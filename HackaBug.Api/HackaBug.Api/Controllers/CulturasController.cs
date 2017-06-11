using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HackaBug.Domain.Entities;
using HackaBug.Domain.Interfaces;
using HackaBug.Infra.Data.Repositories;

namespace HackaBug.Api.Controllers
{
    public class CulturasController : ApiController
    {
       private readonly CulturaRepository _culturaRepository = new CulturaRepository();

        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _culturaRepository.ListAll());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {msg = e.Message, success = false});
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _culturaRepository.GetId(id));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Post(Cultura obj)
        {
            try
            {
                _culturaRepository.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Cadastado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }


        public HttpResponseMessage Post(int id, Cultura obj)
        {
            try
            {
                _culturaRepository.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var delete = _culturaRepository.GetId(id);
                _culturaRepository.Dell(delete);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Excluido com sucesso", success = true });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }
    }
}
