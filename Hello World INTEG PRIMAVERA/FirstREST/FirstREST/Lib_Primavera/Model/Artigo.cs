using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Artigo :ArtigoShort
    {
        public string Resumo
        {
            get;
            set;
        }

        public string Developer
        {
            get;
            set;
        }
        public string Publisher
        {
            get;
            set;
        }

        public int Multiplayer
        {
            get;
            set;
        }

        public int Coop
        {
            get;
            set;
        }
        public DateTime Data
        {
            get;
            set;
        }
      
        public List<string> Genero
        {
            get;
            set;
        }

        public List<string> Idioma
        {
            get;
            set;
        }
        public int DiasRestantesDesconto
        {
            get;
            set;
        }



       

        /*
			“minRequirements” : {
						“os” : “windows 7”,
						“processor” : “dual core cpu @ 2.00ghz”,
“memory” : “1024 MB RAM”,
“graphics” : “GeForce 8600”,
“directX” : “Version 9.0c”,
“hard drive”: “300 mb”,
“sound card” : “directX compatible sound card”
},
         * 
         * */


    }
}