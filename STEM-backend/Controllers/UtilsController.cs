using STEM_backend.Models.DAO;
using STEM_backend.Models.DTO;
using STEM_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace STEM_backend.Controllers
{
    [RoutePrefix("api")]
    public class UtilsController : ApiController
    {
        ISTEMPlanRepository _STEMPlanRepository;
        ISTEMReportRepository _sTEMReportRepository;

        public UtilsController(ISTEMPlanRepository STEMPlanRepository, ISTEMReportRepository sTEMReportRepository)
        {
            _STEMPlanRepository = STEMPlanRepository;
            _sTEMReportRepository = sTEMReportRepository;
        }

        [Route("uploadimage")]
        public IHttpActionResult Post()
        {          
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {               
                string fileName = "";
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(postedFile.FileName);                 
                    var filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + fileName);
                    postedFile.SaveAs(filePath);                  
                    break;
                }
                return Ok(new ReturnImageLoad(new Link("http://localhost:54978/Content/Images/" + fileName, "image/png", 500, 500), "success", 201));
            }
            else
            {
                return Ok(new ReturnImageLoad(null, "bad request", 400));
            }
        }
        [Route("uploadstemplanimage")]
        public IHttpActionResult PostSTEMPlanImage(int sTEMPlanId)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                STEMPlan sTEMPlan = _STEMPlanRepository.GetSTEMPlanById(sTEMPlanId);
                string fileName = "";
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(postedFile.FileName);
                    var filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + fileName);
                    postedFile.SaveAs(filePath);
                    sTEMPlan.AvatarImage = fileName;
                    _STEMPlanRepository.UpdateSTEMPlan(sTEMPlan);
                    break;
                }
                return Ok(new ReturnResult(201, "success", fileName));
            }
            else
            {
                return Ok(new ReturnResult(400, "bad request", null));
            }
        }
        [Route("uploadstemreportimage")]
        public IHttpActionResult PostSTEMReportImage(int sTEMReportId)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                STEMReport sTEMPReport = _sTEMReportRepository.GetSTEMReportById(sTEMReportId);
                string fileName = "";
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(postedFile.FileName);
                    var filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + fileName);
                    postedFile.SaveAs(filePath);
                    sTEMPReport.AvatarImage = fileName;
                    _sTEMReportRepository.UpdateSTEMReport(sTEMPReport);
                    break;
                }
                return Ok(new ReturnResult(201, "success", fileName));
            }
            else
            {
                return Ok(new ReturnResult(400, "bad request", null));
            }
        }
    }
}
