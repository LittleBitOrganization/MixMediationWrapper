using System;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Environment.Ads;
using MixNameSpace;

namespace DefaultNamespace
{
    public class MixSdkInitializer : IMediationNetworkInitializer
    {
        public event Action OnMediationInitialized;
        
        private readonly AdsConfig _config;
        public MixSdkInitializer(AdsConfig config) => _config = config;
        public bool IsInitialized { get; private set; }

        public void Initialize()
        {
            MixMain.instance.OnMaxInit += ()=>
            {
                IsInitialized = true;
                OnMediationInitialized?.Invoke();
            };
        }
    }
}