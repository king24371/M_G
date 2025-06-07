using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAdManager : MonoBehaviour
{
    public static GoogleAdManager inst;

    //public string AppID;

    public string FullScreenAd_ID;
    private InterstitialAd FullScreenAd;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else
            Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        RequestFullScreenAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestFullScreenAd()
    {
        //預設Google全螢幕廣告模式
        FullScreenAd = new InterstitialAd(FullScreenAd_ID);
        //create the request to acces AD
        AdRequest GoogleAdRequest = new AdRequest.Builder().Build();
        FullScreenAd.LoadAd(GoogleAdRequest);
    }

    public void ShowFullScreenAd()
    {
        if (FullScreenAd.IsLoaded())
        {
            FullScreenAd.Show();
        }
        else
            print("Full screen AD not loaded!!");
    }
}
