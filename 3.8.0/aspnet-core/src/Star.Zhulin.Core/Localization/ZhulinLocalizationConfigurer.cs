using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Star.Zhulin.Localization
{
    public static class ZhulinLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ZhulinConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ZhulinLocalizationConfigurer).GetAssembly(),
                        "Star.Zhulin.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
