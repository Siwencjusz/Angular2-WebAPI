using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Angular2WebApi.WebApi.BaseApi;
using Commons.DTOs;
using Commons.Interfaces.Manager.baseManager;

namespace Angular2WebApi.WebApi
{
    [System.Web.Http.RoutePrefix("api/BookApi")]
    public class BookApiController : BaseApiController<BookDto>
    {
        public BookApiController(IBaseManager<BookDto> manager) : base(manager)
        {
        }
    }
}