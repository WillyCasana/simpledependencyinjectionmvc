﻿using WazeCredit.Utility.AppSettingsClasses;

namespace WazeCredit.Utility.DI_Config;

public static class DI_AppSettingsConfig
{
    public static IServiceCollection AddAppSettingsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<WazeForecastSettings>(configuration.GetSection("WazeForecast"));
        services.Configure<StripeSettings>(configuration.GetSection("Stripe"));
        services.Configure<TwilioSettings>(configuration.GetSection("Twilio"));
        services.Configure<SendgridSettings>(configuration.GetSection("SendGrid"));
        return services;
    }
}
