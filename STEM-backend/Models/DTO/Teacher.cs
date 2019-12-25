using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STEM_backend.Models.DTO
{
    public class Teacher
    {
        public int? GiaoVienID { get; set; }
        
        public string Ho { get; set; }
      
        public string Ten { get; set; }

        public int? QuocTichID { get; set; }
      
        public string CMND_HoChieu { get; set; }
        public DateTime? NgayCap { get; set; }
        public string NoiCap { get; set; }       
        public string DienThoai { get; set; }

        public string Email { get; set; }

        public string ThuongTru_SoNha { get; set; }
        public int? ThuongTru_TinhID { get; set; }

        
        public int? ThuongTru_QuanHuyenID { get; set; }

        public int? ThuongTru_XaPhuongID { get; set; }

        
        public bool? Nu { get; set; }
        public Byte? NgaySinh { get; set; }

        public Byte? ThangSinh { get; set; }
        public Int16? NamSinh { get; set; }

        
        public Byte? DanTocID { get; set; }

        public Byte? TonGiaoID { get; set; }

        
        public DateTime? ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public int? LogID { get; set; }

        public string MaGiaoVienBGD { get; set; }

        public int? STT { get; set; }

    }
}