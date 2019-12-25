using STEM_backend.Models.DTO;
using STEM_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace STEM_backend.Controllers
{
    [RoutePrefix("api")]
    public class AccountController : ApiController
    {
        IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ReturnResult(400, "bad request", null));
            }
            if (loginModel.Type == "teacher")
            {
                var isValid = _accountRepository.CheckAccountTeacherByUserNamePassword(loginModel.Username.Trim(), loginModel.Password.Trim());
                if (isValid)
                {
                    var teacher = _accountRepository.GetTeacherById(loginModel.Username);
                    return Ok(new ReturnResult(200, "success", teacher));
                }
            }
            else if (loginModel.Type == "admin")
            {
                var account = _accountRepository.GetAccountAdminByUserNamePassword(loginModel.Username.Trim(), loginModel.Password.Trim());
                if (account != null)
                {
                    account.Password = null;
                    account.Username = null;
                    return Ok(new ReturnResult(200, "success", account));
                }
                
            }
            return Ok(new ReturnResult(404, "not found", null));
        }
    }
}
