using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.Core.Interfaces
{
    public interface IDialogService
    {
        void Info(string message);
        void Error(string message);
        bool Confirm(string message);
    }
}
