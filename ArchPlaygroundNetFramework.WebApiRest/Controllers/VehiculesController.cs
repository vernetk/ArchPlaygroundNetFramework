using ArchPlaygroundNetFramework.Bll;
using ArchPlaygroundNetFramework.Dal;
using ArchPlaygroundNetFramework.WebApiRest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ArchPlaygroundNetFramework.WebApiRest.Controllers
{
    [RoutePrefix("api/vehicules")]
    public class VehiculesController : ApiController
    {
        private readonly IVehiculeService _service;
        private readonly LinkBuilder _links;

        public VehiculesController(IVehiculeService service, LinkBuilder links)
        {
            _service = service;
            _links = links;
        }

        // GET /api/vehicules/123
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var vehicule = await _service.GetAsync(id);
            if (vehicule == null)
                return NotFound();

            return Ok(new
            {
                vehicule,
                _links = new
                {
                    self = _links.Vehicule(id)
                }
            });
        }

        // GET /api/vehicules?page=1&pageSize=20&marque=Renault
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Search([FromUri] VehiculeSearchCriteria c)
        {
            var result = await _service.SearchAsync(c);

            return Ok(new
            {
                result.Items,
                result.Page,
                result.PageSize,
                result.TotalCount,
                _links = _links.PagedVehicules(c, result.TotalCount)
            });
        }
    }
}
