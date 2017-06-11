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
    public class PragasController : ApiController
    {
        private readonly PragasRepository _pragasRepository = new PragasRepository();


        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _pragasRepository.ListAll());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _pragasRepository.GetId(id));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Post(Pragas obj)
        {
            try
            {
                _pragasRepository.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Cadastrado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Post(int id, Pragas obj)
        {
            try
            {
                _pragasRepository.Update(obj);
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
                var delete = _pragasRepository.GetId(id);
                _pragasRepository.Dell(delete);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Excluido com sucesso", success = true });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }
    }
}
