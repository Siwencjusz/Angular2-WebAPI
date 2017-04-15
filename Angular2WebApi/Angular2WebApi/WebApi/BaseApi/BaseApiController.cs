using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Commons;
using Commons.DTOs.BaseDto;
using Commons.Interfaces.Manager.baseManager;

namespace Angular2WebApi.WebApi.BaseApi
{
    public class BaseApiController<TViewModel> : ApiController
      
       where TViewModel : BaseDto
        {
        private readonly IBaseManager<TViewModel> _manager;

        public BaseApiController(IBaseManager<TViewModel> manager)
        {
            _manager = manager;
        }

        [System.Web.Http.Route("GetAll")]
        public virtual HttpResponseMessage GetAll()
        {
            var result = _manager.GetAll();
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Result= result });
        }

        [System.Web.Http.Route("AddOrUpdate")]
        public virtual HttpResponseMessage AddOrUpdate(TViewModel addItem)
        {
            if (ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, new { ModelState });
            if (addItem.Id == 0) _manager.Create(addItem);
            else _manager.Update(addItem);
            return Request.CreateResponse(HttpStatusCode.OK, new {addItem});
        }
        [HttpDelete]
        [System.Web.Http.Route("Delete")]
        public virtual HttpResponseMessage Remove(int id)
        {            
            var result = _manager.GetBy(x => x.Id == id);
            _manager.Delete(result);
            if (result!=null) { _manager.Delete(result); return Request.CreateResponse(HttpStatusCode.OK);}
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        [System.Web.Http.Route("GetById")]
        public virtual HttpResponseMessage GetById(int id)
        {
            var result = _manager.GetBy(x => x.Id == id);
            return result==null ? Request.CreateResponse(HttpStatusCode.BadRequest) : Request.CreateResponse(HttpStatusCode.OK, new {result});
        }
    }
}