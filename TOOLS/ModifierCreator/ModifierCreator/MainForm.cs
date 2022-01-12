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
                if (!string.IsNullOrWhiteSpace(results.Name))
                {
                    modifiers.ModifierSets.Add(results);
                    UpdateDisplay();

                    if (autoSave_cxb.Checked)
                    {
                        button2_Click(sender, e);
                    }
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

            var indexesToRemove = new Stack<int>();
            for (var i = 0; i < modifiers.ModifierSets.Count; i++)
            {
                if (string.IsNullOrEmpty(modifiers.ModifierSets[i].Name))
                {
                    indexesToRemove.Push(i);
                }
            }
            while (indexesToRemove.Count > 0)
            {
                var i = indexesToRemove.Pop();
                modifiers.ModifierSets.RemoveAt(i);
            }

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
            if (Directory.Exists("raw_data"))
            {
                Directory.Delete("raw_data", true);
            }
            Directory.CreateDirectory("raw_data");

            var localisations = new StringBuilder();
            localisations.AppendLine("l_english:");
            localisations.AppendLine("##### Modifiers");

            var modifierList = new StringBuilder();
            var randomizerList = new StringBuilder();
            var legendaryBuffList = new StringBuilder();
            var legendaryBuffAppliedModifiersList = new StringBuilder();
            var legendaryNerfList = new StringBuilder();
            var legendaryNerfAppliedModifiersList = new StringBuilder();
            legendaryBuffList.AppendLine("limit = {");
            legendaryBuffList.AppendLine("    has_country_flag = unequal_nations_2_legendary_buff_nation");
            legendaryBuffList.AppendLine("}");
            legendaryBuffList.AppendLine("clr_country_flag = unequal_nations_2_legendary_buff_nation");
            legendaryBuffList.AppendLine("");
            legendaryNerfList.AppendLine("limit = {");
            legendaryNerfList.AppendLine("    has_country_flag = unequal_nations_2_legendary_nerf_nation");
            legendaryNerfList.AppendLine("}");
            legendaryNerfList.AppendLine("clr_country_flag = unequal_nations_2_legendary_nerf_nation");
            legendaryNerfList.AppendLine("");

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

                var amountTier1Modifiers = modifier.Modifiers.Where(x => x.Value.Tier1Amount != decimal.Zero).ToList().Count;
                var amountTier2Modifiers = modifier.Modifiers.Where(x => x.Value.Tier2Amount != decimal.Zero).ToList().Count;
                var amountTier3Modifiers = modifier.Modifiers.Where(x => x.Value.Tier3Amount != decimal.Zero).ToList().Count;
                var onlyTier1 = false;

                foreach (var set in buffsAndNerfsList)
                {
                    var name = string.Format("{0}_{1}_{2}_tier_{3}", modifierPrefix, baseName, set.Item1 ? "buff" : "nerf", set.Item2);
                    var localisedName = string.Format("{0} - Tier {2} {1}", modifier.Name, set.Item1 ? "Buff" : "Nerf", set.Item2);

                    if (set.Item2 == 1 && amountTier2Modifiers == 0 && amountTier3Modifiers == 0)
                    {
                        name = string.Format("{0}_{1}_{2}", modifierPrefix, baseName, set.Item1 ? "buff" : "nerf");
                        localisedName = string.Format("{0} {1}", modifier.Name, set.Item1 ? "Buff" : "Nerf");
                    }
                    else if ((set.Item2 == 2 && amountTier2Modifiers == 0) || (set.Item2 == 3 && amountTier3Modifiers == 0))
                    {
                        name = String.Empty;
                        localisedName = String.Empty;
                        onlyTier1 = true;
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        mods.Add(new BuffOrNerf(modifier.Name, set.Item1, set.Item2, name));
                        localisations.AppendLine(string.Format(" {0}:0 \"{1}\"", name, localisedName));
                        modifierList.AppendLine(name);
                        legendaryBuffList.AppendLine($"remove_country_modifier = {name}");
                        legendaryNerfList.AppendLine($"remove_country_modifier = {name}");

                        if (set.Item2 == 3)
                        {
                            if (set.Item1 == true)
                            {
                                legendaryBuffAppliedModifiersList.AppendLine("add_country_modifier = {");
                                legendaryBuffAppliedModifiersList.AppendLine(String.Format("    name = {0}", name));
                                legendaryBuffAppliedModifiersList.AppendLine("    duration = -1");
                                legendaryBuffAppliedModifiersList.AppendLine("}");
                            }
                            else
                            {
                                legendaryNerfAppliedModifiersList.AppendLine("add_country_modifier = {");
                                legendaryNerfAppliedModifiersList.AppendLine(String.Format("    name = {0}", name));
                                legendaryNerfAppliedModifiersList.AppendLine("    duration = -1");
                                legendaryNerfAppliedModifiersList.AppendLine("}");
                            }
                        }
                    }

                }

                foreach (var mod in modifier.Modifiers)
                {
                    if (mod.Value.Tier1Amount != decimal.Zero && onlyTier1)
                    {
                        mods[0].Rows.Add($"{mod.Value.Name} = {Math.Round(mod.Value.Tier1Amount, 4)}");
                        mods[1].Rows.Add($"{mod.Value.Name} = {Math.Round(-mod.Value.Tier1Amount, 4)}");
                    }
                    else
                    {
                        mods[2].Rows.Add($"{mod.Value.Name} = {Math.Round(mod.Value.Tier1Amount, 4)}");
                        mods[3].Rows.Add($"{mod.Value.Name} = {Math.Round(-mod.Value.Tier1Amount, 4)}");
                    }
                    if (mod.Value.Tier2Amount != decimal.Zero)
                    {
                        mods[1].Rows.Add($"{mod.Value.Name} = {Math.Round(mod.Value.Tier2Amount, 4)}");
                        mods[4].Rows.Add($"{mod.Value.Name} = {Math.Round(-mod.Value.Tier2Amount, 4)}");
                    }
                    if (mod.Value.Tier3Amount != decimal.Zero)
                    {
                        mods[0].Rows.Add($"{mod.Value.Name} = {Math.Round(mod.Value.Tier3Amount, 4)}");
                        mods[5].Rows.Add($"{mod.Value.Name} = {Math.Round(-mod.Value.Tier3Amount, 4)}");
                    }
                }

                randomizerList.AppendLine($"# {modifier.Name}");
                randomizerList.AppendLine("if = {");
                randomizerList.AppendLine("    limit = {");
                randomizerList.AppendLine("        OR = {");
                randomizerList.AppendLine("            AND = {");
                randomizerList.AppendLine("                ai = no");
                randomizerList.AppendLine("                NOT = { has_global_flag = unequal_nations_2_option_player_impacted_no }");
                randomizerList.AppendLine("            }");
                randomizerList.AppendLine("            AND = {");
                randomizerList.AppendLine("                ai = yes");
                randomizerList.AppendLine("                NOT = { has_global_flag = unequal_nations_2_option_ai_impacted_no }");
                randomizerList.AppendLine("            }");
                randomizerList.AppendLine("        }");
                randomizerList.AppendLine("    }");
                // 10 - 15 - 20 - 5 - 20 - 15 - 10
                randomizerList.AppendLine("    random_list = {");
                randomizerList.AppendLine("        5 = { }");
                foreach (var mod in mods)
                {
                    var amount = mod.Tier == 1
                        ? "20"
                        : mod.Tier == 2
                        ? "15"
                        : "10";
                    randomizerList.AppendLine(String.Format("        {0} = {{", amount));
                    randomizerList.AppendLine("            trigger = {");
                    randomizerList.AppendLine("                OR = {");
                    randomizerList.AppendLine("                    AND = {");
                    randomizerList.AppendLine("                        ai = no");
                    if (mod.Tier == 1)
                    {
                        randomizerList.AppendLine("                        NOT = { has_global_flag = unequal_nations_2_option_player_impacted_no }");
                    }
                    else
                    {
                        randomizerList.AppendLine("                        OR = {");
                        randomizerList.AppendLine("                            has_global_flag = unequal_nations_2_option_player_impacted_tier3");
                        randomizerList.AppendLine("                            has_global_flag = unequal_nations_2_option_player_impacted_legendary");
                        randomizerList.AppendLine("                        }");
                    }

                    randomizerList.AppendLine("                    }");
                    randomizerList.AppendLine("                    AND = {");
                    randomizerList.AppendLine("                        ai = yes");
                    if (mod.Tier == 1)
                    {
                        randomizerList.AppendLine("                        NOT = { has_global_flag = unequal_nations_2_option_ai_impacted_no }");
                    }
                    else
                    {
                        randomizerList.AppendLine("                        OR = {");
                        randomizerList.AppendLine("                            has_global_flag = unequal_nations_2_option_ai_impacted_tier3");
                        randomizerList.AppendLine("                            has_global_flag = unequal_nations_2_option_ai_impacted_legendary");
                        randomizerList.AppendLine("                        }");
                    }

                    randomizerList.AppendLine("                    }");
                    randomizerList.AppendLine("                }");
                    randomizerList.AppendLine("            }");
                    randomizerList.AppendLine("            add_country_modifier = {");
                    randomizerList.AppendLine(String.Format("                name = {0}", mod.ModifierName));
                    randomizerList.AppendLine("                duration = -1");
                    randomizerList.AppendLine("            }");

                    randomizerList.AppendLine("        }");
                }
                randomizerList.AppendLine("    }");
                randomizerList.AppendLine("}");
                randomizerList.AppendLine("");

                var finalFileName = Path.Combine(Constants.OutputDirectoryName, $"{modifier.FileName}.txt");
                var finalText = new List<string>();
                finalText.AddRange(GenerateHeaderText(modifier.Name));
                finalText.AddRange(mods.Select(x => x.ToString()).ToList());
                File.WriteAllLines(finalFileName, finalText);
            }

            var localisationFileName = Path.Combine("localisation", $"{Constants.FileNamePrefix}event_modifiers_l_english.yml");
            File.WriteAllText(localisationFileName, localisations.ToString());

            var rawDataFileName = Path.Combine("raw_data", $"{Constants.FileNamePrefix}modifier_list.txt");
            File.WriteAllText(rawDataFileName, modifierList.ToString());
            rawDataFileName = Path.Combine("raw_data", $"{Constants.FileNamePrefix}randomizer.txt");
            File.WriteAllText(rawDataFileName, randomizerList.ToString());
            rawDataFileName = Path.Combine("raw_data", $"{Constants.FileNamePrefix}legendaryBuff.txt");
            File.WriteAllText(rawDataFileName, legendaryBuffList.ToString());
            rawDataFileName = Path.Combine("raw_data", $"{Constants.FileNamePrefix}legendaryNerf.txt");
            File.WriteAllText(rawDataFileName, legendaryNerfList.ToString());
            rawDataFileName = Path.Combine("raw_data", $"{Constants.FileNamePrefix}legendaryBuffAppliedModifiersList.txt");
            File.WriteAllText(rawDataFileName, legendaryBuffAppliedModifiersList.ToString());
            rawDataFileName = Path.Combine("raw_data", $"{Constants.FileNamePrefix}legendaryNerfAppliedModifiersList.txt");
            File.WriteAllText(rawDataFileName, legendaryNerfAppliedModifiersList.ToString());
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
