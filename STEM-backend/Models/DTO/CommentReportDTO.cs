using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Models.DTO
{
    public class CommentReportDTO
    {
        public string Contents { get; set; }

        public int ReviewBy { get; set; }

        public int STEMReportId { get; set; }
    }
}