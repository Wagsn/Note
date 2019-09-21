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
        private List<NoteCore.Entitys.Note> Notes { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log($"[{nameof(NewMenuItem_Click)}] {sender} {e} Click!");

            EditForm edit = new EditForm();
            edit.ShowDialog();
            //if(edit.DialogResult == DialogResult.OK)
            //{

            //}
            using (var context = new NoteWinCore.Stores.AppDbContext())
            {
                //Notes.Clear();
                //Notes.AddRange(context.Notes.AsNoTracking().ToList());
                //Table.Rows.Clear();
                Table.DataSource = context.Notes.AsNoTracking().ToList();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var context = new NoteWinCore.Stores.AppDbContext())
            {
                Notes = context.Notes.AsNoTracking().ToList();
                Logger.Log($"[{nameof(MainForm_Load)}] {string.Join(", ", Notes.Select(a => $"[Title: {a.Title}, Content: {a.Content}]"))}");

                Table.DataSource = Notes;
            }
        }

        private void Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
