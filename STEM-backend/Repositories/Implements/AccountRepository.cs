using STEM_backend.Models.DAO;
using STEM_backend.Models.DTO;
using STEM_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Repositories.Implements
{
    public class AccountRepository : IAccountRepository
    {
        STEMDB _db;

        public AccountRepository(STEMDB db)
        {
            _db = db;
        }

        public bool CheckAccountTeacherByUserNamePassword(string username, string password)
        {
            var user = _db.Database.SqlQuery<T_User>($"SELECT [UserID], [UserName], [FullName], [PasswordSalt], [Password], [Mobile], [Email],[CreatedByUser],[AccountType],[DonViID],[Disabled],[ForceChangePass],[InitialPassword] FROM [Server_VS].[CSDL].[dbo].[T_User] WHERE [UserName] = '{username}'").SingleOrDefault();

            if (user != null)
            {
                string isValid = _db.Database.SqlQuery<string>("SELECT [HCM_EDU_DATA].[dbo].[F_Password]('" + user.PasswordSalt + "','" + password + "')").FirstOrDefault();
                if (isValid == user.Password )
                {
                    return true;
                }
                  
            }
            return false;
        }

        public Account GetAccountAdminByUserNamePassword(string username, string password)
        {
            var account = _db.Accounts.AsNoTracking().Where(s => s.Username == username && s.Password == password).SingleOrDefault();
            return account;
        }

        public Teacher GetTeacherById(string id)
        {
            var teacher = _db.Database.SqlQuery<Teacher>($"SELECT * FROM [Server_VS].[CSDL].[dbo].[T_DM_GiaoVien] WHERE  [GiaoVienID] = '{id}'").SingleOrDefault();
            return teacher;
        }
    }
}