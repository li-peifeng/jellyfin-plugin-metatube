using Jellyfin.Plugin.MetaTube.Configuration;
using MediaBrowser.Common.Plugins;
#if __EMBY__
using MediaBrowser.Common;
using MediaBrowser.Controller.Plugins;
using MediaBrowser.Model.Drawing;

#else
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using MediaBrowser.Common.Configuration;
#endif

namespace Jellyfin.Plugin.MetaTube;

#if __EMBY__
public class Plugin : BasePluginSimpleUI<PluginConfiguration>, IHasThumbImage
{
    public Plugin(IApplicationHost applicationHost) : base(applicationHost)
    {
        Instance = this;
    }
#else
public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
{
    public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) : base(applicationPaths,
        xmlSerializer)
    {
        Instance = this;
    }
#endif

    public override string Name => "MetaTube";

    public override string Description => "Jellyfin/Emby 中文版 MetaTube 插件";

    public override Guid Id => Guid.Parse("01cc53ec-c415-4108-bbd4-a684a9801a32");

    public static Plugin Instance { get; private set; }

#if !__EMBY__
    public IEnumerable<PluginPageInfo> GetPages()
    {
        return new[]
        {
            new PluginPageInfo
            {
                Name = Name,
                EmbeddedResourcePath = $"{GetType().Namespace}.Configuration.configPage.html"
            }
        };
    }
#endif

#if __EMBY__
    public PluginConfiguration Configuration => GetOptions();

    public Stream GetThumbImage()
    {
        return GetType().Assembly.GetManifestResourceStream($"{GetType().Namespace}.thumb.png");
    }

    public ImageFormat ThumbImageFormat => ImageFormat.Png;
#endif
}