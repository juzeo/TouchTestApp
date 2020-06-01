using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAdsVP : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-5128399712273383/8217099236";
    private string realAd = "ca-app-pub-5128399712273383/3817864815";
    private string testAd = "ca-app-pub-3940256099942544/8691691433";
    public InterstitialAd screenAd;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(

             (initStatus) => InitAd()

             );
    }
  

    public void InitAd()
    {
        screenAd = new InterstitialAd(realAd);
        AdRequest request = new AdRequest.Builder().Build();
        screenAd.LoadAd(request);

    }
    public void show()
    {
        
        StartCoroutine("ShowScreenAd");
        InitAd();
    }
    public IEnumerator ShowScreenAd()
    {
        while (!screenAd.IsLoaded())
        {
           
            yield return null;
        }

        screenAd.Show();
    }
}
