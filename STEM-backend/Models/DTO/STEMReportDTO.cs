using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STEM_backend.Models.DTO
{
    public class STEMReportDTO
    {
        [Required]
        [StringLength(50)]
        public string TeacherName { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherId { get; set; }

        [Required]
        [StringLength(200)]
        public string Topic { get; set; }

        [Required]
        [StringLength(500)]
        public string Summary { get; set; }
        [Required]
        public string ReportDetail { get; set; }

        [Required]
        [StringLength(50)]
        public string SchoolName { get; set; }
        [StringLength(50)]
        [Required]
        public string SchoolId { get; set; }
        [Required]
        public DateTime OperationTime { get; set; }
        [Required]
        public int? StudentQuantity { get; set; }
        [Required]
        public double Budget { get; set; }
    }
}