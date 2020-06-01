using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerAds1 : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-5128399712273383/8217099236";
    private string realAd = "ca-app-pub-5128399712273383/8217099236";
    private string testAd = "ca-app-pub-3940256099942544/6300978111";
    private readonly string test_deviceID = "3DCDF03C9AF66E7B";
    public BannerView bannerview;

   public void Start()
    {
        MobileAds.Initialize(

            (initStatus) => InitAd()
            

            );
    }
    public void InitAd()
    {
        bannerview = new BannerView(realAd, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerview.LoadAd(request);
  
        showBanner();
    }
    public void showBanner()
    {
        try
        {
            bannerview.Show();
          
        }
        catch
        {
          
        }

    }
    public void hideBanner()
    {
        try{
            bannerview.Hide();
         
        }
        catch
        {
          
        }
        

        
    }
}