using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    [RoutePrefix("api/vehicules")]
    public class VehiculesController : ApiController
    {
        private readonly VehiculeRepository _repo = new VehiculeRepository();

        // GET /api/vehicules
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        // GET /api/vehicules/3
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var v = _repo.Get(id);
            if (v == null) return NotFound();
            return Ok(v);
        }
    }
}