using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteWinform.Views
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        private void Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("sender: "+sender+", args: "+e);
        }

        private void Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("sender: " + sender + ", args: " + e);
            var gridView = sender as DataGridView;
            //Console.WriteLine("Text: "+gridView.Get);
        }
    }
}
