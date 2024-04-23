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
    public class AdminController : ApiController
    {
        [AdminLogged]
        [HttpPost]
        [Route("api/Registration/Admin")]
        public HttpResponseMessage Create(AdminDTO obj)
        {
            try
            {
                var data = AdminService.Create(obj);
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
        [Route("api/admin/getAdmins")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/getAdmin/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }



        [AdminLogged]
        [HttpGet]
        [Route("api/admin/DeleteAdmin/{id}")]
        public HttpResponseMessage DeleteAdmin(int id)
        {
            try
            {

                var data = AdminService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted Succesfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

        [AdminLogged]
        [HttpPost]
        [Route("api/admin/UpdateAdmin")]
        public HttpResponseMessage UpdateAdmin(AdminUpdateDTO obj)
        {
            try
            {
                var data = AdminService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated Succesfully", Data = obj });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }

        }


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/ViewProfile/{id}/{Token}")]
        public HttpResponseMessage ViewProfile(int id,string Token)
        {
            try
            {
                if( AuthService.ValidUser(Token,id) )
                {

                    var data = AdminService.UnprotectedGet(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                     return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Wrong Token or Id" });
                }

            }
            catch(Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

    

    }
}
