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
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._characterName = new System.Windows.Forms.Label();
            this._profession = new System.Windows.Forms.Label();
            this._race = new System.Windows.Forms.Label();
            this._comboProfession = new System.Windows.Forms.ComboBox();
            this._comboRace = new System.Windows.Forms.ComboBox();
            this._txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._numStrength = new System.Windows.Forms.NumericUpDown();
            this._numIntelligence = new System.Windows.Forms.NumericUpDown();
            this._numConstitution = new System.Windows.Forms.NumericUpDown();
            this._numAgility = new System.Windows.Forms.NumericUpDown();
            this._numCharisma = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._numStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numIntelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numConstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numAgility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numCharisma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(153, 477);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 9;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(240, 477);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(79, 23);
            this._btnCancel.TabIndex = 10;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // _characterName
            // 
            this._characterName.AutoSize = true;
            this._characterName.Location = new System.Drawing.Point(22, 20);
            this._characterName.Name = "_characterName";
            this._characterName.Size = new System.Drawing.Size(93, 15);
            this._characterName.TabIndex = 2;
            this._characterName.Text = "Character Name";
            // 
            // _profession
            // 
            this._profession.AutoSize = true;
            this._profession.Location = new System.Drawing.Point(53, 55);
            this._profession.Name = "_profession";
            this._profession.Size = new System.Drawing.Size(62, 15);
            this._profession.TabIndex = 3;
            this._profession.Text = "Profession";
            // 
            // _race
            // 
            this._race.AutoSize = true;
            this._race.Location = new System.Drawing.Point(76, 90);
            this._race.Name = "_race";
            this._race.Size = new System.Drawing.Size(32, 15);
            this._race.TabIndex = 4;
            this._race.Text = "Race";
            // 
            // _comboProfession
            // 
            this._comboProfession.FormattingEnabled = true;
            this._comboProfession.Items.AddRange(new object[] {
            "Fighter",
            "Hunter",
            "Priest",
            "Rogue",
            "Wizard"});
            this._comboProfession.Location = new System.Drawing.Point(153, 52);
            this._comboProfession.Name = "_comboProfession";
            this._comboProfession.Size = new System.Drawing.Size(124, 23);
            this._comboProfession.TabIndex = 1;
            this._comboProfession.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateProfession);
            // 
            // _comboRace
            // 
            this._comboRace.FormattingEnabled = true;
            this._comboRace.Items.AddRange(new object[] {
            "Dwarf",
            "Elf",
            "Gnome",
            "Half Elf",
            "Human"});
            this._comboRace.Location = new System.Drawing.Point(153, 87);
            this._comboRace.Name = "_comboRace";
            this._comboRace.Size = new System.Drawing.Size(121, 23);
            this._comboRace.TabIndex = 2;
            this._comboRace.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRace);
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(153, 17);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(121, 23);
            this._txtName.TabIndex = 0;
            this._txtName.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateName);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Attributes";
            // 
            // _numStrength
            // 
            this._numStrength.Location = new System.Drawing.Point(153, 159);
            this._numStrength.Name = "_numStrength";
            this._numStrength.Size = new System.Drawing.Size(120, 23);
            this._numStrength.TabIndex = 3;
            // 
            // _numIntelligence
            // 
            this._numIntelligence.Location = new System.Drawing.Point(153, 192);
            this._numIntelligence.Name = "_numIntelligence";
            this._numIntelligence.Size = new System.Drawing.Size(120, 23);
            this._numIntelligence.TabIndex = 4;
            // 
            // _numConstitution
            // 
            this._numConstitution.Location = new System.Drawing.Point(153, 221);
            this._numConstitution.Name = "_numConstitution";
            this._numConstitution.Size = new System.Drawing.Size(120, 23);
            this._numConstitution.TabIndex = 5;
            // 
            // _numAgility
            // 
            this._numAgility.Location = new System.Drawing.Point(153, 250);
            this._numAgility.Name = "_numAgility";
            this._numAgility.Size = new System.Drawing.Size(120, 23);
            this._numAgility.TabIndex = 6;
            // 
            // _numCharisma
            // 
            this._numCharisma.Location = new System.Drawing.Point(153, 279);
            this._numCharisma.Name = "_numCharisma";
            this._numCharisma.Size = new System.Drawing.Size(120, 23);
            this._numCharisma.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Strength";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Intelligence";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Constitution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Charisma";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Agility";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Description (optional)";
            // 
            // _txtDescription
            // 
            this._txtDescription.Location = new System.Drawing.Point(153, 332);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(166, 90);
            this._txtDescription.TabIndex = 8;
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
            this.ClientSize = new System.Drawing.Size(342, 514);
            this.ControlBox = false;
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._numCharisma);
            this.Controls.Add(this._numAgility);
            this.Controls.Add(this._numConstitution);
            this.Controls.Add(this._numIntelligence);
            this.Controls.Add(this._numStrength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this._comboRace);
            this.Controls.Add(this._comboProfession);
            this.Controls.Add(this._race);
            this.Controls.Add(this._profession);
            this.Controls.Add(this._characterName);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 553);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(358, 553);
            this.Name = "CharacterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            ((System.ComponentModel.ISupportInitialize)(this._numStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numIntelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numConstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numAgility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numCharisma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label _characterName;
        private System.Windows.Forms.Label _profession;
        private System.Windows.Forms.Label _race;
        private System.Windows.Forms.ComboBox _comboProfession;
        private System.Windows.Forms.ComboBox _comboRace;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _numStrength;
        private System.Windows.Forms.NumericUpDown _numIntelligence;
        private System.Windows.Forms.NumericUpDown _numConstitution;
        private System.Windows.Forms.NumericUpDown _numAgility;
        private System.Windows.Forms.NumericUpDown _numCharisma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.ErrorProvider _errors;
    }
}