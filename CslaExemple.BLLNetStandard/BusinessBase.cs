using System;
using System.Threading.Tasks;

namespace CslaExemple.BLLNetStandard.CslaBaseTypes
{
  [Serializable]
  public abstract class BusinessBase<T> : Csla.BusinessBase<T> where T : Csla.BusinessBase<T>
  {
        #region Methods

        /*
        public async Task CheckAllRulesAndWaitForAllRulesToComplete()
        {
            var tcs = new TaskCompletionSource<bool>();
            // declare event handler
            EventHandler eh = (sender, e) => tcs.SetResult(true);
            // attach to validation complete event
            ValidationComplete += eh;
            // call check rules 
            BusinessRules.CheckRules();
            // wait for tcs to set result (ValidationComplete)
            await tcs.Task;
            // unsubscripbe from event
            ValidationComplete -= eh;
        }
        */

        public async Task WaitForAllRulesToComplete()
        {
            while (IsBusy) await Task.Delay(10);
        }

        #endregion
    }
}
