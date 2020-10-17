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
        public MainForm()
        {
            InitializeComponent();

            Character character;
            character = new Character();

            _miFileExit.Click += OnExit;
            _miHelpAbout.Click += OnHelpAbout;
            _miCharacterNew.Click += OnCharacterNew;
            _miCharacterEdit.Click += OnCharacterEdit;
        }
        private Character _character;
       //rivate CharacterDatabase _characters = new CharacterDatabase();

        private void RefreshRoster ()
        {
            //ASSUMPTION: Character is the type that represents a character, change to match your code
            var roster = new BindingList<Character>();

            //ASSUMPTION: _character is the field where the single character is stored, change to match your code
            roster.Add(_character);

            //ASSUMPTION: Control is called _lbRoster for ListBox
         //_lbRoster.DataSource = roster;

            //ASSUMPTION: Property on Character to display is called Name, change to match your code
         //_lbRoster.DisplayName = "Name";
        }
        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var form = new CharacterForm();

            
            var result = form.ShowDialog(this); //Blocks until form is dismissed/
            if (result == DialogResult.Cancel)
                return;

           _character = form.Character;

            MessageBox.Show("Save successful");


        }
        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            //OBject creation
            // 1. Allocate memory for instance, zero initialized
            // 2. Initialize fields 
            // 3. Constructor (finish initialization)
            // 4. Return new instance
            var form = new CharacterForm(_character, "Edit Character");
            //form.Movie = _movie;

            var result = form.ShowDialog(this); //Blocks until form is dismissed
            if (result == DialogResult.Cancel)
                return;

            // TODO: Update movie
            _character = form.Character;

            MessageBox.Show("Save successful");


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

    }

}
