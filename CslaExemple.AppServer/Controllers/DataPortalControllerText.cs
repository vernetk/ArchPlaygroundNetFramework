using System;
using System.Threading.Tasks;
using Csla;
using CslaExemple.BLLNetStandard;
using Microsoft.AspNetCore.Mvc;

namespace CslaExemple.AppServer
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataPortalTextController : Csla.Server.Hosts.HttpPortalController
    {
        public DataPortalTextController()
        {
            UseTextSerialization = true;
        }

        // This override exists for demo purposes only, normally you
        // wouldn't implement this code.
        [HttpPost]
        public override Task PostAsync([FromQuery] string operation)
        {
            return base.PostAsync(operation);
        }

        // Implementing a GET is totally optional, but is nice
        // for quick diagnosis as to whether a service is running.
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            try
            {
                var resourceList = await ResourceList.GetResourceListAsync();
                //var obj = await DataPortal.FetchAsync<Library.Dashboard>();
                //return $"{obj.ProjectCount} projects exist; {obj.ResourceCount} resources exist";
                return $"{resourceList.Count} resource existante.";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}