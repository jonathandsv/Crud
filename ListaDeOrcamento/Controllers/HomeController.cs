using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListaDeOrcamento.Models;

namespace ListaDeOrcamento.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index(int? id)
        {
            TdPecas pecas = new TdPecas();

            List<Peca> PecasList  = pecas.Mostrando_o_Banco();
    
            return View(PecasList);

        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";
            return View();

           
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        public ActionResult NewPeca()
        {



            return View();
        }

        public ActionResult ExcluirPeca(int peca)
        {

            TdPecas pecas = new TdPecas();
            Peca pc = new Peca();
            pc = pecas.Pesquisar_uma_peca(peca);

            return View(pc);
        }

        public ActionResult EditarPeca(int peca)
        {
            TdPecas pecas = new TdPecas();
            Peca pc = new Peca();
            pc = pecas.Pesquisar_uma_peca(peca);
            return View(pc);
        }

        //Fim da chamada de páginas



        public ActionResult InserirNewPeca(Peca peca)
        {

            TdPecas pecas = new TdPecas();
            peca = pecas.Inserir(peca.CodPeca, peca.Nome, peca.Descricao);

            ViewBag.Message = "Peça Adicionada com Sucesso";
            return View("NewPeca", peca);
        }


        public ActionResult EditarUmaPeca(Peca peca)
        {
            TdPecas pecas = new TdPecas();
            peca = pecas.Editar(peca.CodPeca, peca.Nome, peca.Descricao);

            ViewBag.Message = "Peça alterada com Sucesso";

            return View("EditarPeca", peca);
        }

        public ActionResult PesquisarUmaPeca(Peca peca)
        {

            Peca pc = new Peca();
            pc = peca;


            return View();
        }

        public ActionResult PesquisarVariasPecas(string nome)
        {
            TdPecas tdPecas = new TdPecas();
            List<Peca> pc = tdPecas.Pesquisar_varias_pecas(nome);
            


            return View("Index", pc);
        }

        public ActionResult ExcluirUmaPeca(int id)
        {

            TdPecas deletar = new TdPecas();
            int deletando = deletar.deletar_peca(id);
           
            Peca peca = new Peca();
            peca = deletar.Pesquisar_uma_peca(id);
            ViewBag.Message = "Peça Excluida com Sucesso!";
            return View("ExcluirPeca", peca);
        }

    }
}