using System.Collections.Generic;
using ExitGames.Logging;

namespace Photon.Hive.Plugin.SHProject
{
    public class PluginFactory : IPluginFactory
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        public IGamePlugin Create(IPluginHost gameHost, string pluginName, Dictionary<string, string> config, out string errorMsg)
        {
            gameHost = new PluginHostWrapper(gameHost);
            gameHost.TryRegisterType(typeof(Locate), (byte)'Z', Locate.Serialize, Locate.Deserialize);

            IGamePlugin plugin = null;
            if (pluginName.Equals("JoinExtensionPlugin"))
                plugin = new JoinExtensionPlugin();

            if (plugin != null && plugin.SetupInstance(gameHost, config, out errorMsg))
                return plugin;

            errorMsg = string.Empty;
            return null;
        }
    }
}
