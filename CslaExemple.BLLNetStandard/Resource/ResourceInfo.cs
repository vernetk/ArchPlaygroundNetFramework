using Csla;
using CslaExemple.DalNetStandard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.BLLNetStandard
{
    [Serializable()]
    public class ResourceInfo : ReadOnlyBase<ResourceInfo>
    {
        #region Business Properties
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty); }
            private set { LoadProperty(FirstNameProperty, value); }
        }

        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
            private set { LoadProperty(LastNameProperty, value); }
        }

        public static readonly PropertyInfo<string> FullNameProperty = RegisterProperty<string>(c => c.FullName);
        public string FullName
        {
            get { return GetProperty(FullNameProperty); }
            private set { LoadProperty(FullNameProperty, value); }
        }
        #endregion Business Properties

        public override string ToString()
        {
            return FullName;
        }

        #region Factory

        public static async Task<ResourceInfo> GetItemAsync(int id)
        {
            return await DataPortal.FetchAsync<ResourceInfo>(id);
        }

        #endregion Factory

        #region DATA - Server

        private void Fetch(ResourceDto item)
        {
            Id = item.Id;
            FirstName = item.FirstName;
            LastName = item.LastName;
            FullName = string.Format("{1}, {0}", item.FirstName, item.LastName);
        }
        [Fetch]
        private void DataPortal_Fetch(int id, IResourceDal dal)
        {
            var item = dal.Fetch(id);
            Fetch(item);
        }

        [FetchChild]
        private void Child_Fetch(ResourceDto item)
        {
            Fetch(item);
        }
        #endregion DATA - Server
    }
}
