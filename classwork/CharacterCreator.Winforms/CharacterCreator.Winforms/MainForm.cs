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
        }

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
