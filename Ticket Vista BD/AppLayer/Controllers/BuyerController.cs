using AppLayer.Auth;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    public class BuyerController : ApiController
    {
        [HttpPost]
        [Route("api/Registration/Buyer")]
        public HttpResponseMessage Create(BuyerDTO obj)
        {
            try
            {
                var data = BuyerService.Create(obj);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Registered Successfully", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Registered", Data = obj });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }

        }


        [BuyerLogged]
        [HttpGet]
        [Route("api/Buyer/ViewProfile/{id}/{Token}")]
        public HttpResponseMessage ViewProfile(int id, string Token)
        {
            try
            {
                if (AuthService.ValidUser(Token, id))
                {

                    var data = BuyerService.UnprotectedGet(id);
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


        [BuyerLogged]
        [HttpGet]
        [Route("api/Buyer/viewEvents")]
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

    }
}
