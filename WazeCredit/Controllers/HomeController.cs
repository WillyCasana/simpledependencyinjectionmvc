using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WazeCredit.Models;
using WazeCredit.Models.ViewModels;
using WazeCredit.Service;

namespace WazeCredit.Controllers;

public class HomeController : Controller
{
    public HomeVM homeVM{get;set;}
    private readonly IMarketForecaster _marketForecaster;

    public HomeController(IMarketForecaster marketForecaster)
    {
        homeVM = new HomeVM();
        _marketForecaster = marketForecaster;
    }
    public IActionResult Index()
    {
        MarketResult currentMarket= _marketForecaster.GetMarketPrediction();

        switch (currentMarket.MarketCondition)
        {
            case MarketCondition.StableDown:
                homeVM.MarketForecast="lorem StableDown ipsumHtml By Mehedi Islam Ripon on Feb 25 2021 ThankComments(4)Suggest EditShare";
                break;
            case MarketCondition.StableUp:
                homeVM.MarketForecast="lorem2 StableUp ipsumHtml By Mehedi Islam Ripon on Feb 25 2021 ThankComments(4)Suggest EditShare";
                break;
             case MarketCondition.Volatile:
                homeVM.MarketForecast="lorem3 Volatile ipsumHtml By Mehedi Islam Ripon on Feb 25 2021 ThankComments(4)Suggest EditShare";
                break;
             default:
                homeVM.MarketForecast="lorem4 default ipsumHtml By Mehedi Islam Ripon on Feb 25 2021 ThankComments(4)Suggest EditShare";
                break;
              
        }

        return View(homeVM);
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
