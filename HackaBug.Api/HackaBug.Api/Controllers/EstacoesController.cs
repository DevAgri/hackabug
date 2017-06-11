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
    public class EstacoesController : ApiController
    {
        private readonly EstacoesRepository _estacoesRepository = new EstacoesRepository();

        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _estacoesRepository.ListAll());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _estacoesRepository.GetId(id));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Post(Estacoes obj)
        {
            try
            {
                _estacoesRepository.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Cadastado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Post(int id,Estacoes obj)
        {
            try
            {
                _estacoesRepository.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var delete = _estacoesRepository.GetId(id);
                _estacoesRepository.Dell(delete);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Excluido com sucesso", success = true });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = e.Message, success = false });
            }
        }
    }
}
