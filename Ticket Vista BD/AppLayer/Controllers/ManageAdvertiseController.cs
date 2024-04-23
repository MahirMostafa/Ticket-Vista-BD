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
    public class ManageAdvertiseController : ApiController
    {
        [AdvertiserLogged]
        [HttpPost]
        [Route("api/advertiser/advertise/Create/{id}")]
        public HttpResponseMessage Create(AdvertiseCreateDTO obj,int id)
        {
            try
            {

                var data = AdvertiseService.Create(obj, id);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Addverise Created Successfully", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Created", Data = obj });
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
        [Route("api/advertiser/advertise/History/{id}")]
        public HttpResponseMessage History(int id)
        {
            try
            {
                var data = AdvertiseService.History(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }
        }


        [AdvertiserLogged]
        [HttpGet]
        [Route("api/advertiser/advertise/ViewApproved/{id}")]
        public HttpResponseMessage ViewApproved(int id)
        {
            try
            {
                var data = AdvertiseService.ViewApproved(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }
        }

        [AdvertiserLogged]
        [HttpGet]
        [Route("api/advertiser/advertise/ViewDeclined/{id}")]
        public HttpResponseMessage ViewDeclined(int id)
        {
            try
            {
                var data = AdvertiseService.ViewDeclined(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }
        }

        [AdvertiserLogged]
        [HttpGet]
        [Route("api/advertiser/advertise/ViewPendingInd/{id}")]
        public HttpResponseMessage ViewPendingIndividual(int id)
        {
            try
            {
                var data = AdvertiseService.ViewPendingIndividual(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }
        }
    }
}
