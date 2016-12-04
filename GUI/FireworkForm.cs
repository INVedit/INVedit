using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Minecraft.NBT;

namespace INVedit
{
    public partial class FireworkForm : Form
    {
        ItemSlot slot;
        Dictionary<short, Tuple<NbtTag, ListViewItem>> fireworkdesigns = new Dictionary<short, Tuple<NbtTag, ListViewItem>>();


        public FireworkForm()
        {
            InitializeComponent();
        }

        public void Update(ItemSlot slot)
        {

            this.slot = slot;
            Item item = ((slot != null) ? slot.Item : null);


            if (item == null)
                return;

            boxType.Items.Clear();
            foreach (var kvp in Data.fireworkdesigns)
            {
                var design = kvp.Value;
                    boxType.Items.Add(design);
            }

            lvwColors.Items.Clear();
            boxType.Text = "";
            chkFlicker.Checked = false;
            chkTrail.Checked = false;
            editFlight.Value = 3;
            boxType.SelectedIndex = 0;
            editFlight.Enabled = (item != null && item.ID == "minecraft:fireworks");
            boxType.Enabled = (item != null && item.ID == "minecraft:fireworks" || item.ID == "minecraft:firework_charge");
            chkFlicker.Enabled = (item != null && item.ID == "minecraft:fireworks" || item.ID == "minecraft:firework_charge");
            chkTrail.Enabled = (item != null && item.ID == "minecraft:fireworks" || item.ID == "minecraft:firework_charge");
            lvwColors.Enabled = (item != null && item.ID == "minecraft:fireworks" || item.ID == "minecraft:firework_charge");
            btnAdd.Enabled = (item != null && item.ID == "minecraft:fireworks" || item.ID == "minecraft:firework_charge");
            btnRemove.Enabled = (item != null && item.ID == "minecraft:fireworks" || item.ID == "minecraft:firework_charge");

            if (item.ID == "minecraft:fireworks")
            {
                if (item != null && item.tag.Contains("tag"))
                {
                    var tag = item.tag["tag"];
                    if (tag.Contains("Fireworks"))
                    {
                        var fireworks = tag["Fireworks"];

                        if (fireworks.Contains("Flight"))
                            editFlight.Value = (byte)fireworks["Flight"];

                        if (tag.Contains("Fireworks") && tag["Fireworks"].Contains("Explosions"))
                        {

                            foreach (var explosion in tag["Fireworks"]["Explosions"])
                            {

                                if (explosion.Contains("Trail"))
                                {
                                    byte trail = (byte)explosion["Trail"];
                                    chkTrail.Checked = Convert.ToBoolean(trail);
                                }


                                if (explosion.Contains("Type"))
                                {
                                    byte type = (byte)explosion["Type"];
                                    boxType.SelectedIndex = type;
                                }


                                if (explosion.Contains("Flicker"))
                                {
                                    byte flicker = (byte)explosion["Flicker"];
                                    chkFlicker.Checked = Convert.ToBoolean(flicker);

                                }


                                if (explosion.Contains("Colors"))
                                {
                                    int[] colors = (int[])explosion["Colors"];

                                    for (int i = 0; i < colors.Length; i++)
                                    {
                                        lvwColors.Items.Add(colors[i].ToString("X6"));
                                        lvwColors.Items[i].BackColor = ColorTranslator.FromHtml("#" + colors[i].ToString("X6"));
                                    }
                                }
                            }
                        }
                    }
                }

            }
            else if (item.ID == "minecraft:firework_charge")
            {

                if (item != null && item.tag.Contains("tag"))
                {
                    var tag = item.tag["tag"];

                        if (tag.Contains("Explosion"))
                        {

                            tag = item.tag["tag"]["Explosion"];


                            if (tag.Contains("Trail"))
                            {
                                byte trail = (byte)tag["Trail"];
                                chkTrail.Checked = Convert.ToBoolean(trail);
                            }


                            if (tag.Contains("Type"))
                            {
                                byte type = (byte)tag["Type"];
                                boxType.SelectedIndex = type;
                            }


                            if (tag.Contains("Flicker"))
                            {
                                byte flicker = (byte)tag["Flicker"];
                                chkFlicker.Checked = Convert.ToBoolean(flicker);
                            }


                            if (tag.Contains("Colors"))
                            {
                                int[] colors = (int[]) tag["Colors"];

                                for (int i = 0; i < colors.Length; i++)
                                {
                                    lvwColors.Items.Add(colors[i].ToString("X6"));
                                    lvwColors.Items[i].BackColor = ColorTranslator.FromHtml("#" + colors[i].ToString("X6"));
                                }
                            }
                        
                    }                    
                }
            }
        }


        void ChangeFirework(byte type, byte flight, byte trail, byte flicker, int[] colors)
        {

            if (slot.Item.ID == "minecraft:fireworks")
            {
                if (slot.Item.tag.Contains("tag"))
                {
                    slot.Item.tag["tag"]["Fireworks"]["Explosions"].Remove();
                    slot.Item.tag["tag"]["Fireworks"].Remove();
                    slot.Item.tag["tag"].Remove();

                }
            }
            else if (slot.Item.ID == "minecraft:firework_charge")
            {
                if (slot.Item.tag.Contains("tag"))
                {
                    slot.Item.tag["tag"]["Explosion"].Remove();
                    slot.Item.tag["tag"].Remove();
                }
            }

            NbtTag tag = null;

            if (slot.Item.ID == "minecraft:fireworks")
            {

                if (!slot.Item.tag.Contains("tag"))
                    slot.Item.tag.Add("tag", NbtTag.CreateCompound());

                if (!slot.Item.tag["tag"].Contains("Fireworks"))
                    slot.Item.tag["tag"].Add("Fireworks", NbtTag.CreateCompound());

                slot.Item.tag["tag"]["Fireworks"].Add("Flight", (byte)flight);
                slot.Item.tag["tag"]["Fireworks"].Add("Explosions", NbtTag.CreateList(NbtTagType.Compound));

                tag = NbtTag.CreateCompound("Flicker", (byte)flicker, "Trail", (byte)trail, "Type", (byte)type, "Colors", (int[])colors);
                slot.Item.tag["tag"]["Fireworks"]["Explosions"].Add(tag);

            }
            else if (slot.Item.ID == "minecraft:firework_charge")
            {
                if (!slot.Item.tag.Contains("tag"))
                    slot.Item.tag.Add("tag", NbtTag.CreateCompound());

                slot.Item.tag["tag"].Add("Explosion", NbtTag.CreateCompound());

                slot.Item.tag["tag"]["Explosion"].Add("Flicker", (byte)flicker);
                slot.Item.tag["tag"]["Explosion"].Add("Trail", (byte)trail);
                slot.Item.tag["tag"]["Explosion"].Add("Type", (byte)type);
                slot.Item.tag["tag"]["Explosion"].Add("Colors", (int[])colors);
            }

            slot.CallChanged();

        }

        private void FireworkForm_Load(object sender, EventArgs e)
        {

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel) return;

            var color = colorDialog.Color;
            lvwColors.Items.Add((color.ToArgb() & 0xFFFFFF).ToString("X6"));

            string rgb = (color.ToArgb() & 0xFFFFFF).ToString("X6");
            lvwColors.Items[lvwColors.Items.Count - 1].BackColor = ColorTranslator.FromHtml("#" + rgb);
            lvwColors.Items[lvwColors.Items.Count - 1].EnsureVisible();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in lvwColors.SelectedItems)
            {
                lvwColors.Items.Remove(eachItem);
            }
        }

        private void FireworkForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Item item = ((slot != null) ? slot.Item : null);
            if (slot == null || item == null)
                return;

            int[] clrList = new int[lvwColors.Items.Count];

            for (int i = 0; i < lvwColors.Items.Count; i++)
            {
                string hex = lvwColors.Items[i].Text;
                clrList[i] = Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber);   
            }

            ChangeFirework((byte)boxType.SelectedIndex, (byte)editFlight.Value, Convert.ToByte(chkTrail.CheckState), Convert.ToByte(chkFlicker.CheckState), clrList);
        }

     
    }
}
