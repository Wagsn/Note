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
    public partial class EditForm : Form
    {
        private ILogger Logger { get; } = LoggerManager.Get<EditForm>();
        public EditForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Logger.Log($"[{nameof(SaveButton_Click)}] {sender} {e} Click!");
            // TODO 数据操作
            var title = TitieEdit.Text;
            var content = ContentEdit.Text;

            Logger.Log($"[{nameof(SaveButton_Click)}] Titile: '{title}', Content: '{content}'");
            using(var context = new NoteWinCore.Stores.AppDbContext())
            {
                var note = new NoteCore.Entitys.Note
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = title,
                    Content = content,
                    CreateTime = DateTime.Now,
                };
                context.Add(note);
                var ws = context.Users.Where(a => a.Email.Contains("wagsn@foxmail.com")).FirstOrDefault();
                context.NoteUserRelations.Add(new NoteCore.Entitys.NoteUserRelation
                {
                    UserId = ws.Id,
                    NoteId = note.Id
                });
                context.SaveChanges();
            }

            this.Close();
        }
    }
}
