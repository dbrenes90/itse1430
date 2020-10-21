﻿using System;
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

        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }

        public Character Character { get; set; }

        private void OnSave ( object sender, EventArgs e )
        {
                if (!ValidateChildren())
                {
                    DialogResult = DialogResult.None;
                    return;
                }
              
                var button = sender as Button;
                if (button == null)
                    return;

                var character = new Character();
                character.Name = _txtName.Text;
                character.Profession = _comboProfession.SelectedText;
                character.Race = _comboRace.SelectedText;
                character.Strength = (int)_numStrength.Value;
                character.Intelligence = (int)_numIntelligence.Value;
                character.Agility = (int)_numAgility.Value;
                character.Constitution = (int)_numConstitution.Value;
                character.Charisma = (int)_numCharisma.Value;
                character.Description = _txtDescription.Text;

                var error = character.Validate();
                if (!String.IsNullOrEmpty(error))
                {
                    //Show error message - use for standard messages
                    MessageBox.Show(this, error, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    Close();
                    return;
                }

                Character = character;
                Close();
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

            if (control.SelectedItem == null)
            {
                _errors.SetError(control, "Race is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
    }

   }
