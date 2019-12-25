namespace STEM_backend.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STEMPlan")]
    public partial class STEMPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STEMPlan()
        {
            STEMPlanComments = new HashSet<STEMPlanComment>();
        }

        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [StringLength(50)]
        public string TeacherName { get; set; }

        [StringLength(50)]
        public string TeacherId { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(200)]
        public string Topic { get; set; }

        [StringLength(500)]
        public string AvatarImage { get; set; }

        [StringLength(500)]
        public string Summary { get; set; }

        public int? StatusId { get; set; }

        [Column(TypeName = "ntext")]
        public string PostDetail { get; set; }

        [StringLength(50)]
        public string SchoolName { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(50)]
        public string SchoolId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STEMPlanComment> STEMPlanComments { get; set; }

        public virtual STEMStatu STEMStatu { get; set; }
    }
}
