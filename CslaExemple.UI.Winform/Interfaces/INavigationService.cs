using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.UI.Winform
{
    public interface INavigationService
    {
        void OpenResourceDetail(int id, Action afterClose = null);
        void CreateResource(Action afterClose = null);
    }
}
