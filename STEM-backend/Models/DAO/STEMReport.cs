namespace STEM_backend.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STEMReport")]
    public partial class STEMReport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STEMReport()
        {
            STEMReportComments = new HashSet<STEMReportComment>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Topic { get; set; }

        public int? ReviewBy { get; set; }

        public string Summary { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [StringLength(50)]
        public string TeacherName { get; set; }

        [StringLength(50)]
        public string TeacherId { get; set; }

        [StringLength(50)]
        public string SchoolName { get; set; }

        [StringLength(50)]
        public string SchoolId { get; set; }

        public int? StatusId { get; set; }

        [StringLength(500)]
        public string AvatarImage { get; set; }

        [Column(TypeName = "ntext")]
        public string ReportDetail { get; set; }

        public DateTime? OperationTime { get; set; }

        public int? StudentQuantity { get; set; }

        public double? Budget { get; set; }

        public virtual STEMStatu STEMStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STEMReportComment> STEMReportComments { get; set; }
    }
}
