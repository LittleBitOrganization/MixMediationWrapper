using System;
using MixNameSpace;

namespace LittleBitGames.Ads.AdUnits
{
    public class MixSdkInterEvents : IAdUnitEvents
    {
        public event Action<string, IAdInfo> OnAdRevenuePaid;
        public event Action<string, IAdInfo> OnAdLoaded;
        public event Action<string, IAdErrorInfo> OnAdLoadFailed;
        public event Action<string, IAdInfo> OnAdFinished;
        public event Action<string, IAdInfo> OnAdClicked;
        public event Action<string, IAdInfo> OnAdHidden;
        public event Action<string, IAdErrorInfo, IAdInfo> OnAdDisplayFailed;

        public MixSdkInterEvents()
        {
            MixMaxManager.instance.mixInterstitialAd.onAdClickedEvent += (s, info) => OnAdClicked?.Invoke(s, new AdInfo(info));
            MixMaxManager.instance.mixInterstitialAd.onAdHiddenEvent += (s, info) => OnAdHidden?.Invoke(s, new AdInfo(info));
            MixMaxManager.instance.mixInterstitialAd.onAdDisplayFailedEvent +=
                (s, error, info) => OnAdDisplayFailed?.Invoke(s, new AdErrorInfo(error), new AdInfo(info));
            
            MixMaxManager.instance.mixInterstitialAd.onAdHiddenEvent += (s, info) =>
            {
#if UNITY_EDITOR
                OnAdFinished?.Invoke(s, new AdInfo(info));
#endif
            };
            
            MixMaxManager.instance.mixInterstitialAd.onInterAdRevenuePaidEvent += (s, info) =>
            {
                OnAdRevenuePaid?.Invoke(s, new AdInfo(info));
                OnAdFinished?.Invoke(s, new AdInfo(info));
            };
        }
        
    }
}