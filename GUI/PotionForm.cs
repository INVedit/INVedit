using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Minecraft.NBT;

namespace INVedit.GUI
{
    public partial class PotionForm : Form
    {

        ItemSlot slot;
        Dictionary<int, Tuple<NbtTag, ListViewItem>> potioneffects = new Dictionary<int, Tuple<NbtTag, ListViewItem>>();

        public PotionForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            CenterToParent();
        }


        public void Update(ItemSlot slot)
        {
            boxPotionEffects.ItemSelectionChanged -= boxPotionEffectsItemSelectionChanged;
            boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
            editDuration.ValueChanged -= editDurationValueChanged;
            editAmplifier.ValueChanged -= editAmplifierValueChanged;


            this.slot = slot;
            boxPotionEffects.Items.Clear();
            boxName.Items.Clear();
            editDuration.Enabled = false;
            editAmplifier.Enabled = false;
            editDuration.Value = 0;
            editAmplifier.Value = 1;



            if (slot == null || slot.Item == null ||(!slot.Item.Brewable && !slot.Item.Brewed && !boxAllow.Checked))
            {
                boxName.Enabled = false;
            }
            else
            {
                boxName.Enabled = (slot.Item.Brewable || boxAllow.Checked);

                var tag = slot.Item.tag;
                foreach (var kvp in Data.potioneffects)
                {
                    var effect = kvp.Value;
                    if (boxAllow.Checked || effect.items.Contains((string)tag["id"]))
                        boxName.Items.Add(effect);
                }


                boxName.SelectedIndex = 0;
                boxName.Text = boxName.SelectedIndex.ToString();
                
                potioneffects.Clear();

                //Base Potion Check.
                if (tag.Contains("tag") && tag["tag"].Contains("Potion"))
                    Console.WriteLine(tag["tag"]["Potion"].Value);

                if (tag.Contains("tag") && tag["tag"].Contains("CustomPotionEffects"))
                    
                    
                    foreach (var effect in tag["tag"]["CustomPotionEffects"])
                    {
                        int  id = (int)effect["Id"];
                        if (potioneffects.ContainsKey(id))
                            MessageBox.Show("Duplicate potioneffect with ID '" + slot + "' discarded.",
                                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        string name;
                        if (Data.potioneffects.ContainsKey(id))
                            name = Data.potioneffects[id].name;
                        else name = "Unknown potioneffect " + id;
                       
                        var listItem = new ListViewItem(new string[] { name, ((int)effect["Amplifier"]).ToString(), ((int)effect["Duration"] / 20).ToString() });
                        listItem.Tag = id;
                        boxPotionEffects.Items.Add(listItem);
                        potioneffects.Add(id, Tuple.Create(effect, listItem));

                    }
            }

            boxPotionEffects.ItemSelectionChanged += boxPotionEffectsItemSelectionChanged;
            boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
            editDuration.ValueChanged += editDurationValueChanged;
            editAmplifier.ValueChanged += editAmplifierValueChanged;


        }

        Data.PotionEffect lastPotionEffect = null;
        void SelectPotionEffect(int id)
        {
            boxPotionEffects.ItemSelectionChanged -= boxPotionEffectsItemSelectionChanged;
            boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
            editDuration.ValueChanged -= editDurationValueChanged;
            editAmplifier.ValueChanged -= editAmplifierValueChanged;

            Data.PotionEffect effect = null;
            if (Data.potioneffects.ContainsKey(id))
                effect = Data.potioneffects[id];



            NbtTag tag = null;
            if (potioneffects.ContainsKey(id))
                tag = potioneffects[id].Item1;



            boxPotionEffects.SelectedItems.Clear();
            if (potioneffects.ContainsKey(id))
                potioneffects[id].Item2.Selected = true;


            if (lastPotionEffect != null)
                boxName.Items.Remove(lastPotionEffect);

            if (effect == null)
            {
                lastPotionEffect = new Data.PotionEffect(id, "Unknown potioneffect " + id, 0, new List<string>());
                boxName.SelectedIndex = boxName.Items.Add(lastPotionEffect);
            }
            else if (!boxName.Items.Contains(effect))
                boxName.SelectedIndex = boxName.Items.Add(effect);
            else boxName.Text = effect.name;

            editDuration.Enabled = boxAllow.Checked || (effect != null && effect.items.Contains(slot.Item.ID) && (tag == null || (int)tag["Duration"] >= 0 && (int)tag["Duration"] <= effect.max));
            editAmplifier.Enabled = editDuration.Enabled;
            
            bool allow = boxAllow.Checked || effect == null || (tag != null && ((int)tag["Duration"] < 0 || (int)tag["Duration"] > effect.max));
            
            editDuration.Minimum = allow ? -32768 : 0;
            editDuration.Maximum = allow ? (short)32767 : effect.max;
            editDuration.Value = (tag != null) ? (int)tag["Duration"] / 20 : (int)0;

            editAmplifier.Minimum = allow ? -32768 : 1;
            editAmplifier.Maximum = allow ? (short)32767 : editAmplifier.Maximum;
            editAmplifier.Value = (tag != null) ? (int)tag["Amplifier"] : (int)1;   //short or int  Bad Cast??

            boxPotionEffects.ItemSelectionChanged += boxPotionEffectsItemSelectionChanged;
            boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
            editDuration.ValueChanged += editDurationValueChanged;
            editAmplifier.ValueChanged += editAmplifierValueChanged;

        }


        void DeselectPotionEffect()
        {
            boxPotionEffects.ItemSelectionChanged -= boxPotionEffectsItemSelectionChanged;
            boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
            editDuration.ValueChanged -= editDurationValueChanged;
            editAmplifier.ValueChanged -= editAmplifierValueChanged;

            boxPotionEffects.SelectedItems.Clear();
            boxName.SelectedItem = null;
            editDuration.Enabled = false;
            editAmplifier.Enabled = false;
            editDuration.Value = 0;
            editAmplifier.Value = 1;

            boxPotionEffects.ItemSelectionChanged += boxPotionEffectsItemSelectionChanged;
            boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
            editDuration.ValueChanged += editDurationValueChanged;
            editAmplifier.ValueChanged += editAmplifierValueChanged;

        }



        void ChangeLevel(short amplifier, short duration)
        {
            boxPotionEffects.ItemSelectionChanged -= boxPotionEffectsItemSelectionChanged;
            boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
            editDuration.ValueChanged -= editDurationValueChanged;
            editAmplifier.ValueChanged -= editAmplifierValueChanged;

            editDuration.Value = duration;
            editAmplifier.Value = amplifier;



            var potioneffect = (Data.PotionEffect)boxName.SelectedItem;
            if (duration != 0)
            {
                if (!slot.Item.tag.Contains("tag"))
                    slot.Item.tag.Add("tag", NbtTag.CreateCompound());

                if (!slot.Item.tag["tag"].Contains("CustomPotionEffects"))
                    slot.Item.tag["tag"].Add("CustomPotionEffects", NbtTag.CreateList(NbtTagType.Compound));
                
                NbtTag tag = null;

                foreach (var effect in slot.Item.tag["tag"]["CustomPotionEffects"])
                    if ((int)effect["Id"] == potioneffect.id) { tag = effect; break; }


                if (tag == null)
                {
                    tag = NbtTag.CreateCompound(
                        "Id", (int)potioneffect.id,
                        "Amplifier", (int)(amplifier),
                        "Duration", (int)(duration * 20));

                    slot.Item.tag["tag"]["CustomPotionEffects"].Add(tag);

                    var listItem = new ListViewItem(new string[] { potioneffect.name, editAmplifier.Value.ToString(), editDuration.Value.ToString() });
                    listItem.Tag = potioneffect.id;
                    boxPotionEffects.Items.Add(listItem);
                    listItem.Selected = true;
                    potioneffects.Add(potioneffect.id, Tuple.Create(tag, listItem));
                }
                else
                {
                    tag["Duration"].Value = (int)(duration * 20);
                    tag["Amplifier"].Value = (int)amplifier;
                    foreach (ListViewItem item in boxPotionEffects.Items)
                        if ((int)item.Tag == potioneffect.id)
                        {
                            item.SubItems[1].Text = editAmplifier.Value.ToString();
                            item.SubItems[2].Text = editDuration.Value.ToString();
                        }
                }
            }
            else
            {
                NbtTag tag = null;

                if (slot.Item.tag.Contains("CustomPotionEffects"))
                {
                    foreach (var effect in slot.Item.tag["tag"]["CustomPotionEffects"])
                        if ((int)effect["Id"] == potioneffect.id) { tag = effect; break;}
                    tag.Remove();
                    foreach (ListViewItem item in boxPotionEffects.Items)
                        if ((int)item.Tag == potioneffect.id) { item.Remove();break;}

                    if (slot.Item.tag["tag"]["CustomPotionEffects"].Count == 0)
                        slot.Item.tag["tag"]["CustomPotionEffects"].Remove();

                    if (slot.Item.tag["tag"].Count == 0)
                        slot.Item.tag["tag"].Remove();

                    potioneffects.Remove(potioneffect.id);
                }
            }
            slot.CallChanged();

            boxPotionEffects.ItemSelectionChanged += boxPotionEffectsItemSelectionChanged;
            boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
            editDuration.ValueChanged += editDurationValueChanged;
            editAmplifier.ValueChanged += editAmplifierValueChanged;

        }



        void boxPotionEffectsItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                SelectPotionEffect((int)e.Item.Tag);
            else DeselectPotionEffect();
        }

        void BoxNameSelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxName.SelectedItem != null)
                SelectPotionEffect(((Data.PotionEffect)boxName.SelectedItem).id);
        }


        void editDurationValueChanged(object sender, EventArgs e)
        {
            ChangeLevel((short)editAmplifier.Value, (short)editDuration.Value);
        }


        void editAmplifierValueChanged(object sender, EventArgs e)
        {
            ChangeLevel((short)editAmplifier.Value, (short)editDuration.Value);
        }



        void BoxAllowCheckedChanged(object sender, EventArgs e)
        {
            if (slot == null || slot.Item == null) return;

            Data.PotionEffect potioneffect = null;

            if (potioneffect == null && editDuration.Value == 0)
            {
                DeselectPotionEffect();
                return;
            }

            boxName.Enabled = (slot.Item.Brewable || boxAllow.Checked);
            foreach (var kvp in Data.potioneffects)
            {
                var effect = kvp.Value;
                if (boxAllow.Checked || effect.items.Contains(slot.Item.ID))
                {
                    if (!boxName.Items.Contains(effect)) boxName.Items.Add(effect);
                }
                else if (boxName.Items.Contains(effect) &&
                         boxName.SelectedItem != effect) boxName.Items.Remove(effect);
            }

            if (boxName.SelectedItem == null) return;

            editDuration.Enabled = boxAllow.Checked || (potioneffect != null && potioneffect.items.Contains(slot.Item.ID) && editDuration.Value >= 0 && editDuration.Value <= potioneffect.max);
            editAmplifier.Enabled = editDuration.Enabled;

            bool allow = boxAllow.Checked || potioneffect == null || editDuration.Value < 0 || editDuration.Value > potioneffect.max;

            editDuration.Minimum = allow ? -32768 : 0;
            editDuration.Maximum = allow ? (short)32767 : potioneffect.max;

            editAmplifier.Minimum = allow ? -32768 : 1;
            editAmplifier.Maximum = allow ? (short)32767 : editAmplifier.Maximum;
        }

        void boxPotionEffectsKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode & Keys.Delete) != Keys.Delete ||
                slot == null || slot.Item == null ||
                boxName.SelectedItem == null) return;
            ChangeLevel(0, 0);
            DeselectPotionEffect();
        }

        void boxPotionEffectsColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = boxPotionEffects.Columns[e.ColumnIndex].Width;
        }




        private void PotionForm_Load(object sender, EventArgs e)
        {

        }

        private void boxName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boxAllow_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
