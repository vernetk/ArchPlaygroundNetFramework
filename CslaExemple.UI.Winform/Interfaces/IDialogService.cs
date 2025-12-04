using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.UI.Winform
{
    public interface IDialogService
    {
        void Info(string message);
        void Error(string message);
        bool Confirm(string message);
    }
}
