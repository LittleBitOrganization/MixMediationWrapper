using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using MixNameSpace;

namespace DefaultNamespace
{
    public class MixSdkInterAd : AdUnitLogic
    {
        private readonly IAdUnitKey _key;
        
        public MixSdkInterAd(IAdUnitKey key, ICoroutineRunner coroutineRunner) : 
            base(key, new MixSdkInterEvents(), coroutineRunner)
        {
            _key = key;
        }

        protected override bool IsAdReady() => MixMaxManager.instance.mixInterstitialAd.IsInterstitialReady();

        protected override void ShowAd()
        {
            MixMaxManager.instance.mixInterstitialAd.ShowInterstitial(null);
        }

        public override void Load()
        {
            //Loading logic in Mix
        }
    }
}