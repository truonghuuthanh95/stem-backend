using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STEM_backend.Models.DTO
{
    public class T_User
    {

        public Guid UserID { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }
   
        [StringLength(250)]
        public string FullName { get; set; }
        
        [StringLength(100)]
        public string PasswordSalt { get; set; }

       
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public Guid? CreatedByUser { get; set; }

        [StringLength(3)]
        public string AccountType { get; set; }

        [StringLength(50)]
        public string DonViID { get; set; }

        public bool? Disabled { get; set; }

        public bool? ForceChangePass { get; set; }

        [StringLength(50)]
        public string InitialPassword { get; set; }
    }
}