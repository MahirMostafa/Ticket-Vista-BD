using AppLayer.Auth;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    public class EmployeeController : ApiController
    {

        [EmployeeLogged]
        [HttpGet]
        [Route("api/employee/ViewProfile/{id}/{Token}")]
        public HttpResponseMessage ViewProfile(int id, string Token)
        {
            try
            {
                if (AuthService.ValidUser(Token, id))
                {

                    var data = EmployeeService.UnprotectedGet(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Wrong Token or Id" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

        [EmployeeLogged]
        [HttpGet]
        [Route("api/employee/getEmployees")]
        public HttpResponseMessage GetEmployee()
        {
            try
            {
                var data = EmployeeService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

        [EmployeeLogged]
        [HttpPut]
        [Route("api/employee/updateProfile")]
        public HttpResponseMessage UpdateEmployee(EmployeeUpdateDTO obj)
        {
            try
            {
                var data = EmployeeService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated Succesfully", Data = obj });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }

        }

        [EmployeeLogged]
        [HttpDelete]
        [Route("api/employee/DeleteEmployee/{id}")]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                var data = EmployeeService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted Succesfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

        [EmployeeLogged]
        [HttpPatch]
        [Route("api/employee/updatePassword")]
        public HttpResponseMessage UpdatePass(EmployeeUpdatePasswordDTO obj)
        {
            try
            {
                var data = EmployeeService.UpdatePass(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Password Updated Succesfully"});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message});
            }

        }


    }

    }

