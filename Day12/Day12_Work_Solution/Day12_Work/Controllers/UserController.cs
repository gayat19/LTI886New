using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Day12_Work.Models;

namespace Day12_Work.Controllers
{
    [EnableCors(origins:"http://localhost:4200",headers:"*",methods:"*")]
    public class UserController : ApiController
    {
        dbWebAPIEntities entities = new dbWebAPIEntities();

        [HttpPost]
        public HttpResponseMessage UserLogin(tblUser user)
        {
            proc_LoginCheck_Result result = null;
            result = entities.proc_LoginCheck(user.userid, user.password).FirstOrDefault();
            if (result == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Username or password");
            else
                return Request.CreateResponse<proc_LoginCheck_Result>(result);
        }
    }
}
