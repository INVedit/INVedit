using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Minecraft.NBT;

namespace INVedit
{
    public partial class PotionForm : Form
    {
        ItemSlot slot;
        Dictionary<short, Tuple<NbtTag, ListViewItem>> potioneffects = new Dictionary<short, Tuple<NbtTag, ListViewItem>>();

        public PotionForm()
        {
            InitializeComponent();
            editId.Text = "";
        }

        public void Update(ItemSlot slot)
        {
            boxPotionEffects.ItemSelectionChanged -= boxPotionEffectsItemSelectionChanged;
            editId.ValueChanged -= EditIdValueChanged;
            boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
            editDuration.ValueChanged -= editDurationValueChanged;
            editAmplifier.ValueChanged -= editAmplifierValueChanged;

            this.slot = slot;
            boxPotionEffects.Items.Clear();
            editId.Text = "";
            boxName.Items.Clear();
            editDuration.Enabled = false;
            editAmplifier.Enabled = false;
            editDuration.Value = 0;
            editAmplifier.Value = 1;

            if (slot == null || slot.Item == null ||
                (!slot.Item.Brewable && !slot.Item.Brewed && !boxAllow.Checked))
            {
                editId.Enabled = false;
                boxName.Enabled = false;
            }
            else
            {
                editId.Enabled = boxAllow.Checked;
                boxName.Enabled = (slot.Item.Brewable || boxAllow.Checked);

                var tag = slot.Item.tag;
                foreach (var kvp in Data.potioneffects)
                {
                    var effect = kvp.Value;
                    if (boxAllow.Checked || effect.items.Contains((short)tag["id"]))
                        boxName.Items.Add(effect);
                }

                potioneffects.Clear();
                if (tag.Contains("tag") && tag["tag"].Contains("CustomPotionEffects"))
                    foreach (var effect in tag["tag"]["CustomPotionEffects"])
                    {
                        byte id = (byte)effect["Id"]; //both short
                        if (potioneffects.ContainsKey(id))
                            MessageBox.Show("Duplicate potioneffect with ID '" + slot + "' discarded.",
                                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        string name;
                        if (Data.potioneffects.ContainsKey(id))
                            name = Data.potioneffects[id].name;
                        else name = "Unknown potioneffect " + id;

                        var listItem = new ListViewItem(new string[] { name, ((byte)effect["Amplifier"]).ToString(), ((int)effect["Duration"] / 20).ToString() });
                        listItem.Tag = id;
                        boxPotionEffects.Items.Add(listItem);
                        potioneffects.Add(id, Tuple.Create(effect, listItem));
                    }
            }

            boxPotionEffects.ItemSelectionChanged += boxPotionEffectsItemSelectionChanged;
            editId.ValueChanged += EditIdValueChanged;
            boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
            editDuration.ValueChanged += editDurationValueChanged;
            editAmplifier.ValueChanged += editAmplifierValueChanged;
        }

        Data.PotionEffect lastPotionEffect = null;

        void SelectPotionEffect(short id)
        {
            boxPotionEffects.ItemSelectionChanged -= boxPotionEffectsItemSelectionChanged;
            editId.ValueChanged -= EditIdValueChanged;
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

            editId.Value = id; 
            editId.Text = id.ToString();

            if (lastPotionEffect != null)
                boxName.Items.Remove(lastPotionEffect);
            if (effect == null)
            {
                lastPotionEffect = new Data.PotionEffect(id, "Unknown potioneffect " + id, 0, new List<short>());
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
            editAmplifier.Value = (tag != null) ? (byte)tag["Amplifier"] : (short)1;   //short or int  Bad Cast??


            boxPotionEffects.ItemSelectionChanged += boxPotionEffectsItemSelectionChanged;
            editId.ValueChanged += EditIdValueChanged;
            boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
            editDuration.ValueChanged += editDurationValueChanged;
            editAmplifier.ValueChanged += editAmplifierValueChanged;



        }
        
        
        void DeselectPotionEffect()
        {
            boxPotionEffects.ItemSelectionChanged -= boxPotionEffectsItemSelectionChanged;
            editId.ValueChanged -= EditIdValueChanged;
            boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
            editDuration.ValueChanged -= editDurationValueChanged;
            editAmplifier.ValueChanged -= editAmplifierValueChanged;

            boxPotionEffects.SelectedItems.Clear();
            editId.Value = 0;
            editId.Text = "";
            boxName.SelectedItem = null;
            editDuration.Enabled = false;
            editAmplifier.Enabled = false;
            editDuration.Value = 0;
            editAmplifier.Value = 1;

            boxPotionEffects.ItemSelectionChanged += boxPotionEffectsItemSelectionChanged;
            editId.ValueChanged += EditIdValueChanged;
            boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
            editDuration.ValueChanged += editDurationValueChanged;
            editAmplifier.ValueChanged += editAmplifierValueChanged;
        }


        void ChangeLevel(short amplifier, short duration )
        {
            boxPotionEffects.ItemSelectionChanged -= boxPotionEffectsItemSelectionChanged;
            editId.ValueChanged -= EditIdValueChanged;
            boxName.SelectedIndexChanged -= BoxNameSelectedIndexChanged;
            editDuration.ValueChanged -= editDurationValueChanged;
            editAmplifier.ValueChanged -= editAmplifierValueChanged;



            editDuration.Value = duration;
            editAmplifier.Value = amplifier;

            var potioneffect = (Data.PotionEffect)boxName.SelectedItem;

            if (duration != 0)
            {

                NbtTag tag = null;

                if (!slot.Item.tag.Contains("tag"))
                    slot.Item.tag.Add("tag", NbtTag.CreateCompound());
                    
                if (!slot.Item.tag["tag"].Contains("CustomPotionEffects"))
                        slot.Item.tag["tag"].Add("CustomPotionEffects", NbtTag.CreateList(NbtTagType.Compound));
                    
                foreach (var effect in slot.Item.tag["tag"]["CustomPotionEffects"])
                        if ((byte)effect["Id"] == potioneffect.id) { tag = effect; break; }

                    if (tag == null)
                    {
                        tag = NbtTag.CreateCompound(
                            "Id", (byte)potioneffect.id,
                            "Amplifier", (byte)(amplifier),
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
                        tag["Amplifier"].Value = (byte)amplifier;
                        foreach (ListViewItem item in boxPotionEffects.Items)
                            if ((short)item.Tag == potioneffect.id)
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
                        if ((byte)effect["Id"] == potioneffect.id)
                        {
                            tag = effect;
                            break;
                        }


                    tag.Remove();
                    foreach (ListViewItem item in boxPotionEffects.Items)
                        if ((short)item.Tag == potioneffect.id)
                        {
                            item.Remove();
                            break;
                        }

                    if (slot.Item.tag["tag"]["CustomPotionEffects"].Count == 0)
                        slot.Item.tag["tag"]["CustomPotionEffects"].Remove();

                    if (slot.Item.tag["tag"].Count == 0)
                        slot.Item.tag["tag"].Remove();

                    potioneffects.Remove(potioneffect.id);
                }
                
            }

            slot.CallChanged();

            boxPotionEffects.ItemSelectionChanged += boxPotionEffectsItemSelectionChanged;
            editId.ValueChanged += EditIdValueChanged;
            boxName.SelectedIndexChanged += BoxNameSelectedIndexChanged;
            editDuration.ValueChanged += editDurationValueChanged;
            editAmplifier.ValueChanged += editAmplifierValueChanged;
        }

        void EditIdValueChanged(object sender, EventArgs e)
        {
            SelectPotionEffect((short)editId.Value);
        }
        void BoxNameSelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxName.SelectedItem != null)
                SelectPotionEffect(((Data.PotionEffect)boxName.SelectedItem).id);
        }
        void boxPotionEffectsItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                SelectPotionEffect(Convert.ToInt16(e.Item.Tag));
            else DeselectPotionEffect();
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
            if (Data.potioneffects.ContainsKey((short)editId.Value))
                potioneffect = Data.potioneffects[(short)editId.Value];

            editId.Enabled = boxAllow.Checked;

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

        private void PotionForm_Load(object sender, EventArgs e)
        {

        }

    }
}
