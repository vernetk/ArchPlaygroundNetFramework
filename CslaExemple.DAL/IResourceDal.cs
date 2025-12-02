using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.DAL
{
    public interface IResourceDal
    {
        ResourceDto Fetch(int id);
        List<ResourceDto> FetchList();
        /**/
        bool Exists(int id);
        /**/
        void Insert(ResourceDto item);
        void Update(ResourceDto item);
        void Delete(int id);
    }
}
