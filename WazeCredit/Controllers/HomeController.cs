using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WazeCredit.Models;
using WazeCredit.Models.ViewModels;
using WazeCredit.Service;
using WazeCredit.Utility.AppSettingsClasses;

namespace WazeCredit.Controllers;

public class HomeController : Controller
{
    public HomeVM homeVM{get;set;}
    private readonly IMarketForecaster _marketForecaster;
    private readonly StripeSettings _stripeOptions;
    private readonly SendgridSettings _sendGridOptions;
    private readonly TwilioSettings _twilioOptions;
    private readonly WazeForecastSettings _wazeOptions;
    

    public HomeController(IMarketForecaster marketForecaster,
        IOptions<StripeSettings> stripeOptions,
        IOptions<SendgridSettings> sendGridOptions,
        IOptions<TwilioSettings> twilioOptions,
        IOptions<WazeForecastSettings> wazeOptions
        )
    {
        homeVM = new HomeVM();
        _marketForecaster = marketForecaster;
        _stripeOptions= stripeOptions.Value;
        _sendGridOptions= sendGridOptions.Value;
        _twilioOptions= twilioOptions.Value;
        _wazeOptions= wazeOptions.Value;
        

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

    public IActionResult AllConfigSettings()
    {
        List<string> messages = new List<string>();
        messages.Add($"Waze config - Forecast Tracker: " + _wazeOptions.ForecastTrackerEnabled);
        messages.Add($"Stripe Publishable Key: " + _stripeOptions.PublishableKey);
        messages.Add($"Twilio Phone: " + _twilioOptions.PhoneNumber);
        messages.Add($"Twilio SID " + _twilioOptions.AccountSid);
        messages.Add($"Twilio Token " + _twilioOptions.AuthToken);
        return View(messages);
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
