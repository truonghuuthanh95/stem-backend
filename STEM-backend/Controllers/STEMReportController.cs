using AutoMapper;
using STEM_backend.Models.DAO;
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
    public class STEMReportController : ApiController
    {
        ISTEMReportRepository _sTEMReportRepository;      
        ICommentRepository _commentRepository;
        ISTEMStatusRepository _sTEMStatusRepository;

        public STEMReportController(ISTEMReportRepository sTEMReportRepository, ICommentRepository commentRepository, ISTEMStatusRepository sTEMStatusRepository)
        {
            _sTEMReportRepository = sTEMReportRepository;
            _commentRepository = commentRepository;
            _sTEMStatusRepository = sTEMStatusRepository;
        }

        [Route("stemreport")]
        [HttpPost]
        public IHttpActionResult PostSTEMReport(STEMReportDTO sTEMReportDTO)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ReturnResult(400, "bad request", null));
            }
            STEMReport sTEMPReport = new STEMReport();
            Mapper.Map(sTEMReportDTO, sTEMPReport);
            sTEMPReport.CreatedAt = DateTime.Now;
            sTEMPReport.IsActive = true;
            sTEMPReport = _sTEMReportRepository.CreateSTEMReport(sTEMPReport);
            return Ok(new ReturnResult(201, "created", sTEMPReport));
        }
        [Route("getstemreports")]
        [HttpGet]
        public IHttpActionResult GetSTEMReports()
        {
            var sTEMPReports = _sTEMReportRepository.GetSTEMReports();
            return Ok(new ReturnResult(200, "success", sTEMPReports));
        }
        [Route("getstemreports/{teacherId}")]
        [HttpGet]
        public IHttpActionResult GetSTEMReportByTeacher(string teacherId)
        {
            var sTEMPReports = _sTEMReportRepository.GetSTEMReportsByTeacherId(teacherId);
            return Ok(new ReturnResult(200, "success", sTEMPReports));
        }
        [Route("getstemreport/{id}")]
        [HttpGet]
        public IHttpActionResult GetSTEMReportById(int id)
        {
            var sTEMPReport = _sTEMReportRepository.GetSTEMReportById(id);
            return Ok(new ReturnResult(200, "success", sTEMPReport));
        }
        [Route("deletestemreport/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteSTEMReportById(int id)
        {
            var sTEMPReport = _sTEMReportRepository.GetSTEMReportById(id);
            sTEMPReport.IsActive = false;
            sTEMPReport = _sTEMReportRepository.UpdateSTEMReport(sTEMPReport);
            return Ok(new ReturnResult(200, "success", sTEMPReport));
        }
        [Route("commentstemreportbyadmin")]
        [HttpPost]
        public IHttpActionResult PostCommentSTEMReportByAdmin(CommentPlanDTO commentDTO)
        {
            STEMReportComment comment = new STEMReportComment();
            comment.CreatedAt = DateTime.Now;
            comment.STEMReportId = commentDTO.STEMPlanId;
            comment.Contents = comment.Contents;
            comment = _commentRepository.CreateSTEMReportComment(comment);
            return Ok(new ReturnResult(201, "success", comment));

        }
        [Route("getcommentbystemreport/{id}")]
        [HttpPost]
        public IHttpActionResult GetCommentBySTEMReport(int id)
        {
            var comment = _commentRepository.GetSTEMReportCommentById(id);
            return Ok(new ReturnResult(201, "success", comment));

        }
        [Route("updatestemreport")]
        [HttpPost]
        public IHttpActionResult UpdateStemReport(int id, STEMReportDTO sTEMReportDTO)
        {
            STEMReport sTEMReport = _sTEMReportRepository.GetSTEMReportById(id);
            Mapper.Map(sTEMReportDTO, sTEMReport);
            sTEMReport.UpdatedAt = DateTime.Now;
            var comment = _sTEMReportRepository.UpdateSTEMReport(sTEMReport);
            return Ok(new ReturnResult(201, "success", comment));
        }
    }
}
