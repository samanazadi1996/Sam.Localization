﻿namespace Sam.Localization.WebApi.Infrastructure.LocalizationServicesRegistration
{
    public class SamLocationOptions
    {
        public string ResourcesPath { get; set; }
        public string[] SupportedCultures { get; set; }
        public string DefaultRequestCulture { get; set; }
    }
}
