namespace STEM_backend.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STEMReportComment")]
    public partial class STEMReportComment
    {
        public int Id { get; set; }

        public string Contents { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int? ReviewBy { get; set; }

        public int? STEMReportId { get; set; }

        public virtual Account Account { get; set; }

        public virtual STEMReport STEMReport { get; set; }
    }
}
