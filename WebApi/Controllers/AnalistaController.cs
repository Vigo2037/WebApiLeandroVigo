using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;


namespace WebApi.Controllers
{
    /* Nesta parte eu estou fazendo a decoração da nossa API, ou seja, é através desses comandos que serão permitidos
    os acessos externos a nossa API.
    Para utilizar o EnableCors é necessário referenciar corretamente using System.Web.Http.Cors
     */
    [EnableCors("*","*","*")]
    public class AnalistaController : ApiController
    {
        // GET: api/Analista

        // GET: api/Analista
        [HttpGet]
        [Route("Recuperar")]
          public IHttpActionResult Get()
          {
            try
            {
                Analistas analista = new Analistas();
                return Ok(analista.ListarAnalista());
            }              
            catch (Exception ex)
            {
                return InternalServerError(ex);
             }
            
          }        
          // GET: api/Analista/5
          [Route("Recuperar/{id:int}/{nome}/{nome=vigo}")]
          public Analistas Get(int id)
          {
              Analistas aluno = new Analistas();
              return aluno.ListarAnalista().Where(x => x.id ==id).FirstOrDefault();
          }
        [HttpGet]
        [Route(@"RecuperaPorDataNome/{data:regex([0-9]{4}\-[0-9]{2})}/{nome:minlength(5)}")]
        public IHttpActionResult Recuperar(string data, string nome)
        {
            try
            {
                Analistas analistas = new Analistas();
                IEnumerable<Analistas> analista = analistas.ListarAnalista().Where(x => x.data == data || x.nome == nome);
                if (!analista.Any())
                    return NotFound();

                return Ok(analista);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }




                 

        // POST: api/Analista
        public List<Analistas> Post(Analistas analista)
        {
            Analistas _analista = new Analistas();
            _analista.Inserir(analista);
            return _analista.ListarAnalista();

        }

        // PUT: api/Analista/5
        public List<Analistas> Put(int id, Analistas analista)
        {
            Analistas _analista = new Analistas();
            _analista.id = id;
            _analista.Atualizar(analista);
            return _analista.ListarAnalista();

        }

        // DELETE: api/Analista/5
        public void Delete(int id)
        {
            Analistas _Analista = new Analistas();
            _Analista.Deletar(id);
           

        }
    }
}
