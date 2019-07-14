using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWinCore.Mvvm
{
    /// <summary>
    /// 视图模型（用于模型视图交互，包含验证，相当于Presenter）
    /// </summary>
    public interface IViewModel
    {
        IModel Model { get; set; }
        IView View { get; set; }
        void OnCleared();
        void Save();
        void Load();
        void Show();
        void Refreah();
        void Close();
    }
}
