using AutoMapper;
using STEM_backend.Models.DAO;
using STEM_backend.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<STEMPlan, STEMPlanDTO>();
            CreateMap<STEMPlanDTO, STEMPlan>();
            CreateMap<STEMPlanComment, CommentPlanDTO>();
            CreateMap<CommentPlanDTO, STEMPlanComment>();
            CreateMap<STEMReportComment, CommentPlanDTO>();
            CreateMap<CommentPlanDTO, STEMReportComment>();
            CreateMap<STEMReport, STEMReportDTO>();
            CreateMap<STEMReportDTO, STEMReport>();

        }
    }
}