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
    public class ManageEmployeeController : ApiController
    {


        [AdminLogged]
        [HttpPost]
        [Route("api/Registration/Employee")]
        public HttpResponseMessage Create(EmployeeDTO obj)
        {
            try
            {
                var data = EmployeeService.Create(obj);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Registered Successfully", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Registered", Data = obj });
                }
            }
            catch (DbUpdateException dbEx)
            {
                Exception innerException = dbEx.InnerException;
                while (innerException.InnerException != null)
                    innerException = innerException.InnerException;
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = innerException.Message, Data = obj });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }
        }


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/getEmployees")]
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



        [AdminLogged]
        [HttpGet]
        [Route("api/admin/getEmployee/{id}")]
        public HttpResponseMessage GetEmployee(int id)
        {
            try
            {
                var data = EmployeeService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }


        [AdminLogged]
        [HttpPost]
        [Route("api/admin/UpdateEmployee")]
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


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/DeleteEmployee/{id}")]
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
    }
}
