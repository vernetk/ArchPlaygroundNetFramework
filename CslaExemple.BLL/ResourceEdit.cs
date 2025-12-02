using Csla;
using Csla.Security;
using CslaExemple.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.BLL
{
    [Serializable()]
    public class ResourceEdit : Csla.BusinessBase<ResourceEdit>
    {
        public static readonly PropertyInfo<byte[]> TimeStampProperty = RegisterProperty<byte[]>(c => c.TimeStamp);
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] TimeStamp
        {
            get { return GetProperty(TimeStampProperty); }
            set { SetProperty(TimeStampProperty, value); }
        }

        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        [Display(Name = "Resource id")]
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> LastNameProperty =
          RegisterProperty<string>(c => c.LastName);
        [Display(Name = "Last name")]
        [Required]
        [StringLength(50)]
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
            set { SetProperty(LastNameProperty, value); }
        }

        public static readonly PropertyInfo<string> FirstNameProperty =
          RegisterProperty<string>(c => c.FirstName);
        [Display(Name = "First name")]
        [Required]
        [StringLength(50)]
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty); }
            set { SetProperty(FirstNameProperty, value); }
        }

        [Display(Name = "Full name")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [ObjectAuthorizationRules]
        public static void AddObjectAuthorizationRules()
        {
        }

        #region Factory

        #endregion Factory
        public static async Task<ResourceEdit> NewResourceEditAsync()
        {
            return await DataPortal.CreateAsync<ResourceEdit>();
        }

        public static async Task<ResourceEdit> GetResourceEditAsync(int id)
        {
            return await DataPortal.FetchAsync<ResourceEdit>(id);
        }

        public static async Task DeleteResourceEditAsync(int id)
        {
            await DataPortal.DeleteAsync<ResourceEdit>(id);
        }

        [RunLocal]
        [Create]
        private void Create()
        {
            BusinessRules.CheckRules();
        }

        [Fetch]
        private void Fetch(int id, [Inject] IResourceDal dal)
        {
            var data = dal.Fetch(id);
            using (BypassPropertyChecks)
            {
                Id = data.Id;
                FirstName = data.FirstName;
                LastName = data.LastName;
                TimeStamp = data.LastChanged;
            }
        }

        [Insert]
        private async Task Insert([Inject] IResourceDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new ResourceDto
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName
                };
                dal.Insert(item);
                Id = item.Id;
                TimeStamp = item.LastChanged;
            }
            FieldManager.UpdateChildren(this);
        }

        [Update]
        private async Task Update([Inject] IResourceDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new ResourceDto
                {
                    Id = this.Id,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    LastChanged = this.TimeStamp
                };
                dal.Update(item);
                TimeStamp = item.LastChanged;
            }
            FieldManager.UpdateChildren(this);
        }

        [DeleteSelf]
        private void DeleteSelf([Inject] IResourceDal dal)
        {
            using (BypassPropertyChecks)
            {
                FieldManager.UpdateChildren(this);
                Delete(this.Id, dal);
            }
        }

        [Delete]
        private void Delete(int id, [Inject] IResourceDal dal)
        {
            dal.Delete(id);
        }
    }
}
