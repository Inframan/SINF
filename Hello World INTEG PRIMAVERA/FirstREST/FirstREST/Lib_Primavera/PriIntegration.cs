using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interop.ErpBS800;
using Interop.StdPlatBS800;
using Interop.StdBE800;
using Interop.GcpBE800;
using ADODB;
using Interop.IGcpBS800;
//using Interop.StdBESql800;
//using Interop.StdBSSql800;

namespace FirstREST.Lib_Primavera
{
    public class PriIntegration
    {
        

        # region Cliente

        public static List<Model.Cliente> ListaClientes()
        {
            
            
            StdBELista objList;

            List<Model.Cliente> listClientes = new List<Model.Cliente>();

            

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT Cliente, Nome, Moeda, NumContrib as NumContribuinte, Fac_Mor AS campo_exemplo FROM  CLIENTES");

                
                while (!objList.NoFim())
                {
                    listClientes.Add(new Model.Cliente
                    {
                        CodCliente = objList.Valor("Cliente"),
                        NomeCliente = objList.Valor("Nome"),
                        Moeda = objList.Valor("Moeda"),
                        NumContribuinte = objList.Valor("NumContribuinte"),
                        Morada = objList.Valor("campo_exemplo")
                    });
                    objList.Seguinte();

                }

                return listClientes;
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.Cliente GetCliente(string codCliente)
        {
            

            GcpBECliente objCli = new GcpBECliente();


            Model.Cliente myCli = new Model.Cliente();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {




                if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == true)
                {
                    objCli = PriEngine.Engine.Comercial.Clientes.Edita(codCliente);
                    myCli.CodCliente = objCli.get_Cliente();
                    myCli.NomeCliente = objCli.get_Nome();
                    myCli.Moeda = objCli.get_Moeda();
                    myCli.NumContribuinte = objCli.get_NumContribuinte();
                    myCli.Morada = objCli.get_Morada();
                    myCli.Pais = objCli.get_Pais();
                    myCli.CodigoPostal = objCli.get_CodigoPostal();
                    myCli.Telefone = objCli.get_Telefone();
                    myCli.Distrito = objCli.get_Distrito();
                    myCli.DataDeNascimento = objCli.get_DataCriacao();
                    return myCli;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.RespostaErro UpdCliente(Lib_Primavera.Model.Cliente cliente)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
           

            GcpBECliente objCli = new GcpBECliente();

            try
            {

                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {

                    if (PriEngine.Engine.Comercial.Clientes.Existe(cliente.CodCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        objCli = PriEngine.Engine.Comercial.Clientes.Edita(cliente.CodCliente);
                        objCli.set_EmModoEdicao(true);

                        objCli.set_Nome(cliente.NomeCliente);
                        objCli.set_NumContribuinte(cliente.NumContribuinte);
                        objCli.set_Moeda(cliente.Moeda);
                        objCli.set_Morada(cliente.Morada);

                        PriEngine.Engine.Comercial.Clientes.Actualiza(objCli);

                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;

                }

            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }


        public static Lib_Primavera.Model.RespostaErro DelCliente(string codCliente)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBECliente objCli = new GcpBECliente();


            try
            {

                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        PriEngine.Engine.Comercial.Clientes.Remove(codCliente);
                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }

                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }



        public static Lib_Primavera.Model.RespostaErro InsereClienteObj(Model.Cliente cli)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            

            GcpBECliente myCli = new GcpBECliente();

            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {

                    myCli.set_Cliente(cli.CodCliente);
                    myCli.set_Nome(cli.NomeCliente);
                    myCli.set_NumContribuinte(cli.NumContribuinte);
                    myCli.set_Moeda(cli.Moeda);
                    myCli.set_Morada(cli.Morada);

                    PriEngine.Engine.Comercial.Clientes.Actualiza(myCli);

                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }


        }

       

        #endregion Cliente;   // -----------------------------  END   CLIENTE    -----------------------


        #region Artigo

        public static Lib_Primavera.Model.Artigo GetArtigo(string codArtigo)
        {
            
            GcpBEArtigo objArtigo = new GcpBEArtigo();
            IGcpBSArtigos camposArtigo;
            Model.Artigo myArt = new Model.Artigo();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                if (PriEngine.Engine.Comercial.Artigos.Existe(codArtigo) == false)
                {
                    return null;
                }
                else
                {
                    objArtigo = PriEngine.Engine.Comercial.Artigos.Edita(codArtigo);
                    
                    camposArtigo = PriEngine.Engine.Comercial.Artigos;
                   
        


                    
                    myArt.CodArtigo = objArtigo.get_Artigo();
                    myArt.DescArtigo = objArtigo.get_Descricao();
                    myArt.Plataforma = objArtigo.get_Familia();

                    //myArt.Developer = camposArtigo.DaValorAtributo(codArtigo, "Developer");


                    //////////////////////////FETCHING LANGUAGES
                    StdBELista objList;
                    objList = PriEngine.Engine.Consulta("SELECT Artigo.Artigo, ArtigoIdioma.Idioma FROM  Artigo, ArtigoIdioma WHERE Artigo.Artigo=ArtigoIdioma.Artigo");


                     List<string> stringIdiomas = new List<string>();

                     while (!objList.NoFim())
                     {
                         if (objList.Valor("Artigo") == codArtigo)
                         {
                             stringIdiomas.Add(objList.Valor("Idioma"));

                         }
                         objList.Seguinte();
                     }



                    /////////////////FETCHING GENRES
                     objList = PriEngine.Engine.Consulta("SELECT * FROM TDU_ArtigoGenero");


                     List<string> stringGeneros = new List<string>();

                     while (!objList.NoFim())
                     {
                         if(codArtigo ==objList.Valor("CDU_Artigo") )
                             stringGeneros.Add(objList.Valor("CDU_Genero"));
                         objList.Seguinte();
                     }
                     myArt.Genero = stringGeneros;

                    ////////////////////////////////FETCHING PVP
                     objList = PriEngine.Engine.Consulta("SELECT Artigo.Artigo,Artigo.Desconto, Artigo.CDU_LCH as Date,Artigo.CDU_Dev as Dev,Artigo.CDU_Pub as Pub,Artigo.CDU_Mul as Mul,Artigo.CDU_Cop as Cop, ArtigoMoeda.PVP1 FROM  Artigo, ArtigoMoeda WHERE Artigo.Artigo=ArtigoMoeda.Artigo");

                     while (!objList.NoFim())
                     {
                         if (objList.Valor("Artigo") == codArtigo)
                         {
                             myArt.PVP1 = objList.Valor("PVP1");
                             myArt.Publisher = objList.Valor("PUB");
                             myArt.Developer = objList.Valor("DEV");
                             myArt.Multiplayer = objList.Valor("MUL");
                             myArt.Coop =  objList.Valor("COP");
                             if (objList.Valor("Desconto") > 0)
                                 myArt.Desconto = objList.Valor("Desconto");
                             else
                                 myArt.Desconto = 0;
                             myArt.Data = objList.Valor("DATE");
                             break;
                         }                         
                         objList.Seguinte();
                     }

                    /*

                    for (int i = 0; i < 2; i++)
                    */
                        //stringIdiomas[i] = idiomaList.Conteudo.
                    
                    myArt.Idioma = stringIdiomas;
                        

                    return myArt;
                }
                
            }
            else
            {
                return null;
            }

        }

        public static List<Model.ArtigoShort> ListaArtigos()
        {
                        
            StdBELista objList;

            Model.ArtigoShort art = new Model.ArtigoShort();
            List<Model.ArtigoShort> listArts = new List<Model.ArtigoShort>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

               // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT Artigo.Artigo, Artigo.Descricao,Artigo.Familia, ArtigoMoeda.PVP1 FROM  Artigo, ArtigoMoeda WHERE Artigo.Artigo=ArtigoMoeda.Artigo");

                while (!objList.NoFim())
                {
                    art = new Model.ArtigoShort();
                    art.CodArtigo = objList.Valor("Artigo");
                    art.DescArtigo = objList.Valor("Descricao");
                    art.Plataforma = objList.Valor("Familia");
                    art.PVP1 = objList.Valor("PVP1");
                    List<string> stringGeneros = new List<string>();


                    listArts.Add(art);
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }



        public static List<Model.ArtigoShort> ListaRelacionados(string Familia)
        {

            StdBELista objList;

            Model.ArtigoShort art = new Model.ArtigoShort();
            List<Model.ArtigoShort> listArts = new List<Model.ArtigoShort>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT Artigo.Artigo, Artigo.Descricao,Artigo.Familia, ArtigoMoeda.PVP1 FROM  Artigo, ArtigoMoeda WHERE Artigo.Artigo=ArtigoMoeda.Artigo");

                while (!objList.NoFim())
                {

                    if (Familia == objList.Valor("Familia"))
                    {
                        art = new Model.ArtigoShort();
                        art.CodArtigo = objList.Valor("Artigo");
                        art.DescArtigo = objList.Valor("Descricao");
                        art.Plataforma = objList.Valor("Familia");
                        art.PVP1 = objList.Valor("PVP1");
                        listArts.Add(art);
                    }
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }


        public static List<Model.ArtigoShort> ListaGenero(string genero)
        {

            StdBELista objList;

            Model.ArtigoShort art = new Model.ArtigoShort();
            List<Model.ArtigoShort> listArts = new List<Model.ArtigoShort>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT Artigo.Artigo,Artigo.Familia,Artigo.Desconto, Artigo.Descricao,TDU_ArtigoGenero.CDU_Genero as GEN, ArtigoMoeda.PVP1 FROM  Artigo, ArtigoMoeda,TDU_ArtigoGenero WHERE  Artigo.Artigo=ArtigoMoeda.Artigo AND  Artigo.Artigo=TDU_ArtigoGenero.CDU_Artigo");

                while (!objList.NoFim())
                {

                    if (genero == objList.Valor("GEN"))
                    {
                        art = new Model.ArtigoShort();
                        art.CodArtigo = objList.Valor("Artigo");
                        art.DescArtigo = objList.Valor("Descricao");
                        art.Plataforma = objList.Valor("Familia");
                        art.PVP1 = objList.Valor("PVP1");
                        art.Desconto = objList.Valor("Desconto");
                        listArts.Add(art);
                    }
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }


        public static List<Model.ArtigoShort> ListaDescontos()
        {

            StdBELista objList;

            Model.ArtigoShort art = new Model.ArtigoShort();
            List<Model.ArtigoShort> listArts = new List<Model.ArtigoShort>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                // objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();
                objList = PriEngine.Engine.Consulta("SELECT Artigo.Artigo, Artigo.Descricao,Artigo.Familia, ArtigoMoeda.PVP1,Artigo.Desconto  FROM  Artigo, ArtigoMoeda WHERE Artigo.Desconto > 0 AND Artigo.Artigo = ArtigoMoeda.Artigo");

                while (!objList.NoFim())
                {

                        art = new Model.ArtigoShort();
                        art.CodArtigo = objList.Valor("Artigo");
                        art.DescArtigo = objList.Valor("Descricao");
                        art.Plataforma = objList.Valor("Familia");
                        art.PVP1 = objList.Valor("PVP1");
                        art.Desconto = objList.Valor("DESCONTO");
                        listArts.Add(art);
                    
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }


        #endregion Artigo

   

        #region DocCompra
        

        public static List<Model.DocCompra> VGR_List()
        {
                
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();
            Model.LinhaDocCompra lindc = new Model.LinhaDocCompra();
            List<Model.LinhaDocCompra> listlindc = new List<Model.LinhaDocCompra>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                //objListCab = PriEngine.Engine.Consulta("SELECT id, NumDocExterno, Entidade, DataDoc, NumDoc, TotalMerc, Serie From CabecCompras where TipoDoc='VGR'"); //Por algum motivo os TipoDoc estão a dar erro
                objListCab = PriEngine.Engine.Consulta("SELECT id, NumDocExterno, Entidade, DataDoc, NumDoc, TotalMerc, Serie From CabecCompras");
                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.NumDocExterno = objListCab.Valor("NumDocExterno");
                    dc.Entidade = objListCab.Valor("Entidade");
                    dc.NumDoc = objListCab.Valor("NumDoc");
                    dc.Data = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, Armazem, Lote from LinhasCompras where IdCabecCompras='" + dc.id + "' order By NumLinha");
                    listlindc = new List<Model.LinhaDocCompra>();

                    while (!objListLin.NoFim())
                    {
                        lindc = new Model.LinhaDocCompra();
                        lindc.IdCabecDoc = objListLin.Valor("idCabecCompras");
                        lindc.CodArtigo = objListLin.Valor("Artigo");
                        lindc.DescArtigo = objListLin.Valor("Descricao");
                        lindc.Quantidade = objListLin.Valor("Quantidade");
                        lindc.Unidade = objListLin.Valor("Unidade");
                        lindc.Desconto = objListLin.Valor("Desconto1");
                        lindc.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindc.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindc.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindc.Armazem = objListLin.Valor("Armazem");
                        lindc.Lote = objListLin.Valor("Lote");

                        listlindc.Add(lindc);
                        objListLin.Seguinte();
                    }

                    dc.LinhasDoc = listlindc;
                    
                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }

                
        public static Model.RespostaErro VGR_New(Model.DocCompra dc)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            

            GcpBEDocumentoCompra myGR = new GcpBEDocumentoCompra();
            GcpBELinhaDocumentoCompra myLin = new GcpBELinhaDocumentoCompra();
            GcpBELinhasDocumentoCompra myLinhas = new GcpBELinhasDocumentoCompra();

            PreencheRelacaoCompras rl = new PreencheRelacaoCompras();
            List<Model.LinhaDocCompra> lstlindv = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myGR.set_Entidade(dc.Entidade);
                    myGR.set_NumDocExterno(dc.NumDocExterno);
                    myGR.set_Serie(dc.Serie);
                    myGR.set_Tipodoc("VGR");
                    myGR.set_TipoEntidade("F");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dc.LinhasDoc;
                    PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR, rl);
                    foreach (Model.LinhaDocCompra lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Compras.AdicionaLinha(myGR, lin.CodArtigo, lin.Quantidade, lin.Armazem, "", lin.PrecoUnitario, lin.Desconto);
                    }


                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(myGR, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }


        #endregion DocCompra


        #region DocsVenda

        public static Model.RespostaErro Encomendas_New(Model.DocVenda dv)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoVenda myEnc = new GcpBEDocumentoVenda();
             
            GcpBELinhaDocumentoVenda myLin = new GcpBELinhaDocumentoVenda();

            GcpBELinhasDocumentoVenda myLinhas = new GcpBELinhasDocumentoVenda();
             
            PreencheRelacaoVendas rl = new PreencheRelacaoVendas();
            List<Model.LinhaDocVenda> lstlindv = new List<Model.LinhaDocVenda>();
            bool iniciaTransaccao = false;
          

            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myEnc.set_Entidade(dv.Entidade);
                    myEnc.set_Serie("C");
                    myEnc.set_Tipodoc("ECL");
                    myEnc.set_TipoEntidade("C");
                    myEnc.set_CondPag("1");

                    myEnc.set_Seccao("2");
                    myEnc.set_Origem("Web");

                    // Linhas do documento para a lista de linhas
                    lstlindv = dv.LinhasDoc;
                    StdBELista objList;
                    PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc, rl);
                    foreach (Model.LinhaDocVenda lin in lstlindv)
                    {
                        string st = "SELECT PVP1 From ArtigoMoeda WHERE Artigo='" + lin.CodArtigo + "'";
                        objList = PriEngine.Engine.Consulta(st);
                        double pvp = objList.Valor("PVP1");

                        PriEngine.Engine.Comercial.Vendas.AdicionaLinha(myEnc, lin.CodArtigo, lin.Quantidade, "", "", pvp, 0);
                    }


                   // PriEngine.Engine.Comercial.Compras.TransformaDocumento(
                    iniciaTransaccao = true;
                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Vendas.Actualiza(myEnc, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    iniciaTransaccao = false;
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                if (iniciaTransaccao)
                 PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }

     

        public static List<Model.DocVenda> Encomendas_List()
        {
            
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            List<Model.DocVenda> listdv = new List<Model.DocVenda>();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new
            List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                //objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL'");
                objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc");
                while (!objListCab.NoFim())
                {
                    dv = new Model.DocVenda();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Entidade");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("Data");
                    dv.TotalMerc = objListCab.Valor("TotalMerc");
                    dv.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                    listlindv = new List<Model.LinhaDocVenda>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new Model.LinhaDocVenda();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("Descricao");
                        lindv.Quantidade = objListLin.Valor("Quantidade");
                        lindv.Unidade = objListLin.Valor("Unidade");
                        lindv.Desconto = objListLin.Valor("Desconto1");
                        lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }
            return listdv;
        }


       

        public static Model.DocVenda Encomenda_Get(string numdoc)
        {
            
            
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                

                string st = "SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where  NumDoc='" + numdoc + "'";
                objListCab = PriEngine.Engine.Consulta(st);
                dv = new Model.DocVenda();
              dv.id = objListCab.Valor("id");   //ISto dá problemas
                dv.Entidade = objListCab.Valor("Entidade");
                dv.NumDoc = objListCab.Valor("NumDoc");
                dv.Data = objListCab.Valor("Data");
                dv.TotalMerc = objListCab.Valor("TotalMerc");
                dv.Serie = objListCab.Valor("Serie");
                objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                listlindv = new List<Model.LinhaDocVenda>();

                while (!objListLin.NoFim())
                {
                    lindv = new Model.LinhaDocVenda();
                    lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                    lindv.CodArtigo = objListLin.Valor("Artigo");
                    lindv.DescArtigo = objListLin.Valor("Descricao");
                    lindv.Quantidade = objListLin.Valor("Quantidade");
                    lindv.Unidade = objListLin.Valor("Unidade");
                    lindv.Desconto = objListLin.Valor("Desconto1");
                    lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                    lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                    lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                    listlindv.Add(lindv);
                    objListLin.Seguinte();
                }

                dv.LinhasDoc = listlindv;
                return dv;
            }
            return null;
        }

        #endregion DocsVenda
    }
}