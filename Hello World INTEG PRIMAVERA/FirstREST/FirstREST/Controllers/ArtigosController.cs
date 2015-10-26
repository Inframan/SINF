using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;


namespace FirstREST.Controllers
{
    public class ArtigosController : ApiController
    {
        //
        // GET: /Artigos/

        public IEnumerable<Lib_Primavera.Model.ArtigoShort> Get()
        {
            return Lib_Primavera.PriIntegration.ListaArtigos();
        }


        // GET api/artigo/5    
        public Artigo Get(string id)
        {
            

            Lib_Primavera.Model.Artigo artigo = Lib_Primavera.PriIntegration.GetArtigo(id);
            if (artigo == null)
            {
                throw new HttpResponseException(
                  Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return artigo;
            }
        }



    }





    public class ArtigoFiltroController : ApiController
    {
        //
        // GET: /atrigoFiltro/

        public IEnumerable<Lib_Primavera.Model.ArtigoShort> Get(string id)
        {
            return Lib_Primavera.PriIntegration.ListaRelacionados(id);
        }


        // GET api/artigo/5    
        public Artigo Get()
        {
            return new Artigo();
       }



    }



    public class ArtigoDescontoController : ApiController
    {
        //
        // GET: /atrigoFiltro/

        public IEnumerable<Lib_Primavera.Model.ArtigoShort> Get(string id)
        {
            return Lib_Primavera.PriIntegration.ListaRelacionados(id);
        }


        // GET api/artigo/5    
        public IEnumerable<Lib_Primavera.Model.ArtigoShort> Get()
        {
            return Lib_Primavera.PriIntegration.ListaDescontos();
       }



    }





}

