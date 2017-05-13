using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Redis;

namespace Redis.Controllers
{
    
    public class HomeController : Controller
    {
        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            var stringConexao = $@"hsouza.redis.cache.windows.net, password=YtvZCo4BSdShjPS3PYeqBoCzSfTiBwr+J0rskXatyVI=, ssl=true";

            var cCon = ConnectionMultiplexer.Connect(stringConexao);

            ViewBag.DataInicio = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
            var soma = 0;

            IDatabase db = cCon.GetDatabase();

            var resultado = db.StringGet("resultcalc1");

            if (string.IsNullOrWhiteSpace(resultado))
            {
                for (int i = 0; i < 10; i++)
                {
                    soma += 1;
                    System.Threading.Thread.Sleep(1000);
                }

                db.StringSet("resultcalc1", soma);
            }
            else {
                soma = Convert.ToInt32(resultado);
            }

            cCon.Close();

            ViewBag.Soma = soma;
            ViewBag.Fim = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");


            return View();
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
    }
}