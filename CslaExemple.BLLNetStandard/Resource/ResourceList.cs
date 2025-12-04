using Csla;
using CslaExemple.DalNetStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.BLLNetStandard
{
    [Serializable()]
    public class ResourceList : ReadOnlyListBase<ResourceList, ResourceInfo>
    {
        public void RemoveChild(int resourceId)
        {
            var iro = IsReadOnly;
            IsReadOnly = false;
            try
            {
                var item = this.Where(r => r.Id == resourceId).FirstOrDefault();
                if (item != null)
                {
                    var index = this.IndexOf(item);
                    Remove(item);
                }
            }
            finally
            {
                IsReadOnly = iro;
            }
        }

        public static ResourceList GetEmptyList()
        {
            return DataPortal.Create<ResourceList>();
        }

        public static async Task<ResourceList> GetResourceListAsync()
        {
            return await DataPortal.FetchAsync<ResourceList>();
        }

        public static ResourceList GetResourceList()
        {
            return DataPortal.Fetch<ResourceList>();
        }

        [Create]
        [RunLocal]
        private void Create()
        { }

        [Fetch]
        private void Fetch([Inject] IResourceDal dal)
        {
            using (LoadListMode)
            {
                List<ResourceDto> list = null;
                list = dal.FetchList();
                foreach (var item in list)
                    Add(DataPortal.FetchChild<ResourceInfo>(item));
            }
        }
    }
}
