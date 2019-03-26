using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.resposta = 0;

            Session["primeiroOperando"] ="";
            Session["operador"] = "";
            Session["limpavisor"] = true;

            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(string visor, string bt)
        {
            string resposta=visor;
            switch(bt)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    
                    if (resposta == "0" || (bool)Session["limpavisor"])
                    {
                        resposta = bt;
                        Session["limpavisor"] = false;
                    }
                    else
                    {
                        resposta += bt;
                    }
                    break;
                case "+":
                case "-":
                case "x":
                case "/":
                    if ((string)Session["operador"]=="")
                    {
                        Session["primeiroOperando"] = visor;
                        Session["operador"] = bt;
                        Session["limpavisor"] = true;
                    }

                    else
                    {
                        double operando1 = Convert.ToDouble(Session["primeiroOperando"]);
                        string operador = (string)Session["operador"];

                        switch (operador)
                        {
                            case "+":
                                resposta = operando1 + Convert.ToDouble(resposta) + "";
                                break;
                            case "-":
                                resposta = operando1 - Convert.ToDouble(resposta) + "";
                                break;
                            case "x":
                                resposta = operando1 * Convert.ToDouble(resposta) + "";
                                break;
                            case "/":
                                resposta = operando1 / Convert.ToDouble(resposta) + "";
                                break;
                        }
                    }

                    break;


            }

            ViewBag.resposta = resposta;
            return View();
        }
    }
}