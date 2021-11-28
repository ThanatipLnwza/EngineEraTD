using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    private string gameID = "4425086";
    public bool testMode = true;
    private string placement = "Rewarded_Android";

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, testMode);
        //ShowBannerAd("Banner_Android");
    }

    public void ShowAd(string placement)
    {
        Advertisement.Show(placement);
    }

    public void ShowBannerAd(string placement)
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placement);
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("This : " + placementId + " Finished!");

        if (showResult == ShowResult.Finished)
        {
            Debug.Log("Ads Reward++");
        }
        else if (showResult == ShowResult.Failed)
        {
            //Oh no!
        }
    }
}
