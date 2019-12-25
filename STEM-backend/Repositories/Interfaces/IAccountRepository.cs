using STEM_backend.Models.DAO;
using STEM_backend.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccountAdminByUserNamePassword(string username, string password);
        bool CheckAccountTeacherByUserNamePassword(string username, string password);
        Teacher GetTeacherById(string id);
        
    }
}