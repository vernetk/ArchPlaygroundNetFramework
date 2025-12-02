using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Csla;
using CslaExemple.DalNetStandard;

namespace RFit.BusinessLibrary
{
    [Serializable]
    public class ResourceExistsByFirstNameAndLastNameCommand : CommandBase<ResourceExistsByFirstNameAndLastNameCommand>
    {
        #region Business Properties

        public readonly static PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
        public string FirstName
        {
            get { return ReadProperty(FirstNameProperty); }
            set { LoadProperty(FirstNameProperty, value); }
        }

        public readonly static PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
        public string LastName
        {
            get { return ReadProperty(LastNameProperty); }
            set { LoadProperty(LastNameProperty, value); }
        }


        public readonly static PropertyInfo<int> ResultProperty = RegisterProperty<int>(c => c.Result);
        public int Result
        {
            get { return ReadProperty(ResultProperty); }
            private set { LoadProperty(ResultProperty, value); }
        }

        #endregion Business Properties

        #region Constructors

        [Create, RunLocal]
        private void Create()
        { }

        [Create, RunLocal]
        private void Create(Criteria criteria)
        {
            FirstName = criteria.FirstName;
            LastName = criteria.LastName;
        }

        #endregion Constructors

        #region Factories

        public static async Task<int> ExecuteAsync(string firstName, string lastName)
        {
            var cmd = await DataPortal.CreateAsync<ResourceExistsByFirstNameAndLastNameCommand>(new Criteria() { FirstName = firstName, LastName = lastName });
            cmd = await DataPortal.ExecuteAsync(cmd);
            return cmd.Result;
        }

        #endregion Factories

        #region Execute       

        [Execute]
        //[Transactional(TransactionalTypes.TransactionScope, TransactionIsolationLevel.Serializable, Config.TransactionalTimeoutInSeconds)]
        protected void DataPortal_Execute([Inject] IResourceDal dal)
        {
            //var claimsPrincipal = Csla.ApplicationContext.User as ClaimsPrincipal;
            //var tenantId = int.Parse((claimsPrincipal.Claims.First(c => c.Type == Config.ClaimTenantType)).Value);

            Result = dal.ExistsByFirstNameAndLastName(FirstName, LastName);
        }

        #endregion Execute

        #region Criteria

        [Serializable]
        public class Criteria : CriteriaBase<Criteria>
        {
            public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
            public string FirstName
            {
                get { return ReadProperty(FirstNameProperty); }
                set { LoadProperty(FirstNameProperty, value); }
            }
            public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
            public string LastName
            {
                get { return ReadProperty(LastNameProperty); }
                set { LoadProperty(LastNameProperty, value); }
            }
        }

        #endregion Criteria
    }
}
