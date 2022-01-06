namespace ModifierCreator
{
    partial class ModifierConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.modifierName_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tier1Amount_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tier3Amount_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.tier2Amount_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // modifierName_txt
            // 
            this.modifierName_txt.Location = new System.Drawing.Point(66, 12);
            this.modifierName_txt.Name = "modifierName_txt";
            this.modifierName_txt.ReadOnly = true;
            this.modifierName_txt.Size = new System.Drawing.Size(722, 20);
            this.modifierName_txt.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Modifier:";
            // 
            // tier1Amount_txt
            // 
            this.tier1Amount_txt.Location = new System.Drawing.Point(97, 38);
            this.tier1Amount_txt.Name = "tier1Amount_txt";
            this.tier1Amount_txt.Size = new System.Drawing.Size(691, 20);
            this.tier1Amount_txt.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tier 1 Amount:";
            // 
            // tier3Amount_txt
            // 
            this.tier3Amount_txt.Location = new System.Drawing.Point(97, 90);
            this.tier3Amount_txt.Name = "tier3Amount_txt";
            this.tier3Amount_txt.Size = new System.Drawing.Size(691, 20);
            this.tier3Amount_txt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tier 3 Amount:";
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(439, 116);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 3;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(277, 116);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // tier2Amount_txt
            // 
            this.tier2Amount_txt.Location = new System.Drawing.Point(97, 64);
            this.tier2Amount_txt.Name = "tier2Amount_txt";
            this.tier2Amount_txt.Size = new System.Drawing.Size(691, 20);
            this.tier2Amount_txt.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tier 2 Amount:";
            // 
            // ModifierConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 151);
            this.Controls.Add(this.tier2Amount_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.tier3Amount_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tier1Amount_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modifierName_txt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ModifierConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModifierConfig";
            this.Load += new System.EventHandler(this.ModifierConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox modifierName_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tier1Amount_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tier3Amount_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox tier2Amount_txt;
        private System.Windows.Forms.Label label4;
    }
}