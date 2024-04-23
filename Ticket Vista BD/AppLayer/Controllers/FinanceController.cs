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
    public class FinanceController : ApiController
    {


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/Finance")]
        public HttpResponseMessage Finance()
        {
            try
            {
                var data = FinanceService.Finance();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Data Not Found" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }


        [AdminLogged]
        [HttpPost]
        [Route("api/admin/finance/AddSalary")]
        public HttpResponseMessage AddSalary(SalaryDTO obj)
        {
            try
            {
                var data = SalaryService.Create(obj);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Salary Added", Data = obj });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed To Add Salary" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/finance/ViewSalary")]
        public HttpResponseMessage ViewSalary()
        {
            try
            {
                var data = SalaryService.Get();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,data);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed To view Salary" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

        [AdminLogged]
        [HttpPost]
        [Route("api/admin/finance/EditSalary")]
        public HttpResponseMessage EditSalary(SalaryViewDTO obj)
        {
            try
            {
                var data = SalaryService.Update(obj);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new {Msg ="Data Updated" ,Data = obj});
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed To Edit Salary Or USer Not Found" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/finance/DeleteSalary/{id}")]
        public HttpResponseMessage DeleteSalary(int id)
        {
            try
            {
                var data = SalaryService.Delete(id);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Salary Scale Deleted" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed To Delete Salary Or USer Not Found" });

                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }
    }
}
