using IdenetityAPI.DTO;
using IdenetityAPI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
namespace IdenetityAPI.Controllers
{
  //[Authorize]
    public class orderController : ApiController
    {
        IntiteCompaney context = new IntiteCompaney();
        public IHttpActionResult get()
        {
            return Ok(context.Orders.ToList());
        }

        public IHttpActionResult getById(int id)
        {
            return Ok(context.Orders.FirstOrDefault(O=>O.ID == id));
        }

        //Register 
        [Route("api/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Register(UserDto userDto)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AuthBl Authb = new AuthBl();
            IdentityResult result =Authb.Create(userDto.Name, userDto.Email ,userDto.Password);
            if (result.Succeeded)
            {
                return Created("http://localhost:51823/api/order", "Data saved");
            }
            return BadRequest(result.Errors.FirstOrDefault());
            

        }
        //---------------------------Get user claims-------------------
        [Route("api/GetUserClaims")]
        [Authorize]
        public UserDto GetuserClams()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            UserDto u = new UserDto()
            {
                Name = identityClaims.FindFirst("Name").Value,
                Email = identityClaims.FindFirst("Email").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value


            };
            return u;
        }
    }
}
