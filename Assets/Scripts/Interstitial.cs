using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using GoogleMobileAds.Api;


public class Interstitial : MonoBehaviour
{
    public InterstitialAd interstitial;

    public void ShowInterstitialAd() {
        MobileAds.Initialize(initstatus => { });

        RequestInterstitial();

        if(interstitial.IsLoaded()){
            interstitial.Show();
        }
    }

    private void RequestInterstitial() {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdClosed_reset(object sender, EventArgs args){
        SceneManager.LoadScene(2);
        this.interstitial.OnAdClosed -= HandleOnAdClosed_reset;
    }

    public void HandleOnAdClosed_menu(object sender, EventArgs args){
        SceneManager.LoadScene(1);
        this.interstitial.OnAdClosed -= HandleOnAdClosed_menu;
    }
}
