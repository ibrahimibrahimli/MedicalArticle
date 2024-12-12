using Microsoft.Extensions.Localization;
using System.Reflection;

namespace MedicalArticles.Services
{
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            AssemblyName assemblyName = new(assemblyName: type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create(nameof(SharedResource), assemblyName.Name);
        }

        public LocalizedString getKey(string key)
        {
            return _localizer.GetString(key);
        }
    }
}
