/* Daniel Brenes
 * Lab 5 ITSE 1430
 * Character Creator
 * Main Form
 * 12/11/2020
 */
using CharacterCreator.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();

            Character character;
            character = new Character();

            _miFileExit.Click += OnExit;
            _miHelpAbout.Click += OnHelpAbout;
            _miCharacterNew.Click += OnCharacterNew;
            _miCharacterEdit.Click += OnCharacterEdit;
            _miCharacterDelete.Click += OnCharacterDelete;
        }
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            RefreshRoster();
        }
        private ICharacterDatabase _characters = new MemoryCharacterDatabase();
        //private const string _connectionString = @"
        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            switch (MessageBox.Show(this, $"Are you sure you want to delete '{character.Name}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No: return;

            }

            
            DeleteCharacter(character.Id);
            RefreshRoster();

        }
        private void AddCharacter ( Character character )
        {

            var newCharacter = _characters.Add(character, out var message);
            if (newCharacter == null)
            {
                MessageBox.Show(this, message, "Add Failed", MessageBoxButtons.OK);
                return;
            }
            RefreshRoster();
        }
        private void DeleteCharacter ( int id )
        {
            _characters.Delete(id);
        }      
        private Character GetSelectedCharacter ()
        {
            return _lbRoster.SelectedItem as Character;

        }
        private void RefreshRoster ()
        {
            //_lbRoster.DataSource = null;
            _lbRoster.DataSource = _characters.GetAll().ToArray();
           // _lbRoster.DisplayMember = nameof(Character.Name);
        }
        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var form = new CharacterForm();

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                return;

            //_characters = form.Character;
            AddCharacter(form.Character);

            MessageBox.Show("Save successful");

            // RefreshRoster();            
        }
        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var form = new CharacterForm(character, "Edit Character");            

            var result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
         
            EditCharacter(character.Id, form.Character);
        }
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox1();
            about.ShowDialog(this);
        }
        private void OnExit ( object sender, EventArgs e )
        {
            Close();
        }
        private void EditCharacter ( int id, Character character )
        {
            var error = _characters.Update(id, character);
            if (String.IsNullOrEmpty(error))
            {
                RefreshRoster();
                return;
            };
            MessageBox.Show(this, error, "Edit Character", MessageBoxButtons.OK);
        }

    }
}
