namespace ModifierCreator
{
    partial class MainForm
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
            this.generateModifierFiles_btn = new System.Windows.Forms.Button();
            this.createNewModifier_btn = new System.Windows.Forms.Button();
            this.editModifier_btn = new System.Windows.Forms.Button();
            this.deleteModifier_btn = new System.Windows.Forms.Button();
            this.modifierList_lst = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.autoSave_cxb = new System.Windows.Forms.CheckBox();
            this.keepOnTop_cxb = new System.Windows.Forms.CheckBox();
            this.version_txt = new System.Windows.Forms.Label();
            this.modifiersCount_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generateModifierFiles_btn
            // 
            this.generateModifierFiles_btn.Location = new System.Drawing.Point(302, 450);
            this.generateModifierFiles_btn.Name = "generateModifierFiles_btn";
            this.generateModifierFiles_btn.Size = new System.Drawing.Size(139, 23);
            this.generateModifierFiles_btn.TabIndex = 5;
            this.generateModifierFiles_btn.Text = "Generate Modifier Files";
            this.generateModifierFiles_btn.UseVisualStyleBackColor = true;
            this.generateModifierFiles_btn.Click += new System.EventHandler(this.generateModifierFiles_btn_Click);
            // 
            // createNewModifier_btn
            // 
            this.createNewModifier_btn.Location = new System.Drawing.Point(12, 397);
            this.createNewModifier_btn.Name = "createNewModifier_btn";
            this.createNewModifier_btn.Size = new System.Drawing.Size(139, 23);
            this.createNewModifier_btn.TabIndex = 0;
            this.createNewModifier_btn.Text = "Create New Modifier";
            this.createNewModifier_btn.UseVisualStyleBackColor = true;
            this.createNewModifier_btn.Click += new System.EventHandler(this.createNewModifier_btn_Click);
            // 
            // editModifier_btn
            // 
            this.editModifier_btn.Location = new System.Drawing.Point(157, 397);
            this.editModifier_btn.Name = "editModifier_btn";
            this.editModifier_btn.Size = new System.Drawing.Size(139, 23);
            this.editModifier_btn.TabIndex = 1;
            this.editModifier_btn.Text = "Edit Modifier";
            this.editModifier_btn.UseVisualStyleBackColor = true;
            this.editModifier_btn.Click += new System.EventHandler(this.editModifier_btn_Click);
            // 
            // deleteModifier_btn
            // 
            this.deleteModifier_btn.Location = new System.Drawing.Point(302, 397);
            this.deleteModifier_btn.Name = "deleteModifier_btn";
            this.deleteModifier_btn.Size = new System.Drawing.Size(139, 23);
            this.deleteModifier_btn.TabIndex = 2;
            this.deleteModifier_btn.Text = "Delete Modifier";
            this.deleteModifier_btn.UseVisualStyleBackColor = true;
            this.deleteModifier_btn.Click += new System.EventHandler(this.deleteModifier_btn_Click);
            // 
            // modifierList_lst
            // 
            this.modifierList_lst.FormattingEnabled = true;
            this.modifierList_lst.Location = new System.Drawing.Point(12, 13);
            this.modifierList_lst.Name = "modifierList_lst";
            this.modifierList_lst.Size = new System.Drawing.Size(429, 381);
            this.modifierList_lst.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Load Config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 450);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save Config";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // autoSave_cxb
            // 
            this.autoSave_cxb.AutoSize = true;
            this.autoSave_cxb.Location = new System.Drawing.Point(13, 427);
            this.autoSave_cxb.Name = "autoSave_cxb";
            this.autoSave_cxb.Size = new System.Drawing.Size(73, 17);
            this.autoSave_cxb.TabIndex = 7;
            this.autoSave_cxb.Text = "AutoSave";
            this.autoSave_cxb.UseVisualStyleBackColor = true;
            // 
            // keepOnTop_cxb
            // 
            this.keepOnTop_cxb.AutoSize = true;
            this.keepOnTop_cxb.Location = new System.Drawing.Point(157, 427);
            this.keepOnTop_cxb.Name = "keepOnTop_cxb";
            this.keepOnTop_cxb.Size = new System.Drawing.Size(90, 17);
            this.keepOnTop_cxb.TabIndex = 8;
            this.keepOnTop_cxb.Text = "Keep On Top";
            this.keepOnTop_cxb.UseVisualStyleBackColor = true;
            this.keepOnTop_cxb.CheckedChanged += new System.EventHandler(this.keepOnTop_cxb_CheckedChanged);
            // 
            // version_txt
            // 
            this.version_txt.AutoSize = true;
            this.version_txt.Location = new System.Drawing.Point(10, 479);
            this.version_txt.Name = "version_txt";
            this.version_txt.Size = new System.Drawing.Size(48, 13);
            this.version_txt.TabIndex = 9;
            this.version_txt.Text = "Version: ";
            this.version_txt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // modifiersCount_txt
            // 
            this.modifiersCount_txt.AutoSize = true;
            this.modifiersCount_txt.Location = new System.Drawing.Point(344, 427);
            this.modifiersCount_txt.Name = "modifiersCount_txt";
            this.modifiersCount_txt.Size = new System.Drawing.Size(52, 13);
            this.modifiersCount_txt.TabIndex = 10;
            this.modifiersCount_txt.Text = "Modifiers:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 501);
            this.Controls.Add(this.modifiersCount_txt);
            this.Controls.Add(this.version_txt);
            this.Controls.Add(this.keepOnTop_cxb);
            this.Controls.Add(this.autoSave_cxb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.modifierList_lst);
            this.Controls.Add(this.deleteModifier_btn);
            this.Controls.Add(this.editModifier_btn);
            this.Controls.Add(this.createNewModifier_btn);
            this.Controls.Add(this.generateModifierFiles_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Modifier Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateModifierFiles_btn;
        private System.Windows.Forms.Button createNewModifier_btn;
        private System.Windows.Forms.Button editModifier_btn;
        private System.Windows.Forms.Button deleteModifier_btn;
        private System.Windows.Forms.ListBox modifierList_lst;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox autoSave_cxb;
        private System.Windows.Forms.CheckBox keepOnTop_cxb;
        private System.Windows.Forms.Label version_txt;
        private System.Windows.Forms.Label modifiersCount_txt;
    }
}

