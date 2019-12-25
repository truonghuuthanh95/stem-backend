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
    public class STEMPlanController : ApiController
    {
        ISTEMPlanRepository _sTEMPlanRepository;
        ICommentRepository _commentRepository;
        ISTEMStatusRepository _sTEMStatusRepository;

        public STEMPlanController(ISTEMPlanRepository sTEMPlanRepository, ICommentRepository commentRepository, ISTEMStatusRepository sTEMStatusRepository)
        {
            _sTEMPlanRepository = sTEMPlanRepository;
            _commentRepository = commentRepository;
            _sTEMStatusRepository = sTEMStatusRepository;
        }

        [Route("stemplan")]
        [HttpPost]
        public IHttpActionResult PostSTEMPlan(STEMPlanDTO sTEMPlanDTO)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ReturnResult(400, "bad request", null));
            }
            STEMPlan sTEMPlan = new STEMPlan();
            Mapper.Map(sTEMPlanDTO, sTEMPlan);
            sTEMPlan.CreatedAt = DateTime.Now;
            sTEMPlan.IsActive = true;
            sTEMPlan = _sTEMPlanRepository.CreateSTEMPlan(sTEMPlan);
            return Ok(new ReturnResult(201, "created", sTEMPlan));
        }
        [Route("getstemplans")]
        [HttpGet]
        public IHttpActionResult GetSTEMPlans()
        {
            var sTEMPost = _sTEMPlanRepository.GetSTEMPlans();
            return Ok(new ReturnResult(200, "success", sTEMPost));
        }
        [Route("getstemplans/{teacherId}")]
        [HttpGet]
        public IHttpActionResult GetSTEMPlanByTeacher(string teacherId)
        {
            var sTEMPost = _sTEMPlanRepository.GetSTEMPlansByTeacherId(teacherId);
            return Ok(new ReturnResult(200, "success", sTEMPost));
        }
        [Route("getstemplan/{id}")]
        [HttpGet]
        public IHttpActionResult GetSTEMPlanById(int id)
        {
            var sTEMPost = _sTEMPlanRepository.GetSTEMPlanById(id);
            return Ok(new ReturnResult(200, "success", sTEMPost));
        }
        [Route("deletestemplan/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteSTEMPlanById(int id)
        {
            var sTEMPost = _sTEMPlanRepository.GetSTEMPlanById(id);
            sTEMPost.IsActive = false;
            sTEMPost = _sTEMPlanRepository.UpdateSTEMPlan(sTEMPost);
            return Ok(new ReturnResult(200, "success", sTEMPost));
        }
        [Route("commentstemplanbyadmin")]
        [HttpPost]
        public IHttpActionResult PostCommentSTEMPlanByAdmin(CommentPlanDTO commentDTO)
        {
            STEMPlanComment comment = new STEMPlanComment();
            comment.CreatedAt = DateTime.Now;
            comment.STEMPlanId = commentDTO.STEMPlanId;
            comment.Contents = comment.Contents;
            comment = _commentRepository.CreateSTEMPlanComment(comment);
            return Ok(new ReturnResult(201, "success", comment));

        }
        [Route("getcommentbystemplan/{id}")]
        [HttpPost]
        public IHttpActionResult GetCommentBySTEMPlan(int id)
        {
            var comment = _commentRepository.GetSTEMPlanCommentById(id);
            return Ok(new ReturnResult(201, "success", comment));

        }
        [Route("updatestemplan")]
        [HttpPost]
        public IHttpActionResult UpdateStemPlan(int id, STEMPlanDTO sTEMPlanDTO)
        {
            STEMPlan sTEMPlan = _sTEMPlanRepository.GetSTEMPlanById(id);
            Mapper.Map(sTEMPlanDTO, sTEMPlan);
            sTEMPlan.UpdatedAt = DateTime.Now;
            var comment = _sTEMPlanRepository.UpdateSTEMPlan(sTEMPlan);
            return Ok(new ReturnResult(201, "success", comment));

        }


    }
}
