namespace Space_Rush
{
    partial class Settings
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
            this.difficultuComboBox = new System.Windows.Forms.ComboBox();
            this.weaponComboBox = new System.Windows.Forms.ComboBox();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.weaponLabel = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // difficultuComboBox
            // 
            this.difficultuComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultuComboBox.FormattingEnabled = true;
            this.difficultuComboBox.Items.AddRange(new object[] {
            "Легко",
            "Нормально",
            "Сложно"});
            this.difficultuComboBox.Location = new System.Drawing.Point(45, 33);
            this.difficultuComboBox.Name = "difficultuComboBox";
            this.difficultuComboBox.Size = new System.Drawing.Size(121, 21);
            this.difficultuComboBox.TabIndex = 0;
            this.difficultuComboBox.SelectedIndexChanged += new System.EventHandler(this.difficultuComboBox_SelectedIndexChanged);
            // 
            // weaponComboBox
            // 
            this.weaponComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.weaponComboBox.FormattingEnabled = true;
            this.weaponComboBox.Items.AddRange(new object[] {
            "Пулемёт",
            "Дробовик"});
            this.weaponComboBox.Location = new System.Drawing.Point(45, 75);
            this.weaponComboBox.Name = "weaponComboBox";
            this.weaponComboBox.Size = new System.Drawing.Size(121, 21);
            this.weaponComboBox.TabIndex = 1;
            this.weaponComboBox.SelectedIndexChanged += new System.EventHandler(this.weaponComboBox_SelectedIndexChanged);
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Location = new System.Drawing.Point(73, 17);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(63, 13);
            this.difficultyLabel.TabIndex = 2;
            this.difficultyLabel.Text = "Сложность";
            // 
            // weaponLabel
            // 
            this.weaponLabel.AutoSize = true;
            this.weaponLabel.Location = new System.Drawing.Point(73, 59);
            this.weaponLabel.Name = "weaponLabel";
            this.weaponLabel.Size = new System.Drawing.Size(46, 13);
            this.weaponLabel.TabIndex = 3;
            this.weaponLabel.Text = "Оружие";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(61, 102);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 4;
            this.acceptButton.Text = "Принять";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 147);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.weaponLabel);
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.weaponComboBox);
            this.Controls.Add(this.difficultuComboBox);
            this.Name = "Settings";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox difficultuComboBox;
        private System.Windows.Forms.ComboBox weaponComboBox;
        private System.Windows.Forms.Label difficultyLabel;
        private System.Windows.Forms.Label weaponLabel;
        private System.Windows.Forms.Button acceptButton;
    }
}