namespace ModifierCreator
{
    partial class CreateOrEditModifier
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
            this.label1 = new System.Windows.Forms.Label();
            this.modifierName_txt = new System.Windows.Forms.TextBox();
            this.fileName_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gameModifiers_lst = new System.Windows.Forms.ListBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.edit_btn = new System.Windows.Forms.Button();
            this.addedModifiers_lst = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.manualInput_txt = new System.Windows.Forms.TextBox();
            this.choosenCount_txt = new System.Windows.Forms.Label();
            this.availableCount_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Modifier Name:";
            // 
            // modifierName_txt
            // 
            this.modifierName_txt.Location = new System.Drawing.Point(97, 10);
            this.modifierName_txt.Name = "modifierName_txt";
            this.modifierName_txt.Size = new System.Drawing.Size(691, 20);
            this.modifierName_txt.TabIndex = 0;
            this.modifierName_txt.TextChanged += new System.EventHandler(this.modifierName_txt_TextChanged);
            // 
            // fileName_txt
            // 
            this.fileName_txt.Location = new System.Drawing.Point(97, 36);
            this.fileName_txt.Name = "fileName_txt";
            this.fileName_txt.ReadOnly = true;
            this.fileName_txt.Size = new System.Drawing.Size(691, 20);
            this.fileName_txt.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "File Name:";
            // 
            // gameModifiers_lst
            // 
            this.gameModifiers_lst.FormattingEnabled = true;
            this.gameModifiers_lst.Location = new System.Drawing.Point(16, 110);
            this.gameModifiers_lst.Name = "gameModifiers_lst";
            this.gameModifiers_lst.Size = new System.Drawing.Size(348, 121);
            this.gameModifiers_lst.TabIndex = 1;
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(370, 84);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(75, 23);
            this.add_btn.TabIndex = 2;
            this.add_btn.Text = "Add";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(370, 142);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(75, 23);
            this.delete_btn.TabIndex = 5;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // edit_btn
            // 
            this.edit_btn.Location = new System.Drawing.Point(370, 113);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(75, 23);
            this.edit_btn.TabIndex = 4;
            this.edit_btn.Text = "Edit";
            this.edit_btn.UseVisualStyleBackColor = true;
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click);
            // 
            // addedModifiers_lst
            // 
            this.addedModifiers_lst.FormattingEnabled = true;
            this.addedModifiers_lst.Location = new System.Drawing.Point(451, 84);
            this.addedModifiers_lst.Name = "addedModifiers_lst";
            this.addedModifiers_lst.Size = new System.Drawing.Size(337, 147);
            this.addedModifiers_lst.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Modifiers";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(289, 262);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 7;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(451, 262);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 6;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // manualInput_txt
            // 
            this.manualInput_txt.Location = new System.Drawing.Point(16, 84);
            this.manualInput_txt.Name = "manualInput_txt";
            this.manualInput_txt.Size = new System.Drawing.Size(348, 20);
            this.manualInput_txt.TabIndex = 12;
            this.manualInput_txt.TextChanged += new System.EventHandler(this.manualInput_txt_TextChanged);
            // 
            // choosenCount_txt
            // 
            this.choosenCount_txt.AutoSize = true;
            this.choosenCount_txt.Location = new System.Drawing.Point(451, 238);
            this.choosenCount_txt.Name = "choosenCount_txt";
            this.choosenCount_txt.Size = new System.Drawing.Size(97, 13);
            this.choosenCount_txt.TabIndex = 13;
            this.choosenCount_txt.Text = "Selected Modifiers:";
            // 
            // availableCount_txt
            // 
            this.availableCount_txt.AutoSize = true;
            this.availableCount_txt.Location = new System.Drawing.Point(16, 238);
            this.availableCount_txt.Name = "availableCount_txt";
            this.availableCount_txt.Size = new System.Drawing.Size(101, 13);
            this.availableCount_txt.TabIndex = 14;
            this.availableCount_txt.Text = "Available Modifiers: ";
            // 
            // CreateOrEditModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 297);
            this.Controls.Add(this.availableCount_txt);
            this.Controls.Add(this.choosenCount_txt);
            this.Controls.Add(this.manualInput_txt);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addedModifiers_lst);
            this.Controls.Add(this.edit_btn);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.gameModifiers_lst);
            this.Controls.Add(this.fileName_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modifierName_txt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CreateOrEditModifier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateOrEditModifier";
            this.Load += new System.EventHandler(this.CreateOrEditModifier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modifierName_txt;
        private System.Windows.Forms.TextBox fileName_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox gameModifiers_lst;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button edit_btn;
        private System.Windows.Forms.ListBox addedModifiers_lst;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox manualInput_txt;
        private System.Windows.Forms.Label choosenCount_txt;
        private System.Windows.Forms.Label availableCount_txt;
    }
}