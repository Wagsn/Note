using Microsoft.EntityFrameworkCore;
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

            EditForm edit = new EditForm();
            edit.ShowDialog();
            using (var context = new NoteWinCore.Stores.AppDbContext())
            {
                var notes = context.Notes.AsNoTracking().ToList();
                Logger.Log($"[{nameof(Note_Add_Click)}] {string.Join(", ", notes.Select(a => $"[Title: {a.Title}, Content: {a.Content}]"))}");
            }
        }
    }
}
