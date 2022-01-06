using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace ModifierCreator
{
    public partial class MainForm : Form
    {
        public CompleteModifiers modifiers = new CompleteModifiers();

        public MainForm()
        {
            InitializeComponent();
            modifiers = new CompleteModifiers();
            modifiers.MaxTier = Constants.MaxTier;
            modifiers.FileNamePrefix = Constants.FileNamePrefix;
            modifiers.ModifierSets = new List<ModifierSet>();
            modifiers.SaveFileVersion = Constants.CurrentVersion;
            modifiers.ModName = "Unequal Nations 2";

            version_txt.Text = $"Version: {Constants.CurrentVersion.ToString()}";
            UpdateDisplay();
        }

        private void createNewModifier_btn_Click(object sender, EventArgs e)
        {
            var dialog = new CreateOrEditModifier();
            dialog.Initialize(new ModifierSet());

            dialog.TopMost = this.TopMost;
            dialog.ShowDialog();

            if (!dialog.Cancelled)
            {
                var results = dialog.GetSet();
                modifiers.ModifierSets.Add(results);
                UpdateDisplay();

                if (autoSave_cxb.Checked)
                {
                    button2_Click(sender, e);
                }
            }
        }

        private void editModifier_btn_Click(object sender, EventArgs e)
        {
            if (modifierList_lst.Items.Count == 0 || modifierList_lst.SelectedItem == null)
            {
                return;
            }
            // determine the modifier set we want to edit...
            var itemName = modifierList_lst.SelectedItem.ToString();
            var itemIndex = modifierList_lst.SelectedIndex;

            var dialog = new CreateOrEditModifier();
            dialog.Initialize(modifiers.ModifierSets[itemIndex]);

            dialog.TopMost = this.TopMost;
            dialog.ShowDialog();

            if (!dialog.Cancelled)
            {
                var results = dialog.GetSet();
                if (results.Name == null)
                {
                    return;
                }
                modifiers.ModifierSets[itemIndex] = results;

                // update the modifier set with the new version
                UpdateDisplay();

                if (autoSave_cxb.Checked)
                {
                    button2_Click(sender, e);
                }
            }
        }

        private void deleteModifier_btn_Click(object sender, EventArgs e)
        {
            if (modifierList_lst.Items.Count == 0 || modifierList_lst.SelectedItem == null)
            {
                return;
            }
            var itemIndex = modifierList_lst.SelectedIndex;
            modifiers.ModifierSets.RemoveAt(itemIndex);
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            modifierList_lst.DataSource = null;
            var list = modifiers.ModifierSets.Select(x => x.Name).ToList();
            modifierList_lst.DataSource = list;
            modifiersCount_txt.Text = $"Modifiers: {modifiers.ModifierSets.Count}";
        }

        private void generateModifierFiles_btn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Constants.OutputDirectoryName))
            {
                Directory.Delete(Constants.OutputDirectoryName, true);
            }
            Directory.CreateDirectory(Constants.OutputDirectoryName);
            if (Directory.Exists("localisation"))
            {
                Directory.Delete("localisation", true);
            }
            Directory.CreateDirectory("localisation");

            var localisations = new StringBuilder();
            localisations.AppendLine("l_english:");
            localisations.AppendLine("##### Modifiers");


            var mods = new List<BuffOrNerf>();
            var modifierPrefix = modifiers.ModName.Replace(" - ", "_").Replace(' ', '_').Replace("-", "_").ToLowerInvariant();
            var buffsAndNerfsList = new List<Tuple<bool, int>>()
            {
                new Tuple<bool, int>(true, 3),
                new Tuple<bool, int>(true, 2),
                new Tuple<bool, int>(true, 1),
                new Tuple<bool, int>(false, 1),
                new Tuple<bool, int>(false, 2),
                new Tuple<bool, int>(false, 3),
            };


            foreach (var modifier in modifiers.ModifierSets)
            {
                var modifierOutput = new List<string>();
                mods.Clear();
                var baseName = modifier.Name.Replace(" - ", "_").Replace(' ', '_').Replace("-", "_").ToLowerInvariant();
                
                foreach (var set in buffsAndNerfsList)
                {
                    var name = string.Format("{0}_{1}_{2}_tier_{3}", modifierPrefix, baseName, set.Item1 ? "buff" : "nerf", set.Item2);
                    var localisedName = string.Format("{0} - Tier {2} {1}", modifier.Name, set.Item1 ? "Buff" : "Nerf", set.Item2);
                    mods.Add(new BuffOrNerf(modifier.Name, set.Item1, set.Item2, name));
                    localisations.AppendLine(string.Format(" {0}:0 \"{1}\"", name, localisedName));
                }

                foreach (var mod in modifier.Modifiers)
                {
                    if (mod.Value.Tier1Amount > 0)
                    {
                        mods[2].Rows.Add($"{mod.Value.Name} = {Math.Round(mod.Value.Tier1Amount, 4)}");
                        mods[3].Rows.Add($"{mod.Value.Name} = {Math.Round(-mod.Value.Tier1Amount, 4)}");
                    }
                    if (mod.Value.Tier2Amount > 0)
                    {
                        mods[1].Rows.Add($"{mod.Value.Name} = {Math.Round(mod.Value.Tier2Amount, 4)}");
                        mods[4].Rows.Add($"{mod.Value.Name} = {Math.Round(-mod.Value.Tier2Amount, 4)}");
                    }
                    if (mod.Value.Tier3Amount > 0)
                    {
                        mods[0].Rows.Add($"{mod.Value.Name} = {Math.Round(mod.Value.Tier3Amount, 4)}");
                        mods[5].Rows.Add($"{mod.Value.Name} = {Math.Round(-mod.Value.Tier3Amount, 4)}");
                    }
                }

                var finalFileName = Path.Combine(Constants.OutputDirectoryName, $"{modifier.FileName}.txt");
                var finalText = new List<string>();
                finalText.AddRange(GenerateHeaderText(modifier.Name));
                finalText.AddRange(mods.Select(x => x.ToString()).ToList());
                File.WriteAllLines(finalFileName, finalText);

                var localisationFileName = Path.Combine("localisation", $"{Constants.FileNamePrefix}event_modifiers_l_english.yml");
                File.WriteAllText(localisationFileName, localisations.ToString());
            }
        }

        public List<string> GenerateHeaderText(string name)
        {
            var writtenBy = "Written by von_der_borch";
            var maxLength = name.Length > writtenBy.Length ? name.Length : writtenBy.Length;
            maxLength += 3;

            var outputString = new List<string>();

            var fullLine = new String('#', maxLength);
            var SpacedLine = new String(' ', maxLength);
            outputString.Add($"##{fullLine}##");
            outputString.Add(GetPaddedString(modifiers.ModName, maxLength));
            outputString.Add(GetPaddedString(name, maxLength));
            outputString.Add($"# {SpacedLine} #");
            outputString.Add(GetPaddedString("Written by von_der_borch", maxLength));
            outputString.Add($"##{fullLine}##");

            return outputString;
        }

        public string GetPaddedString(string text, int maxLength)
        {
            var remainingSpaces = maxLength - text.Length;
            return $"# {text}{new String(' ', remainingSpaces)} #";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(Constants.SaveFileName))
            {
                var text = File.ReadAllText(Constants.SaveFileName);

                CompleteModifiers mods = null;
                try
                {
                    mods = JsonConvert.DeserializeObject<CompleteModifiers>(text);
                }
                catch (Exception ex)
                {
                    mods = null;
                }

                if (mods.SaveFileVersion == Constants.CurrentVersion)
                {
                    modifiers = mods;
                }
            }

            UpdateDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var output = JsonConvert.SerializeObject(modifiers);
            if (File.Exists(Constants.SaveFileName))
            {
                File.Delete(Constants.SaveFileName);
            }
            File.WriteAllText(Constants.SaveFileName, output);
        }

        private void keepOnTop_cxb_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = keepOnTop_cxb.Checked;
        }
    }
}
