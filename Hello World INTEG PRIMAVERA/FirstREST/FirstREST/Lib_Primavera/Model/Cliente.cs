using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Cliente
    {
        public string Morada;

        /* Exemplo para POST e GET com valores específicos
         public string Morada
        {
            get
            {
                return "MORADA: " + _morada;
            }
            set
            {
                _morada = value;
            }
        }
    
*/       
        public string CodCliente
        {
            get;
            set;
        }

        public string NomeCliente
        {
            get;
            set;
        }

        public string NumContribuinte
        {
            get;
            set;
        }

        public string Moeda
        {
            get;
            set;
        }
        public DateTime DataDeNascimento
        {
            get;
            set;
        }

        public string Pais
        {
            get;
            set;
        }
        public string Distrito
        {
            get;
            set;
        }
        public string CodigoPostal
        {
            get;
            set;
        }

        public string Telefone
        {
            get;
            set;
        }


    }
}