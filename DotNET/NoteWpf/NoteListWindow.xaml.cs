using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoteWpf
{
    /// <summary>
    /// NoteListWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NoteListWindow : Window
    {
        BindingList<NoteCore.Entitys.Note> listData = new BindingList<NoteCore.Entitys.Note>();

        public NoteListWindow()
        {
            InitializeComponent();

            this.listView.ItemsSource = listData;

            for(var i =1; i<10; i++)
            {
                this.listData.Add(new NoteCore.Entitys.Note
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = $"第{i}个日记",
                    Content = $"第{i}个日记的正文"
                });
            }

        }
    }
}
