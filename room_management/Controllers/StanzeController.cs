
using room_management.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace room_management.Controllers
{
    // definisco la common route
    [RoutePrefix("api/stanze")]
    public class StanzeController : ApiController
    {
        Entities db = new Entities();
        Response response = new Response();
        //Per aggiungere info alla mia tabella
        [HttpPost,Route("add")]
        public HttpResponseMessage Add([FromBody] stanze stanze)
        {
            try
            {
                db.stanzes.Add(stanze);
                db.SaveChanges();
                response.Message = "Stanza aggiunta con successo!";
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex) 
            { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex);
            }
        }

        //Per leggere info della mia tabella
        [HttpGet, Route("get")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.stanzes.ToList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        //Per aggiornare info dalla mia tabella
        [HttpPatch, Route("update")]
        public HttpResponseMessage Update([FromBody] stanze stanze)
        {
            try
            {
                stanze stanzeObj = db.stanzes.Find(stanze.id);
                if (stanzeObj == null)
                {
                    response.Message = "Stanza non registrata";
                    return Request.CreateResponse(HttpStatusCode.OK, response );
                }
                stanzeObj.nome= stanze.nome;
                stanzeObj.prezzo= stanze.prezzo;
                stanzeObj.descrizione= stanze.descrizione;
                db.Entry(stanzeObj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                response.Message = "Situazione stanza aggiornata!";
                return Request.CreateResponse(HttpStatusCode.OK,response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        //Per cancellare item dalla mia tabella
        [HttpDelete, Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try 
            {
                stanze stanzeObj= db.stanzes.Find(id);
                if(stanzeObj == null)
                {
                    response.Message = "Stanza non esistente";
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                db.stanzes.Remove(stanzeObj);
                db.SaveChanges();
                response.Message = "Stanza cancellata correttamente";
                return Request.CreateResponse(HttpStatusCode.OK, response);
            
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);   
            }
        }
          

    }
}




