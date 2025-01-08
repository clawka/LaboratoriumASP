using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public enum Operator
{
    Unknown, Add, Mul, Sub, Div
}

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Calculator(Operator? op, double? a, double? b)
    {
        if (a is null || b is null)
        {
            ViewBag.errorMessage = "Niepoprawny format liczby w parametrze a lub b";
            return View("ErrorMessage");
        }
        if (op is not Operator)
        {
            ViewBag.errorMessage = "Nieznany operator";
            return View("ErrorMessage");
        }

        ViewBag.a = a;
        ViewBag.b = b;
        
        switch(op)
        {
            case Operator.Add:
                ViewBag.Result = a + b;
                ViewBag.op = "+";
                break;
            case Operator.Sub:
                ViewBag.Result = a - b;
                ViewBag.op = "-";
                break;
            case Operator.Mul:
                ViewBag.Result = a * b;
                ViewBag.op = "*";
                break;
            case Operator.Div:
                if (b == 0)
                {
                    ViewBag.errorMessage = "Nie mozna dzielic na 0";
                    return View("ErrorMessage");
                }
                ViewBag.Result = a / b;
                ViewBag.op = "/";
                break;
        }
        return View();
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}