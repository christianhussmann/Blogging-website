using System;
using Blogging_website.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogging_website.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService service)
        {
            _loginService = service;
        }

        [HttpDelete("{id}")]
        public Login Delete(int id)
        {
            return _loginService.DeleteLogin(id);
        }

        [HttpPut("{id:int}")]
        public ActionResult<LoginDto> UpdateLogin(int id, LoginDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("It is not a match bro");
            }

            var login = _loginService.UpdateLogin(new Login
            {
                Id = dto.Id,
                Email = dto.Email
            });
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<LoginDto> CreateLogin([FromBody] LoginDto dto)
        {
            var loginFromDto = new Login
            {
                Id = dto.Id,
                Email = dto.Email
            };

            try
            {
                var newLogin = _loginService.CreateLogin(loginFromDto);
                return Created($"https://localhost:5001/api/logins/{newLogin.Id}")
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        [HttpGet]
        public ActionResult<LoginsDto> GetAllLogin()
        {
            try
            {
                var logins = _loginService.GetAllLogins()
                    .Select(login => new LoginDto
                    {
                        Id = login.Id,
                        Email = login.Email
                    }).ToList();
                return Ok(new LoginsDto
                {
                    List = logins
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<LoginDto> GetLoginById(int id)
        {
            var login = _loginService.GetLoginById(id);
            return Ok(new Login
            {
                Id = login.Id,
                Email = login.Email
            });
        }


    }
}