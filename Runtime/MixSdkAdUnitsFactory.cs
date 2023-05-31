using System;
using DefaultNamespace;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Configs;

namespace LittleBitGames.Ads
{
    internal class MixSdkAdUnitsFactory
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public MixSdkAdUnitsFactory(ICoroutineRunner coroutineRunner, AdsConfig adsConfig)
        {
            _coroutineRunner = coroutineRunner;
        }

        //Id takes from mix logic
        public IAdUnit CreateInterAdUnit() =>
            new MixSdkInterAd(null, _coroutineRunner);

        public IAdUnit CreateRewardedAdUnit() =>
            new MixSdkRewardedAd(null, _coroutineRunner);
    }
}