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
    public class AdvertiserController : ApiController
    {
        [HttpPost]
        [Route("api/Registration/Advertiser")]
        public HttpResponseMessage Create(AdvertiserDTO obj)
        {
            try
            {
                var data = AdvertiserService.Create(obj);
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


        [AdvertiserLogged]
        [HttpGet]
        [Route("api/advertiser/ViewProfile/{id}/{Token}")]
        public HttpResponseMessage ViewProfile(int id, string Token)
        {
            try
            {
                if (AuthService.ValidUser(Token, id))
                {

                    var data = AdvertiserService.UnprotectedGet(id);
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


            [AdvertiserLogged]
            [HttpPut]
            [Route("api/advertiser/updateProfile")]
            public HttpResponseMessage UpdateAdvertiser(AdvertiserUpdateDTO obj)
            {
                try
                {
                    var data = AdvertiserService.Update(obj);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated Succesfully", Data = obj });
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
                }

            }

        [AdvertiserLogged]
        [HttpDelete]
        [Route("api/advertiser/DeleteAdvertiser/{id}")]
        public HttpResponseMessage DeleteAdvertiser(int id)
        {
            try
            {
                var data = AdvertiserService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted Succesfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

    }
    }

