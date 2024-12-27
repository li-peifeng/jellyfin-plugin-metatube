using System.ComponentModel;

namespace Jellyfin.Plugin.MetaTube.Translation;

public enum TranslationEngine
{
    [Description("百度")]
    Baidu,

    [Description("谷歌")]
    Google,

    [Description("谷歌 (免费)")]
    GoogleFree,

    [Description("DeepL (免费)")]
    DeepL,

    [Description("OpenAI")]
    OpenAi
}