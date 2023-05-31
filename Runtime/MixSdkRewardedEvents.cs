using System;
using MixNameSpace;

namespace LittleBitGames.Ads.AdUnits
{
    public class MixSdkRewardedEvents : IAdUnitEvents
    {
        public event Action<string, IAdInfo> OnAdRevenuePaid;
        public event Action<string, IAdInfo> OnAdLoaded;
        public event Action<string, IAdErrorInfo> OnAdLoadFailed;
        public event Action<string, IAdInfo> OnAdFinished;
        public event Action<string, IAdInfo> OnAdClicked;
        public event Action<string, IAdInfo> OnAdHidden;
        public event Action<string, IAdErrorInfo, IAdInfo> OnAdDisplayFailed;

        public MixSdkRewardedEvents()
        {
            MixMaxManager.instance.mixRewardedAd.onRewardedAdRevenuePaidEvent += (s, info) => OnAdRevenuePaid?.Invoke(s, new AdInfo(info));
            MixMaxManager.instance.mixRewardedAd.onAdLoadedEvent += (s, info) => OnAdLoaded?.Invoke(s, new AdInfo(info));
            MixMaxManager.instance.mixRewardedAd.onAdLoadFailedEvent += (s, info) => OnAdLoadFailed?.Invoke(s, new AdErrorInfo(info));
            MixMaxManager.instance.mixRewardedAd.onAdReceivedRewardEvent += (s, info) => OnAdFinished?.Invoke(s, null);
            MixMaxManager.instance.mixRewardedAd.onAdClickedEvent += (s, info) => OnAdClicked?.Invoke(s, new AdInfo(info));
            MixMaxManager.instance.mixRewardedAd.onAdHiddenEvent += (s, info) => OnAdHidden?.Invoke(s, new AdInfo(info));
            MixMaxManager.instance.mixRewardedAd.onAdDisplayFailedEvent += (s, error, info) => OnAdDisplayFailed?.Invoke(s, new AdErrorInfo(error), new AdInfo(info));
        }
    }
}