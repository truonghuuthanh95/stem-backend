using STEM_backend.Models.DTO;
using STEM_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace STEM_backend.Controllers
{
    [RoutePrefix("api")]
    public class STEMStatusController : ApiController
    {
        ISTEMStatusRepository _sTEMStatusRepository;

        public STEMStatusController(ISTEMStatusRepository sTEMStatusRepository)
        {
            _sTEMStatusRepository = sTEMStatusRepository;
        }
        [Route("getstemstatus")]
        [HttpGet]
        public IHttpActionResult GetStemStatus()
        {
            var status = _sTEMStatusRepository.GetSTEMStatus();
            return Ok(new ReturnResult(200, "success", status));

        }
    }
}
