using System;
using System.Linq;
using System.Windows.Forms;

namespace ModifierCreator
{
    public partial class CreateOrEditModifier : Form
    {
        private ModifierSet _set;

        public bool Cancelled = false;

        public CreateOrEditModifier()
        {
            InitializeComponent();
        }

        public void Initialize(ModifierSet set)
        {
            _set = set;
            modifierName_txt.Text = _set.Name;
            fileName_txt.Text = _set.FileName;

            UpdateGameModifiersList();
        }

        public void UpdateGameModifiersList()
        {
            var oldGameModifierIndex = gameModifiers_lst.SelectedIndex;
            var oldAddedModifierIndex = addedModifiers_lst.SelectedIndex;

            gameModifiers_lst.DataSource = null;
            addedModifiers_lst.DataSource = null;

            var mods = Constants.Instance.GetModifiers();

            foreach (var modifier in _set.Modifiers)
            {
                mods.Remove(modifier.Key);
            }
            gameModifiers_lst.DataSource = mods;
            addedModifiers_lst.DataSource = _set.Modifiers.Select(x => $"{x.Key} -> (T1: {x.Value.Tier1Amount}, T2: {x.Value.Tier2Amount}, T3: {x.Value.Tier3Amount})").ToList();

            gameModifiers_lst.Refresh();
            addedModifiers_lst.Refresh();
            availableCount_txt.Text = $"Available Modifiers: {gameModifiers_lst.Items.Count}";
            choosenCount_txt.Text = $"Selected Modifiers: {addedModifiers_lst.Items.Count}";

            manualInput_txt.Text = String.Empty;
            if (gameModifiers_lst.Items.Count > 0)
            {
                gameModifiers_lst.SelectedIndex = oldGameModifierIndex > 0
                    ? gameModifiers_lst.Items.Count > oldGameModifierIndex
                        ? oldGameModifierIndex
                        : oldGameModifierIndex - 1
                    : 0;
            }
            if (addedModifiers_lst.Items.Count > 0)
            {
                addedModifiers_lst.SelectedIndex = oldAddedModifierIndex > 0
                    ? addedModifiers_lst.Items.Count > oldAddedModifierIndex
                        ? oldAddedModifierIndex
                        : oldAddedModifierIndex - 1
                    : 0;
            }
        }

        public ModifierSet GetSet()
        {
            return _set;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            this.Close();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            _set.Name = modifierName_txt.Text;
            _set.FileName = fileName_txt.Text;

            this.Close();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (gameModifiers_lst.SelectedItems.Count == 0 || gameModifiers_lst.SelectedItem == null)
            {
                return;
            }

            var dialog = new ModifierConfig();
            var modifierName = gameModifiers_lst.SelectedItem.ToString();
            dialog.Initialize(new Modifier() { Name = modifierName });

            dialog.TopMost = this.TopMost;
            dialog.ShowDialog();

            if (!dialog.Cancelled)
            {
                var modifier = dialog.GetModifier();
                _set.Modifiers.Add(modifier.Name, modifier);

                UpdateGameModifiersList();
            }
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            if (addedModifiers_lst.SelectedItems.Count == 0 || addedModifiers_lst.SelectedItem == null)
            {
                return;
            }

            var dialog = new ModifierConfig();
            var item = addedModifiers_lst.SelectedItem.ToString();
            var oldModifierName = item.Substring(0, item.IndexOf(" ->"));
            dialog.Initialize(_set.Modifiers[oldModifierName]);

            dialog.TopMost = this.TopMost;
            dialog.ShowDialog();

            if (!dialog.Cancelled)
            {
                var modifier = dialog.GetModifier();
                _set.Modifiers[oldModifierName] = modifier;

                UpdateGameModifiersList();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (addedModifiers_lst.SelectedItems.Count == 0 || addedModifiers_lst.SelectedItem == null)
            {
                return;
            }
            
            var item = addedModifiers_lst.SelectedItem.ToString();
            var modifierToDelete = item.Substring(0, item.IndexOf(" ->"));
            _set.Modifiers.Remove(modifierToDelete);

            UpdateGameModifiersList();
        }

        private void CreateOrEditModifier_Load(object sender, EventArgs e)
        {
            gameModifiers_lst.DataSource = Constants.Instance.GetModifiers();
            addedModifiers_lst.DataSource = _set.Modifiers.Keys.ToList();
            UpdateGameModifiersList();
        }

        private void modifierName_txt_TextChanged(object sender, EventArgs e)
        {
            var rawText = modifierName_txt.Text;
            fileName_txt.Text = String.Format("{0}{1}", Constants.FileNamePrefix, rawText.Replace(" - ", "_").Replace(' ', '_').Replace("-", "_").ToLowerInvariant());
        }

        private void find_btn_Click(object sender, EventArgs e)
        {
            var index = gameModifiers_lst.FindString(manualInput_txt.Text);
            gameModifiers_lst.SelectedIndex = index;
        }

        private void manualInput_txt_TextChanged(object sender, EventArgs e)
        {
            var index = gameModifiers_lst.FindString(manualInput_txt.Text);
            gameModifiers_lst.SelectedIndex = index;
        }
    }
}
