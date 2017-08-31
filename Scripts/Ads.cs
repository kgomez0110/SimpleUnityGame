using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Ads : MonoBehaviour {

	private void RequestBanner(){
		#if UNITY_EDITOR
			string adUnitId = "unused";
		#elif UNITY_ANDROID	
			string adUnitId = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
		#elif UNITY_IPHONE
			string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
			string adUnitId = "unexpeceted_platform";
		#endif

		BannerView bannerView = new BannerView (adUnitId, AdSize.Banner, AdPosition.Top);
		AdRequest request = new AdRequest.Builder ().Build ();
		bannerView.LoadAd (request);
	}
	
		void Start(){
		RequestBanner ();
	}
}
