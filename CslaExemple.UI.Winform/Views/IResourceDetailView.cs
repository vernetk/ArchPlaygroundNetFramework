using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.UI.Winform
{
    public interface IResourceDetailView
    {
        ResourceDetailViewModel ViewModel { get; }

        event EventHandler SaveRequested;
        void SetMode(FormMode mode);
        void Close();
        //void ShowMessage(string msg);
        //void ShowError(string msg);

        void SetError(string propertyName, string message);
        void ClearErrors();
        void SetSaveButtonEnabled(bool enabled);
    }
}
