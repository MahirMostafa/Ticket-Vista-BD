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
    public class EventProfitController : ApiController
    {


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/EventProfit/{id}")]
        public HttpResponseMessage EventProfit(int id)
        {
            try
            {
                var data = ProfitService.EventProfit(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new {Msg ="Event Profit Details:" ,Data =data});
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Data Not Found" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/TotalEventProfit")]
        public HttpResponseMessage TotalEventProfit()
        {
            try
            {
                var data = ProfitService.AllEventProfit();
                if (data > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Profit From All The Event :", Data = data });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Data Not Found" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }


    }
}
