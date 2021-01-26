using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace RoyalEstate.Localization
{
    public static class RoyalEstateLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(RoyalEstateConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(RoyalEstateLocalizationConfigurer).GetAssembly(),
                        "RoyalEstate.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
