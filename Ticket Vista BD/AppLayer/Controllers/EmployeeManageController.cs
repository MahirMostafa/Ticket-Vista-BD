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
    public class EmployeeManageController : ApiController
    {
        [EmployeeLogged]
        [HttpGet]
        [Route("api/employee/manage/ViewAllClient")]

        public HttpResponseMessage GetClients()
        {
            try
            {
                var data = AdvertiserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

        [EmployeeLogged]
        [HttpGet]
        [Route("api/employee/manage/ViewAllAds")]

        public HttpResponseMessage ViewAllAds()
        {
            try
            {
                var data = AdvertiseService.GetAllAds();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }
        }

        [EmployeeLogged]
        [HttpGet]
        [Route("api/employee/manage/ViewPendingAds")]

        public HttpResponseMessage ViewAPendingAds()
        {
            try
            {
                var data = AdvertiseService.GetPendingAds();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }
        }

        [EmployeeLogged]
        [HttpPost]
        [Route("api/employee/manage/ApproveAd/{id}")]

        public HttpResponseMessage ApproveAd(int id)
        {
            
                try
                {             
                    var data = AdvertiseService.ApproveAd(id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg= "Advertise Approved"});
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
                }
            
        }
        [EmployeeLogged]
        [HttpPost]
        [Route("api/employee/manage/DeclineAd/{id}")]

        public HttpResponseMessage DeclineeAd(int id)
        {

            try
            {
                var data = AdvertiseService.DeclineeAd(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Advertise Declined" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }


    }
}
