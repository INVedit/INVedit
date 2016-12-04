using System;
using System.IO;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Reflection;
using INVedit.XML;

namespace INVedit
{
	internal static class Data
	{
		static readonly Dictionary<string, Image> images = new Dictionary<string, Image>();
		public static readonly ImageList list = new ImageList(){ ColorDepth = ColorDepth.Depth32Bit };
		public static readonly Items items = new Items();


        public static readonly Dictionary<string, Group> groups = new Dictionary<string, Group>();

        public static readonly List<string> enchantable = new List<string>();
        public static readonly Dictionary<short, Enchantment> enchantments = new Dictionary<short, Enchantment>();


        //Added for Custom Potions
        public static readonly List<string> brewable = new List<string>();
        public static readonly Dictionary<int, PotionEffect> potioneffects = new Dictionary<int, PotionEffect>();



        //Added for Firework Types
        public static readonly List<string> fwdesign = new List<string>();
        public static readonly Dictionary<string, FireworkDesign> fireworkdesigns = new Dictionary<string, FireworkDesign>();






		
		public static Image unknown;
		public static int version = int.MinValue;
		public static string mcVersion = "";


        //Zip File Location
        public static string zipFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + "data.inv";



		public static void Init(string path)
		{
            ResourceManager resources = new ResourceManager("INVedit.Properties.Resources", typeof(Data).Assembly);
			unknown = (Image)resources.GetObject("unknown");

            //unknown = INVedit.Properties.Resources.unknown; ;

			list.Images.Add(unknown);


            XMLReader.sInit(LoadFile("data.xml"));



            while (XMLReader.sPrepareNextNode())
            {
                try
                {
                    if (XMLReader.sCheckElement("Item"))
                    {
                        string id = XMLReader.sReadNextString(); //short.Parse(CXMLReader.sReadNextString());
                        string name = XMLReader.sReadNextString();
                        short dmg = XMLReader.sReadNextShort(); //short.Parse(CXMLReader.sReadNextString());
                        byte stack = XMLReader.sReadNextByte(); //byte.Parse(CXMLReader.sReadNextString());
                        byte maxstack = XMLReader.sReadNextByte(); //byte.Parse(CXMLReader.sReadNextString());
                        short maxdmg = XMLReader.sReadNextShort(); //short.Parse(CXMLReader.sReadNextString());
                        Image img = LoadImage(XMLReader.sReadNextString());


                        items.Add(new Item(id, name, stack, maxstack, dmg, maxdmg, img));

                        continue;


                    }
                    else if (XMLReader.sCheckElement("Enchantment"))
                    {
                        

                        // TODO: items with damage values not yet supported in the item list. At the moment, it doesn't matter, but if mojang implements weapons or armor with
                        // damage values, this part has to be rewritten. (Maybe use a List<Tuple(short,short)> instead of a List<short>?)
                        short id = XMLReader.sReadNextShort();
                        enchantments.Add(id, new Enchantment(id,
                        XMLReader.sReadNextString(),
                        XMLReader.sReadNextShort(),
                        ItemListFromStrArr(XMLReader.sReadNextStringArray(','))
                        ));
                        foreach (string s in enchantments[id].items) { enchantable.Add(s); } //<- ugly, gonna change that
                        continue;
                         
                    }
                    else if (XMLReader.sCheckElement("Group"))
                    {
                        
                        


                        // TODO: Currently, Items have to be parsed BEFORE the groups (that mean that they should be ABOVE the groups in data.xml), because 
                        // copyboy's group class implementation requires an Item object, not just an id. Maybe change that?



                        //Might need to add sub icon or change it so it only needs to read icon name.
                        //Sub icon would only be needed cause there is more then 1 type of stone , wood etc.

                        string groupName = XMLReader.sReadNextString();
                        string groupIconID = XMLReader.sReadNextString();
                        string Damage = XMLReader.sReadNextString();

                        int subItemIcon = 0;

                        foreach (Item ittm in items[(string)groupIconID].Values)
                        {
                            if (Damage == ittm.damage.ToString())
                            {
                                subItemIcon = (int)ittm.imageIndex;
                                break;
                            }
                            
                        }



                        Group group = new Group(groupName, (short)subItemIcon);

                        foreach (Tuple<string, string, string> tpl in TupleListFromStrArr(XMLReader.sReadNextStringArray(',')))
                        {
                            //if (tpl.Item2 != "")
                            //{
                                foreach (Item itm in items[tpl.Item1 + ":" + tpl.Item2].Values)
                                {
                                    if (group.items.Contains(itm))
                                    {
                                        break;
                                    }
                                    else
                                    {                           //Add Checks for null and errors
                                        group.Add(itm);         //Fixed? //Fix - adding same item over and over again.
                                        //break;
                                    }
                                }
                            //}
                            //else if (items[tpl.Item1].ContainsKey(tpl.Item2))
                            //{
                            //    group.Add(items[tpl.Item1][tpl.Item2]);
                            //}
                            //else
                            //{
                            //    throw new Exception(String.Concat("Item with ID ", tpl.Item1, ":", tpl.Item2, " not found. ", XMLReader.sGetPos()));
                            //}
                       }


                        groups.Add(group.name, group);

                        continue;
                          
                          
                         
                    }
                    else if (XMLReader.sCheckElement("PotionEffect"))
                    {

                        int id = XMLReader.sReadNextInt();
                       
                        potioneffects.Add(id, new PotionEffect(id, XMLReader.sReadNextString(), XMLReader.sReadNextShort(), ItemListFromStrArr(XMLReader.sReadNextStringArray(','))));
                        
                        foreach (string s in potioneffects[id].items) 
                        { 
                            brewable.Add(s); 
                        } 
                        continue;
                    }
                    else if (XMLReader.sCheckElement("FireworkType"))
                    {
                        string id = XMLReader.sReadNextString();
                        fireworkdesigns.Add(id, new FireworkDesign(id, XMLReader.sReadNextString()));
                        continue;
                    }
                    else if (XMLReader.sCheckElement("Version"))
                    {
                        version = XMLReader.sReadNextInt();
                        mcVersion = XMLReader.sReadNextString();
                        continue;
                         
                    }


                }
                catch (XmlDataException xdex)
                {
                    MessageBox.Show("Fatal error in initializing or reading of XML data file. INV edit will now exit. " + xdex.Message, "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show(String.Concat("Error parsing ", XMLReader.sGetPos(), " in file data.xml. ", ex.Message, ex.InnerException), "Fatal error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                       == DialogResult.OK) { continue; }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }






            //Old Code
			/*
			string[] lines = File.ReadAllLines(path);
			for (int i = 1; i <= lines.Length; ++i) {
				try {
					string line = lines[i-1].TrimStart();
					if (line=="" || line[0]=='#') continue;
					string[] split;
					if (line[0] == ':') {
						split = line.Split(new char[]{' '}, 2, StringSplitOptions.RemoveEmptyEntries);
						switch (split[0].ToLower()) {
							case ":version":
								try { version = int.Parse(split[1]); }
								catch (Exception e) { throw new DataException("Failed to parse option "+split[0]+".", e); }
								break;
							case ":mc-version":
								mcVersion = split[1];
								break;
							default:
								throw new DataException("Unknown option '"+split[0]+"'.");
						} continue;
					}
					split = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
					Exception ex = new DataException("Invalid number of colums.");
					if (line[0]=='~') { if (split.Length != 4) throw ex; }
					else if (line[0]=='+') { if (split.Length != 5) throw ex; }
					else { if (split.Length < 4 || split.Length > 5) throw ex; }
					if (line[0]=='~') {
						string name = split[1].Replace('_', ' ');
						string icon;
						try { icon = split[2]; }
						catch (Exception e) { throw new DataException("Failed to parse column 'ICON'.", e); }

						if (!items.ContainsKey(icon)) throw new DataException("Invalid item id '"+icon+"' in column 'ICON'.");

						int imageIndex = items[icon][0].imageIndex;
						string[] l = split[3].Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
						Group group = new Group(name, imageIndex);
						foreach (string nn in l) {
							string n = nn;
							string s;
							short d = -1;
							if (n.IndexOf('~') != -1) {
								string[] sp = n.Split('~');
								n = sp[0];
								try { d = short.Parse(sp[1]); }
								catch (Exception e) { throw new DataException("Failed to parse column 'ITEMS'.", e); }
							}
							try { s = n; }
							catch (Exception e) { throw new DataException("Failed to parse column 'ITEMS'.", e); }
							if (!items.ContainsKey(s))
								throw new DataException("Invalid item id '"+s+"' in column 'ITEMS'.");
							if (d == -1) foreach (Item item in items[s].Values) group.Add(item);
							else if (items[s].ContainsKey(d)) group.Add(items[s][d]);
							else throw new DataException("Invalid item damage '"+d+"' in column 'ITEMS'.");
						}
						groups.Add(name, group);
					} else if (line[0]=='+') {
						string id;
                        //try { id = short.Parse(split[1]); }
                        try { id = split[1]; }
						catch (Exception e) { throw new DataException("Failed to parse column 'EID'.", e); }
						string name = split[2].Replace('_', ' ');
						short max;
						try { max = short.Parse(split[3]); }
						catch (Exception e) { throw new DataException("Failed to parse column 'MAX'.", e); }
						string[] l = split[4].Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
						List<string> itemList = new List<string>();
						foreach (string nn in l) {
							string n = nn;
							string s;
							try { s = n; }
							catch (Exception e) { throw new DataException("Failed to parse column 'ITEMS'.", e); }
							if (!items.ContainsKey(s))
								throw new DataException("Invalid item id '"+s+"' in column 'ITEMS'.");
							enchantable.Add(s);
							itemList.Add(s);
						}
						enchantments.Add(id,  new Enchantment(id, name, max, itemList));
					} else {
						string name = split[1].Replace('_', ' ');
						string id;
						//try { id = short.Parse(split[0]); }
                        try { id = split[0]; }
						catch (Exception e) { throw new DataException("Failed to parse column 'ID'.", e); }
						Image image;
						try { image = LoadImage(split[2]); }
						catch (Exception e) { throw new DataException("Failed to load image '"+split[2]+"' ("+e.Message+").", e); }
						string[] cords = split[3].Split(',');
						if (cords.Length != 2) throw new DataException("Failed to parse column 'CORDS'.");
						int x, y;
						try {
							x = int.Parse(cords[0]);
							y = int.Parse(cords[1]);
						} catch (Exception e) { throw new DataException("Failed to parse column 'CORDS'.", e); }
						if (x < 0 || y < 0 || x*16+16 > image.Width || y*16+16 > image.Height)
							throw new DataException("Invalid image cords "+x+","+y+".");
						byte stack = 64;
						byte preferred = 0;
						short damage = 0;
						short maxDamage = 0;
						bool brackets = false;
						if (split.Length == 5) {
							string str = split[4];
							char chr = ' ';
							if (str[0] == '(') {
								if (str[str.Length - 1] != ')')
									throw new DataException("Failed to parse column 'DAMAGE'.");
								str = str.Substring(1, str.Length - 2);
								brackets = true;
							}
							if (str[0] == '+' || str[0] == 'x') {
								chr = str[0];
								str = str.Substring(1, str.Length - 1);
							}
							short val;
							try { val = short.Parse(str); }
							catch (Exception e) { throw new DataException("Failed to parse column 'DAMAGE'.", e); }
							switch (chr) {
								case '+':
									if (brackets || val <= 0) throw new DataException("Failed to parse column 'DAMAGE'.");
									stack = 1;
									maxDamage = val;
									break;
								case 'x':
									if (val <= 0) throw new DataException("Failed to parse column 'DAMAGE'.");
									if (val > 255) throw new DataException("Failed to parse column 'DAMAGE'.");
									if (brackets) preferred = (byte)val;
									else stack = (byte)val;
									break;
								default:
									if (brackets) throw new DataException("Failed to parse column 'DAMAGE'.");
									damage = val;
									break;
							}
						}
						if (preferred == 0)
							preferred = stack;
						items.Add(new Item(id, name, stack, preferred, damage, maxDamage, image, x, y));
					}
				} catch (Exception e) {
					if (MessageBox.Show("Error at line "+i+": "+e.Message, "Warning",
					                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
						return;
				}
			}*/




		}




        static List<string> ItemListFromStrArr(string[] _sarr)
        {
            try
            {
                var list = new List<string>();
                foreach (string s in _sarr)
                {
                    //list.Add(short.Parse(s));
                    list.Add(s);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Error in converting string array to ItemList. ", ex.Message));
            }
        }




        static List<Tuple<string, string, string>> TupleListFromStrArr(string[] _sarr)
        {
            try
            {
                var list = new List<Tuple<string, string, string>>();
                foreach (string s in _sarr)
                {
                    if (s.Contains(":"))
                    {
                        string[] split = s.Split(new char[] { ':' });
                        list.Add(new Tuple<string, string, string>(split[0], split[1], split[2]));
                        continue;
                    }
                    else
                    {
                        list.Add(new Tuple<string, string, string>(s, "0", "0"));
                        continue;
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Error in converting string array to TupleList. ", ex.Message));
            }
        }








        static string[] LoadItems(string itemsName)
        {
            try
            {
                string[] rtn = new string[0];
                Zip zip = Zip.Open(zipFile, FileAccess.Read);
                List<Zip.ZipFileEntry> dir = zip.ReadCentralDir();

                string zipItemsName;
                foreach (Zip.ZipFileEntry entry in dir)
                {
                    zipItemsName = Path.GetFileName(entry.FilenameInZip);
                    if (zipItemsName == itemsName)
                    {
                        rtn = zip.ExtractTextFile(entry);
                        break;
                    }
                }
                zip.Close();
                return rtn;
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("Error: Invalid or not supported Zip file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Error while processing source file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;


        }

















        static MemoryStream LoadFile(string fileName)
        {
            try
            {
                MemoryStream strmm = new MemoryStream();

                Zip zip = Zip.Open(zipFile, FileAccess.Read);
                List<Zip.ZipFileEntry> dir = zip.ReadCentralDir();

                string zipFileName;
                foreach (Zip.ZipFileEntry entry in dir)
                {
                    zipFileName = Path.GetFileName(entry.FilenameInZip);
                    if (zipFileName == fileName)
                    {

                        if (zip.ExtractFile(entry, strmm))
                        {
                            break;
                        }
                    }
                }
                zip.Close();
                strmm.Position = 0;
                return strmm;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while processing source file. - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }










        static Image LoadImage(string imgName)
        {
            try
            {
                Image rtn = null;
                Zip zip = Zip.Open(zipFile, FileAccess.Read);
                List<Zip.ZipFileEntry> dir = zip.ReadCentralDir();

                string zipImageName;
                foreach (Zip.ZipFileEntry entry in dir)
                {
                    zipImageName = Path.GetFileName(entry.FilenameInZip);
                    if (zipImageName == imgName)
                    {
                        rtn = zip.ExtractImage(entry);
                        break;
                    }
                }
                zip.Close();
                return rtn;
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("Error: Invalid or not supported Zip file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Error while processing source file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
		



		internal class Items : Dictionary<string, Dictionary<string, Item>>
		{
			public void Add(Item item)
			{
				Dictionary<string, Item> list;
				if (ContainsKey(item.id)) list = this[item.id];
				else { list = new Dictionary<string, Item>(); Add(item.id, list); }
				list.Add(item.damage.ToString(), item);
			}
		}
		
		internal class Item
		{
			public readonly string id;
			public readonly string name;
			public readonly byte stack;
			public readonly byte preferred;
			public readonly short damage;
			public readonly short maxDamage;
			public readonly int imageIndex;
			
			internal Item(string id, string name, byte stack, byte preferred, short damage, short maxDamage, Image image)
			{
				this.id = id;
				this.name = name;
				this.stack = stack;
				this.preferred = preferred;
				this.damage = damage;
				this.maxDamage = maxDamage;
				
				Bitmap b = new Bitmap(16, 16);
				using (Graphics g = Graphics.FromImage(b))
					g.DrawImage(image, new Rectangle(0, 0, 16, 16), new Rectangle(0, 0, 16, 16), GraphicsUnit.Pixel); //possible fix the 2 zeros
				
				imageIndex = Data.list.Images.Count;
				Data.list.Images.Add(b);
			}
		}
		
		internal class Group
		{
			public readonly string name;
			public readonly short imageIndex;
			public readonly List<Item> items = new List<Item>();
			
			internal Group(string name, short imageIndex)
			{
				this.name = name;
				this.imageIndex = imageIndex;
			}
			internal void Add(Item item)
			{
				items.Add(item);
			}
		}
		
		internal class Enchantment
		{
			public readonly short id;
			public readonly string name;
			public readonly short max;
			public readonly List<string> items;
			
			internal Enchantment(short id, string name, short max, List<string> items)
			{
				this.id = id;
				this.name = name;
				this.max = max;
				this.items = items;
			}
			public override string ToString() { return name; }
		}





        //Added for Custom Potions
        internal class PotionEffect
        {
            public readonly int id;
            public readonly string name;
            public readonly short max;
            public readonly List<string> items;

            internal PotionEffect(int id, string name, short max, List<string> items)
            {
                this.id = id;
                this.name = name;
                this.max = max;
                this.items = items;
            }
            public override string ToString() { return name; }
        }


        //Added for Fireworks
        internal class FireworkDesign
        {
            public readonly string id;
            public readonly string name;

            internal FireworkDesign(string id, string name)
            {
                this.id = id;
                this.name = name;
            }
            public override string ToString() { return name; }
        }








	}
	
	public class DataException : Exception
	{
		public DataException() : base() {  }
		public DataException(string message) : base(message) {  }
		public DataException(string message, Exception innerException) : base(message, innerException) {  }
	}
}
