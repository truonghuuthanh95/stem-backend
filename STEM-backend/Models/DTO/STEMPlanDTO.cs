using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STEM_backend.Models.DTO
{
    public class STEMPlanDTO
    {
        [StringLength(50)]
        public string TeacherName { get; set; }

        [StringLength(50)]
        public string TeacherId { get; set; }       

        [StringLength(200)]
        public string Topic { get; set; }
        
        [StringLength(500)]
        public string Summary { get; set; }
       
        public string PostDetail { get; set; }

        [StringLength(50)]
        public string SchoolName { get; set; }
        [StringLength(50)]
        public string SchoolId { get; set; }
    }
}