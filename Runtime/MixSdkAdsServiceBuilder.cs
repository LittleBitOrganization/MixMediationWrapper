using System;
using DefaultNamespace;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Environment.Ads;
using MixNameSpace;

namespace LittleBitGames.Ads
{
    public class MixSdkAdsServiceBuilder : IAdsServiceBuilder
    {
        private readonly MixSdkAdUnitsFactory _adUnitsFactory;
        private readonly MixSdkInitializer _initializer;

        private IAdUnit _inter, _rewarded;
        private AdsConfig _adsConfig;

        public IMediationNetworkInitializer Initializer => _initializer;

        public MixSdkAdsServiceBuilder(AdsConfig adsConfig, ICoroutineRunner coroutineRunner)
        {
            _adsConfig = adsConfig;
            _adUnitsFactory = new MixSdkAdUnitsFactory(coroutineRunner, adsConfig);
            _initializer = new MixSdkInitializer(adsConfig);
        }

        public IAdsService QuickBuild()
        {
            BuildInterAdUnit();
            BuildRewardedAdUnit();

            return GetResult();
        }

        public void BuildInterAdUnit() =>
            _inter = _adUnitsFactory.CreateInterAdUnit();

        public void BuildRewardedAdUnit() =>
            _rewarded = _adUnitsFactory.CreateRewardedAdUnit();

        public IAdsService GetResult() => new AdsService(_initializer, _inter, _rewarded);
    }
}