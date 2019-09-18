using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WS.Log;

namespace NoteWinform.Views
{
    public partial class MainForm : Form
    {
        private ILogger Logger { get; } = LoggerManager.Get<MainForm>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Note_Add_Click(object sender, EventArgs e)
        {
            Logger.Log($"[{nameof(Note_Add_Click)}] {sender} {e} Click!");

            
        }
    }
}
