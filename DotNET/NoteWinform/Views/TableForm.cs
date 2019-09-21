using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WS.Log;

namespace NoteWinform.Views
{
    public partial class TableForm : Form
    {
        private ILogger Logger { get; } = LoggerManager.Get<TableForm>();

        private List<NoteCore.Entitys.Note> Notes { get; set; }

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

        private void TableForm_Load(object sender, EventArgs e)
        {
            using (var context = new NoteWinCore.Stores.AppDbContext())
            {
                Notes = context.Notes.AsNoTracking().ToList();
                Logger.Log($"[{nameof(TableForm_Load)}] {string.Join(", ", Notes.Select(a => $"[Title: {a.Title}, Content: {a.Content}]"))}");

                Table.DataSource = Notes;
            }
        }
    }
}
