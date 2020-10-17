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
        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var form = new CharacterForm();

            // Can show two different ways
            // ShowDialog - modal :: user must interact with child form, cannot access parent
            // Show - modeless :: multiples windows open and accessible at the same time
            var result = form.ShowDialog(this); //Blocks until form is dismissed/
            if (result == DialogResult.Cancel)
                return;

            // After form is gone
            // TODO: Save movie
            //_movie = form.Movie;

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
