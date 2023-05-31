using System;
using System.Collections.Generic;
using AppLovinMax;
using LittleBitGames.Ads;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Collections.Extensions;
using LittleBitGames.Environment.Ads;
using LittleBitGames.Environment.Events;
using MixNameSpace;
using UnityEngine.Scripting;

namespace DefaultNamespace
{
    public class MixSdkAnalytics : IMediationNetworkAnalytics
    {
        private const string SdkSourceName = "applovin_max_sdk";
        private const string Currency = "USD";

        private readonly IReadOnlyList<IAdUnit> _adUnits;

        public event Action<IDataEventAdImpression, AdType> OnAdRevenuePaidEvent;

        [Preserve]
        public MixSdkAnalytics(IAdsService adsService)
        {
            _adUnits = adsService.AdUnits;
            
            if (!_adUnits.Validate()) ThrowException();
            
            adsService.Initializer.OnMediationInitialized += Subscribe;
        }

        private static void ThrowException() =>
            throw new Exception("Invalid list of ad units was provided to MaxSdkAnalytics");

        private void Subscribe()
        {
            MixMaxManager.instance.mixRewardedAd.onRewardedAdRevenuePaidEvent += (delegate(string s, MaxSdkBase.AdInfo info)
            {
                OnAdRevenuePaid(s, info, AdType.Rewarded);
            });
            
            MixMaxManager.instance.mixInterstitialAd.onInterAdRevenuePaidEvent += (delegate(string s, MaxSdkBase.AdInfo info)
            {
                OnAdRevenuePaid(s, info, AdType.Inter);
            });
            
            MixMaxManager.instance.mixBannerAd.onBannerAdRevenuePaidEvent += (delegate(string s, MaxSdkBase.AdInfo info)
            {
                OnAdRevenuePaid(s, info, AdType.Banner);
            });
        }
        

        private void OnAdRevenuePaid(string adUnitId, MaxSdkBase.AdInfo adInfo, AdType adType)
        {
            var ad = _adUnits.FindByKey(adUnitId);
            
            var adImpressionEvent = new DataEventAdImpression(
                new SdkSource(SdkSourceName),
                adInfo.NetworkName,
                adInfo.AdFormat,
                ad.UnitPlace.StringValue,
                Currency,
                adInfo.Revenue);

            OnAdRevenuePaidEvent?.Invoke(adImpressionEvent, adType);
        }
    }
}