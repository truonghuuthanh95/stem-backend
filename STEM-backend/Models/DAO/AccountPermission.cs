namespace STEM_backend.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountPermission")]
    public partial class AccountPermission
    {
        public int Id { get; set; }

        public int? AccountId { get; set; }

        public int? PermissionId { get; set; }

        public bool? IsActive { get; set; }

        public virtual Account Account { get; set; }

        public virtual Permission Permission { get; set; }
    }
}
