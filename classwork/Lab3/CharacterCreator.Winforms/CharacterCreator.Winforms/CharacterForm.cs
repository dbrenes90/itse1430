/* Daniel Brenes
 * Lab 3 ITSE 1430
 * Character Creator
 * Character Database
 * 10/30/2020
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            //Movie = movie; 
        }

        //Constructor chaining - calling one constructor from another
        public CharacterForm ( Character character, string title ) : this()
        {
            //InitializeComponent();

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
                _comboProfession.SelectedText = Character.Profession;
                _comboRace.SelectedText = Character.Race;
                _numStrength.Value = Character.Strength;
                _numIntelligence.Value = Character.Intelligence;
                _numConstitution.Value = Character.Constitution;
                _numAgility.Value = Character.Agility;
                _numCharisma.Value = Character.Charisma;
                _txtDescription.Text = Character.Description;
            };

            // Go ahead and show validation errors
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

                var item = _comboProfession.SelectedItem as Character;
             
                character.Profession = (string)_comboProfession.SelectedItem;
                var race = _comboRace.SelectedItem as Character;
                //if (race != null)
                  //  character.Race = race.ToString();
                character.Race = (string)_comboRace.SelectedItem;
                character.Strength = (int)_numStrength.Value;
                character.Intelligence = (int)_numIntelligence.Value;
                character.Agility = (int)_numAgility.Value;
                character.Constitution = (int)_numConstitution.Value;
                character.Charisma = (int)_numCharisma.Value;
                character.Description = _txtDescription.Text;

                //MessageBox.Show(this, Character.Profession);
                var error = character.Validate(); // Code runs to this when set to breakpoint. How to save form to List Array?
               // if (!String.IsNullOrEmpty(error))
               // {
                    //Show error message - use for standard messages
                  //  MessageBox.Show(this, error, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 //   DialogResult = DialogResult.None;
                  //  Close();
                  //  return;
              //  }

                Character = character;
                
                Close();
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }
    }
}
