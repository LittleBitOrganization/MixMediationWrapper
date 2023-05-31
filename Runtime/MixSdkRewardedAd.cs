using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using MixNameSpace;

namespace DefaultNamespace
{
    public class MixSdkRewardedAd : AdUnitLogic
    {
        private readonly IAdUnitKey _key;
        
        public MixSdkRewardedAd(IAdUnitKey key, ICoroutineRunner coroutineRunner) :
            base(key, new MixSdkRewardedEvents(), coroutineRunner)
        {
            _key = key;
        }

        protected override bool IsAdReady() => MixMaxManager.instance.mixRewardedAd.IsRewardedAdReady();

        protected override void ShowAd()
        {
            MixMaxManager.instance.mixRewardedAd.ShowRewardedAd(null, null);
        }

        public override void Load()
        {
            //Loading logic in Mix
        }
    }
}