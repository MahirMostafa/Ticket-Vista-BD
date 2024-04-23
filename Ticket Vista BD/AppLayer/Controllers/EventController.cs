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
    public class EventController : ApiController
    {
        [EmployeeLogged]
        [HttpGet]
        [Route("api/employee/viewEvents")]
        public HttpResponseMessage ViewEvents()
        {
            try
            {
                var data = EventService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });

            }
        }
        [EmployeeLogged]
        [HttpPost]
        [Route("api/employee/addEvent")]
        public HttpResponseMessage Create(EventDTO obj)
        {
            try
            {
                var data = EventService.Create(obj);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Event Added", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error", Data = obj });
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

        [EmployeeLogged]
        [HttpGet]
        [Route("api/employee/getEvent/{id}")]
        public HttpResponseMessage GetEvent(int id)
        {
            try
            {
                var data = EventService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

        [EmployeeLogged]
        [HttpPut]
        [Route("api/employee/updateEvent")]
        public HttpResponseMessage UpdateEvent(EventUpdateDTO obj)
        {
            try
            {
                var data = EventService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated Succesfully", Data = obj });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }

        }

        [EmployeeLogged]
        [HttpDelete]
        [Route("api/employee/DeleteEvent/{id}")]
        public HttpResponseMessage DeleteEvent(int id)
        {
            try
            {
                var data = EventService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted Succesfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }
    }
}
