/* Daniel Brenes
 * Lab 5 ITSE 1430
 * Character Creator
 * Main Form
 * 12/11/2020
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class CharacterForm : Form
    {
       
        public CharacterForm ()
        {
            InitializeComponent();
        }
        public CharacterForm ( Character character) : this(character, null)
        {            
        }
        
        public CharacterForm ( Character character, string title ) : this()
        {           

            Character = character;
            Text = title ?? "Add Character";
        }
        public Character Character { get; set; }
        protected override void OnLoad ( EventArgs e )
        {
           
            base.OnLoad(e);

            if (Character != null)
            {
                _txtName.Text = Character.Name;
                _comboProfession.SelectedItem = Character.Profession;
                _comboRace.SelectedItem = Character.Race;
                _numStrength.Value = Character.Strength;
                _numIntelligence.Value = Character.Intelligence;
                _numConstitution.Value = Character.Constitution;
                _numAgility.Value = Character.Agility;
                _numCharisma.Value = Character.Charisma;
                _txtDescription.Text = Character.Description;
            };
                       
            ValidateChildren();
        }
       
        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            
                var control = sender as TextBox;

                if (String.IsNullOrEmpty(control.Text))
                {
                    _errors.SetError(control, "Name is required");
                    e.Cancel = true;
                } else
                    _errors.SetError(control, "");
        }

        private void OnValidateProfession ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;
            //var item = _comboProfession.SelectedItem as Character;
            if (control.SelectedItem == null)
            {
                _errors.SetError(control, "Profession is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateRace ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;
            //var item = _comboProfession.SelectedItem as Character;
            if (control.SelectedItem == null)
            {
                _errors.SetError(control, "Race is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnSave ( object sender, EventArgs e )
        {          
            
                if (!ValidateChildren())
                {
                    DialogResult = DialogResult.None;
                    return;
                };

                var button = sender as Button;
                if (button == null)
                    return;

                var character = new Character();

                character.Name = _txtName.Text;           

                character.Profession = (string)_comboProfession.SelectedItem;
                
                character.Race = (string)_comboRace.SelectedItem;

                character.Strength = (int)_numStrength.Value;
                character.Intelligence = (int)_numIntelligence.Value;
                character.Agility = (int)_numAgility.Value;
                character.Constitution = (int)_numConstitution.Value;
                character.Charisma = (int)_numCharisma.Value;
                character.Description = _txtDescription.Text;
                            
                var validationResults = new ObjectValidator().TryValidateFullObject(character); 
                
            if (validationResults.Count() > 0)
            {
                var builder = new System.Text.StringBuilder();
                foreach (var result in validationResults)
                {
                    builder.AppendLine(result.ErrorMessage);
                };
                MessageBox.Show(this, builder.ToString(), "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;

                return;
            }               
                Character = character;                
                Close();
        }
        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }
    }
}
