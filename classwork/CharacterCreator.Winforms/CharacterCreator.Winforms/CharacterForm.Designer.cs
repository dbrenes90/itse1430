namespace CharacterCreator.Winforms
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Profession = new System.Windows.Forms.Label();
            this.Race = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._comboProfession = new System.Windows.Forms.ComboBox();
            this._comboRace = new System.Windows.Forms.ComboBox();
            this._numStrength = new System.Windows.Forms.NumericUpDown();
            this._numIntelligence = new System.Windows.Forms.NumericUpDown();
            this._numAgility = new System.Windows.Forms.NumericUpDown();
            this._numCharisma = new System.Windows.Forms.NumericUpDown();
            this._numConstitution = new System.Windows.Forms.NumericUpDown();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this.Strength = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._numStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numIntelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numAgility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numCharisma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numConstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // Profession
            // 
            this.Profession.AutoSize = true;
            this.Profession.Location = new System.Drawing.Point(14, 74);
            this.Profession.Name = "Profession";
            this.Profession.Size = new System.Drawing.Size(62, 15);
            this.Profession.TabIndex = 1;
            this.Profession.Text = "Profession";
            // 
            // Race
            // 
            this.Race.AutoSize = true;
            this.Race.Location = new System.Drawing.Point(44, 121);
            this.Race.Name = "Race";
            this.Race.Size = new System.Drawing.Size(32, 15);
            this.Race.TabIndex = 2;
            this.Race.Text = "Race";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Attributes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Description";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(94, 32);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(121, 23);
            this._txtName.TabIndex = 0;
            this._txtName.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateName);
            // 
            // _comboProfession
            // 
            this._comboProfession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboProfession.FormattingEnabled = true;
            this._comboProfession.Items.AddRange(new object[] {
            "Fighter",
            "Hunter",
            "Priest",
            "Rogue",
            "Wizard"});
            this._comboProfession.Location = new System.Drawing.Point(94, 71);
            this._comboProfession.Name = "_comboProfession";
            this._comboProfession.Size = new System.Drawing.Size(121, 23);
            this._comboProfession.TabIndex = 1;
            this._comboProfession.Tag = "SelectedItem";
            this._comboProfession.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateProfession);
            // 
            // _comboRace
            // 
            this._comboRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboRace.FormattingEnabled = true;
            this._comboRace.Items.AddRange(new object[] {
            "Dwarf",
            "Elf",
            "Gnome",
            "Half Elf",
            "Human"});
            this._comboRace.Location = new System.Drawing.Point(94, 118);
            this._comboRace.Name = "_comboRace";
            this._comboRace.Size = new System.Drawing.Size(121, 23);
            this._comboRace.TabIndex = 2;
            this._comboRace.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRace);
            // 
            // _numStrength
            // 
            this._numStrength.Location = new System.Drawing.Point(94, 169);
            this._numStrength.Name = "_numStrength";
            this._numStrength.Size = new System.Drawing.Size(120, 23);
            this._numStrength.TabIndex = 3;
            // 
            // _numIntelligence
            // 
            this._numIntelligence.Location = new System.Drawing.Point(94, 196);
            this._numIntelligence.Name = "_numIntelligence";
            this._numIntelligence.Size = new System.Drawing.Size(120, 23);
            this._numIntelligence.TabIndex = 4;
            // 
            // _numAgility
            // 
            this._numAgility.Location = new System.Drawing.Point(94, 225);
            this._numAgility.Name = "_numAgility";
            this._numAgility.Size = new System.Drawing.Size(120, 23);
            this._numAgility.TabIndex = 5;
            // 
            // _numCharisma
            // 
            this._numCharisma.Location = new System.Drawing.Point(94, 283);
            this._numCharisma.Name = "_numCharisma";
            this._numCharisma.Size = new System.Drawing.Size(120, 23);
            this._numCharisma.TabIndex = 7;
            // 
            // _numConstitution
            // 
            this._numConstitution.Location = new System.Drawing.Point(94, 254);
            this._numConstitution.Name = "_numConstitution";
            this._numConstitution.Size = new System.Drawing.Size(120, 23);
            this._numConstitution.TabIndex = 6;
            // 
            // _txtDescription
            // 
            this._txtDescription.Location = new System.Drawing.Point(94, 320);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(167, 80);
            this._txtDescription.TabIndex = 8;
            // 
            // Strength
            // 
            this.Strength.AutoSize = true;
            this.Strength.Location = new System.Drawing.Point(24, 171);
            this.Strength.Name = "Strength";
            this.Strength.Size = new System.Drawing.Size(52, 15);
            this.Strength.TabIndex = 14;
            this.Strength.Text = "Strength";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Intelligence";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Agility";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Constitution";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Charisma";
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(109, 437);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 9;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Validating += new System.ComponentModel.CancelEventHandler(this.OnSave);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(190, 437);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 10;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Validating += new System.ComponentModel.CancelEventHandler(this.OnCancel);
            // 
            // _errors
            // 
            this._errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errors.ContainerControl = this;
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(280, 472);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Strength);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._numConstitution);
            this.Controls.Add(this._numCharisma);
            this.Controls.Add(this._numAgility);
            this.Controls.Add(this._numIntelligence);
            this.Controls.Add(this._numStrength);
            this.Controls.Add(this._comboRace);
            this.Controls.Add(this._comboProfession);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Race);
            this.Controls.Add(this.Profession);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(296, 511);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(296, 511);
            this.Name = "CharacterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            ((System.ComponentModel.ISupportInitialize)(this._numStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numIntelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numAgility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numCharisma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numConstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Profession;
        private System.Windows.Forms.Label Race;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.ComboBox _comboProfession;
        private System.Windows.Forms.ComboBox _comboRace;
        private System.Windows.Forms.NumericUpDown _numStrength;
        private System.Windows.Forms.NumericUpDown _numIntelligence;
        private System.Windows.Forms.NumericUpDown _numAgility;
        private System.Windows.Forms.NumericUpDown _numCharisma;
        private System.Windows.Forms.NumericUpDown _numConstitution;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.Label Strength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.ErrorProvider _errors;
    }
}