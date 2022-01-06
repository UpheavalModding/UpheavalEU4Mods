using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModifierCreator
{
    public partial class ModifierConfig : Form
    {
        private Modifier _modifier;

        public bool Cancelled = false;

        public ModifierConfig()
        {
            InitializeComponent();
        }

        public void Initialize(Modifier modifier)
        {
            _modifier = modifier;
            modifierName_txt.Text = modifier.Name;
            tier1Amount_txt.Text = modifier.Tier1Amount.ToString();
            tier2Amount_txt.Text = modifier.Tier2Amount.ToString();
            tier3Amount_txt.Text = modifier.Tier3Amount.ToString();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            this.Close();
        }

        public Modifier GetModifier() { return _modifier; }

        private void save_btn_Click(object sender, EventArgs e)
        {
            var tier1 = tier1Amount_txt.Text;
            if (string.IsNullOrWhiteSpace(tier1))
            {
                tier1 = "0";
            }
            var tier2 = tier2Amount_txt.Text;
            if (string.IsNullOrWhiteSpace(tier2))
            {
                tier2 = "0";
            }
            var tier3 = tier3Amount_txt.Text;
            if (string.IsNullOrWhiteSpace(tier3))
            {
                tier3 = "0";
            }

            _modifier.Tier1Amount = decimal.Parse(tier1);
            _modifier.Tier2Amount = decimal.Parse(tier2);
            _modifier.Tier3Amount = decimal.Parse(tier3);
            this.Close();
        }

        private void ModifierConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
