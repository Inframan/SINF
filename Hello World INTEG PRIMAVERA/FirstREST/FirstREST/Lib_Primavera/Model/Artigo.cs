using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Artigo
    {
        public string CodArtigo
        {
            get;
            set;
        }

        public string DescArtigo
        {
            get;
            set;
        }

        public double PVP1
        {
            get;
            set;
        }

       public string Plataforma
        {
            get;
            set;
        }

        public string Titulo
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

        public bool Multiplayer
        {
            get;
            set;
        }

        public bool Coop
        {
            get;
            set;
        }
        public int Ano
        {
            get;
            set;
        }
        public int Mes
        {
            get;
            set;
        }

        public int Dia
        {
            get;
            set;
        }

        public string[] Genero
        {
            get;
            set;
        }

        public string[] LinguaInterface
        {
            get;
            set;
        }

        public string[] LinguaAudio
        {
            get;
            set;
        }

        public string[] LinguaLegendas
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