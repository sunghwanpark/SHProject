using System;
using System.Collections.Generic;
using System.Collections;

namespace Photon.Hive.Plugin.SHProject
{
    public class JoinExtensionPlugin : PluginBase
    {

        public override string Name => GetType().Name;

        public override void BeforeJoin(IBeforeJoinGameCallInfo info)
        {
            PluginHost.LogDebug(string.Format("BeforeJoin {0}", info));
            base.BeforeJoin(info);
        }

        public override void OnJoin(IJoinGameCallInfo info)
        {
            PluginHost.LogDebug(string.Format("OnJoin {0}", info));

            base.OnJoin(info);

            Dictionary<byte, object> locateInfos = new Dictionary<byte, object>(PluginHost.GameActors.Count);
            foreach (var actor in PluginHost.GameActors)
            {
                locateInfos.Add((byte)actor.ActorNr, RandomLocate.GetRandomLocate());
            }

            BroadcastEvent((byte)EventCode.FirstLocate, locateInfos);
        }

        public override void BeforeSetProperties(IBeforeSetPropertiesCallInfo info)
        {
            PluginHost.LogDebug(string.Format("BeforeSetProperties {0}", info));

            base.BeforeSetProperties(info);
        }

        public override void OnCreateGame(ICreateGameCallInfo info)
        {
            PluginHost.LogDebug(string.Format("OnCreateGame {0}", info));

            base.OnCreateGame(info);
        }
    }
}
