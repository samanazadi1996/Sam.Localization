using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Globalization;
using System.Linq;

namespace Sam.Localization.WebApi.Infrastructure.LocalizationServicesRegistration
{
    public static class LocalizationServicRegistration
    {
        public static IApplicationBuilder UseSamLocalization(this IApplicationBuilder app)
        {
            var samLocationOptions = app.ApplicationServices.GetRequiredService<SamLocationOptions>();

            var supportedCultures = samLocationOptions.SupportedCultures.Select(p => new CultureInfo(p)).ToList();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(samLocationOptions.DefaultRequestCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseRequestLocalization();

            return app;
        }

        public static IMvcBuilder AddSamLocalization(this IMvcBuilder builder, Action<SamLocationOptions> action)
        {
            SamLocationOptions samLocationOptions = new();

            action(samLocationOptions);

            builder.Services.AddSingleton(samLocationOptions);

            builder.Services.AddLocalization(options => options.ResourcesPath = samLocationOptions.ResourcesPath);

            builder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = samLocationOptions.SupportedCultures.Select(p => new CultureInfo(p)).ToList();

                options.DefaultRequestCulture = new RequestCulture(samLocationOptions.DefaultRequestCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            return builder;
        }

        public static void AddSamLocalization(this SwaggerGenOptions options)
        {
            options.OperationFilter<LocalizationParameterOperationFilter>();
        }
    }
}
