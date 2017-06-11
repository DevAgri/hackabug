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
    public class PlantioController : ApiController
    {
        private readonly DadosPlantioRepository _dadosPlantioRepository = new DadosPlantioRepository();

        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _dadosPlantioRepository.listaAll());
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
                return Request.CreateResponse(HttpStatusCode.OK, _dadosPlantioRepository.GetId(id));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Post(DadosPlantio obj)
        {
            try
            {
                _dadosPlantioRepository.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Cadastado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }

        public HttpResponseMessage Post(int id,DadosPlantio obj)
        {

            try
            {
                _dadosPlantioRepository.Update(obj);
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
                var delete = _dadosPlantioRepository.GetId(id);
                _dadosPlantioRepository.Dell(delete);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Excluido com sucesso", success = true });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = e.Message, success = false });
            }
        }
    }
}
