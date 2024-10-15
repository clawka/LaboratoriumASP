using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: CalculatorController.cs
        public ActionResult Index()
        {
            return View();
        }
        
        public IActionResult Result(int x,string op,int y)
        {
      
            switch (op)
            {
                case "+":
                    ViewBag.Result = x+y;
                    break;
                case "-":
                    ViewBag.Result = x-y ;
                    break;
                case "*":
                    ViewBag.Result = x*y;
                    break;
                case "/":
                    ViewBag.Result = x/y;
                    break;
                default:
                    ViewBag.Result = "b";
                    break;
            }
            return View();
        }
        public IActionResult Form(int x,string op,int y)
        {
            return Result(x,op,y);
        }
    }
}
