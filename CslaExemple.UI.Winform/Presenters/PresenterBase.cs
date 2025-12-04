using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.UI.Winform
{
    public abstract class PresenterBase
    {
        protected readonly IDialogService _dialog;

        public PresenterBase(IDialogService dialog)
        {
            _dialog = dialog;
        }

        protected void ShowError(string msg)
        {
            _dialog.Error(msg);
        }

        protected void ShowInfo(string msg)
        {
            _dialog.Info(msg);
        }
    }
}
