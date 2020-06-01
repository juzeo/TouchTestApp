using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    public float[] time;
    public GameObject target;
    public GameObject temp;
    public int count = 0;
    public float final = 0;
    public float[] highScore;
    public GameObject starticon;
    public GameObject InfiText;
    public int adscount = 1;
    int ClickCount = 0;
    public int goalcount = 5;
    public Text goalCountText;
    public bool stop;
    public string LeaderBoard;
    public GameObject DetailIcon;
    public GameObject StartText;
    public GameObject Ranking;
    public GameObject Detail;
    public GameObject Okay;
    public GameObject[] targetDetail;
   // public DataSave data;
    public GameObject targetaver;
    public bool playerpre;
    public bool addchacne = true;
    public GameObject rechance;
    public bool rechancecheck;
   public void Save()
    {
       

    }
    void LoadData()
    {
        if (PlayerPrefs.HasKey("removeAds") == true)
        {
            GameObject.Find("Ads").SetActive(false);
            removeAd = true;
        }
        
        if (removeAd == false)
        {
            GameObject.Find("Ads").GetComponent<BannerAds1>().InitAd();
        }
       
        if (PlayerPrefs.HasKey("touch") == false)
        {
            for (int i = 0; i < 11; i++)
            {
                PlayerPrefs.SetFloat("highscore" + i, 999999);

            }
            PlayerPrefs.SetFloat("highscore" + 11, 0);
            PlayerPrefs.SetInt("touch", 0);
            PlayerPrefs.SetFloat("aver", 0);
        }
        else
        {
            if (PlayerPrefs.GetFloat("highscore" + 11) == 999999)
            {
                PlayerPrefs.SetFloat("highscore" + 11, 0);
            }
            for (int i = 0; i < highScore.Length; i++)
            {
                highScore[i] = PlayerPrefs.GetFloat("highscore" + i);
            }
        }
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            StartText.GetComponent<Text>().text = "시작하기";
            Ranking.GetComponent<Text>().text = "순위보기";
            Detail.GetComponent<Text>().text = "분석";
            Okay.GetComponent<Text>().text = "확인";
        }
        else
        {
            StartText.GetComponent<Text>().text = "Start";
            Ranking.GetComponent<Text>().text = "Ranking";
            Detail.GetComponent<Text>().text = "Detail";
            Okay.GetComponent<Text>().text = "Okay";
        }
        LeaderBoard = "CgkI9830ha0JEAIQBA";
        highScore = new float[12];
        for (int i = 0; i < highScore.Length; i++)
        {
            highScore[i] = PlayerPrefs.GetFloat("highscore" + i);
        }
        if (highScore[5] != 999999)
        {
            GameObject.Find("highscore").GetComponent<Text>().text = "highscore " + highScore[5] + "sec";
        }
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            GameObject.Find("aver").GetComponent<Text>().text = "현재 = " + count;
        }
        else
        {
            GameObject.Find("aver").GetComponent<Text>().text = "now = " + count;
        }
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            goalCountText.GetComponent<Text>().text = "과녁 " + goalcount + "개";
        }
        else
        {
            goalCountText.GetComponent<Text>().text = "target " + goalcount;
        }
    }
    private void Start()
    {
        LoadData();
        
        Screen.SetResolution(1440, 2960, true);
    }
    // Start is called before the first frame update
    public void Startaction()
    {
        rechancecheck = false;
        addchacne = true;
        if (removeAd == false)
        {


            GameObject.Find("Ads").GetComponent<BannerAds1>().hideBanner();
        }
        Destroy(GameObject.FindWithTag("target"));
        final = 0;
        count = 0;
        if (goalcount == 11)
        {
            stop = false;
            time = new float[1];
            time[0] = 0;
            starticon.SetActive(false);
            StartCoroutine("infinite");

        }
        else
        {      
            time = new float[goalcount];
            for (int i = 0; i < time.Length; i++)
            {
                time[i] = 0;
            }
            starticon.SetActive(false);

            testStart();
        }
       
    }
    public void reinfinite()
    {
        Destroy(GameObject.FindWithTag("target"));
        stop = false;
        StartCoroutine("infinite");

    }
    public IEnumerator infinite()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 3.0f));
        
        temp = Instantiate(target, new Vector3(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height), -1), Quaternion.identity);
        if (stop == false)
        StartCoroutine("infinite");
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        starticon.SetActive(true);
       
    }
    // 모드 올리기
    public void upGoalCount()
    {
        if (goalcount < 11)
        {
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                GameObject.Find("aver").GetComponent<Text>().text = "평균 = sec";
            }
            else
            {
                GameObject.Find("aver").GetComponent<Text>().text = "average = sec";
            }    
            goalcount++;
        }
        else
        {
            if (goalcount == 11)
            {
                if (Application.systemLanguage == SystemLanguage.Korean)
                {
                    GameObject.Find("aver").GetComponent<Text>().text = "현재 = ";
                }
                else
                {
                    GameObject.Find("aver").GetComponent<Text>().text = "now = ";
                }
            }
        }       
        changeLeaderboard();
        if(highScore[goalcount]!= 999999)
        {
            GameObject.Find("highscore").GetComponent<Text>().text = "highscore " + highScore[goalcount] + "sec";
        }   
        else
        {
            GameObject.Find("highscore").GetComponent<Text>().text = "highscore ";
        }
        if (goalcount == 11)
        {
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                goalCountText.GetComponent<Text>().text = "무한모드";
            }
            else
            {
                goalCountText.GetComponent<Text>().text = "infinite mode" ;
            }
            GameObject.Find("highscore").GetComponent<Text>().text = "highscore " + highScore[goalcount];
            InfiText.SetActive(true);
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                goalCountText.GetComponent<Text>().text = "과녁 " + goalcount + "개";
            }
            else
            {
                goalCountText.GetComponent<Text>().text = "target " + goalcount;
            }
        }
        
    }
    //모드 내리기
    public void downGoalCount()
    {
        if(goalcount>5)
        {

            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                GameObject.Find("aver").GetComponent<Text>().text = "평균 = sec";
            }
            else
            {
                GameObject.Find("aver").GetComponent<Text>().text = "average = sec";
            }
       
            goalcount--;
        }
        changeLeaderboard();
        if (highScore[goalcount] != 999999)
            GameObject.Find("highscore").GetComponent<Text>().text = "highscore " + highScore[goalcount] + "sec";
        else
        {
            GameObject.Find("highscore").GetComponent<Text>().text = "highscore ";
        }
        InfiText.SetActive(false);
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            goalCountText.GetComponent<Text>().text = "과녁 " + goalcount + "개";
        }
        else
        {
            goalCountText.GetComponent<Text>().text = "target " + goalcount;
        }
    }
    //업적보기
    public void OnShowAchivement()
    {
        Social.ShowAchievementsUI();
    }
    
    //리더보드 바꾸기
    public void changeLeaderboard()
    {
        switch (goalcount)
        {
            case 5:
                LeaderBoard = "CgkI9830ha0JEAIQBA";
                break;
            case 6:
                LeaderBoard = "CgkI9830ha0JEAIQBw";
                break;
            case 7:
                LeaderBoard = "CgkI9830ha0JEAIQCA";
                break;
            case 8:
                LeaderBoard = "CgkI9830ha0JEAIQCQ";
                break;
            case 9:
                LeaderBoard = "CgkI9830ha0JEAIQCg";
                break;
            case 10:
                LeaderBoard = "CgkI9830ha0JEAIQCw";
                break;
            case 11:
                LeaderBoard = "CgkI9830ha0JEAIQDg";
                break;

        }
    }
    //디테일버튼
    public void DetailIconButton()
    {
        starticon.SetActive(false);
        DetailIcon.SetActive(true);
        for (int i = 0; i < targetDetail.Length; i++)
        {
            targetDetail[i].SetActive(false);
        }
        for (int i = 0; i < goalcount; i++)
        {
           
            try{
                targetDetail[i].SetActive(true);
                targetDetail[i].GetComponent<Text>().text = "target" + (i + 1) + "  " + Mathf.Round(time[i] * 1000) / 1000;

            }
            catch (Exception ex)
            {

            }
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                targetaver.GetComponent<Text>().text = "전체 평균"  + " "  +PlayerPrefs.GetFloat("aver");
            }
            else
            {
                targetaver.GetComponent<Text>().text = "All Averge" + " " + PlayerPrefs.GetFloat("aver");
            }
           
        }
        adscount++;
        if (adscount % 5 == 0)
        {
            if (removeAd == false)
            {


                GameObject.Find("Ads").GetComponent<FullAdsVP>().show();
            }

        }
    }
    //디테일 닫기
    public void DetailCheckButton()
    {
        starticon.SetActive(true);
        DetailIcon.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            PlayerPrefs.Save();
            Application.Quit();
        }

    }
    //다시하기No
    public void closerechance()
    {
        rechance.SetActive(false);
        StopInfinite();
    }
    //다시하기Yes
    public void rechanceYes()
    {
        if (removeAd == false)
            GameObject.Find("Ads").GetComponent<FullAds>().Show();
    }
    //광고본후다시 시작
    public void rechancecheckpoint()
    {
        if (rechancecheck == true)
        {
            reinfinite();
        }
        else
        {
            StopInfinite();
        }
    }

    IEnumerator choiceStop()
    {
        yield return new WaitForSeconds(0.5f);
        if (addchacne == true)
        {
            addchacne = false;
            rechance.SetActive(true);
        }
        else
        {
            StopInfinite();
        }
    }
    //무한모드 종료
    public void StopInfinite()
    {
       
       
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            GameObject.Find("aver").GetComponent<Text>().text = "현재 = " + count;
        }
        else
        {
            GameObject.Find("aver").GetComponent<Text>().text = "now = " + count;
        }
        if (count >highScore[goalcount])
        {
           highScore[goalcount] = count;
            PlayerPrefs.SetFloat("highscore"+goalcount, highScore[goalcount]);
          
            
            GameObject.Find("highscore").GetComponent<Text>().text = "highscore " +highScore[goalcount];
            if (Social.localUser.authenticated == true)
            {

                Social.ReportScore((int)(GameObject.Find("Canvas").GetComponent<control>().highScore[goalcount]), LeaderBoard, (bool success) => { });
       
            }

        }
        if (highScore[goalcount] >= 100)
        {
            if (Social.localUser.authenticated == true)
            {

                Social.ReportProgress(GPGSIds.achievement_wheres_the_end, 100f, (bool success) => { });
               
            }
            if (highScore[goalcount] >= 200)
            {
                if (Social.localUser.authenticated == true)
                {

                    Social.ReportProgress(GPGSIds.achievement_are_you_machine, 100f, (bool success) => { });
                 
                }
            }
        }
        Destroy(GameObject.FindWithTag("target"));
        StartCoroutine("wait");
        Destroy(GameObject.FindWithTag("target"));
        if (removeAd == false)
        {


            adscount++;
            if (adscount % 5 == 0)
            {

                GameObject.Find("Ads").GetComponent<FullAdsVP>().show();

            }
            GameObject.Find("Ads").GetComponent<BannerAds1>().showBanner();
        }
    }

    void DoubleClick()
    {
        ClickCount = 0;
    }
    public void updatetime(float temp)
    {
        if (goalcount == 11)
        {
            if (stop == false)
            {

                time[0] = temp;
                if (temp > 1)
                {
                    stop = true;
                    StartCoroutine("choiceStop");
                }
                count++;
            }
           
        }
        else
        {
            for (int i = 0; i < time.Length; i++)
            {
                if (time[i] == 0)
                {
                    PlayerPrefs.SetFloat("aver", ((((PlayerPrefs.GetFloat("aver") * PlayerPrefs.GetInt("touch")) + temp) / (PlayerPrefs.GetInt("touch") + 1))*1000)/1000);
                    PlayerPrefs.SetInt("touch", PlayerPrefs.GetInt("touch") + 1);
                    
                    
                    time[i] = temp;
                    final += temp;
                    break;
                }

            }
            if (time[goalcount - 1] != 0)
            {
                StopStart();
            }
        }
       
    }
    public void StopStart()
    {

        float tempscore = Mathf.Round(final/goalcount*1000)/1000;
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            GameObject.Find("aver").GetComponent<Text>().text = "평균 = " + tempscore + "sec";
        }
        else
        {
            GameObject.Find("aver").GetComponent<Text>().text = "average = "+ tempscore + "sec";
        }
       
        if (tempscore < highScore[goalcount])
        {
           highScore[goalcount] = tempscore;
            PlayerPrefs.SetFloat("highscore" + goalcount, highScore[goalcount]);
            
        
            GameObject.Find("highscore").GetComponent<Text>().text = "highscore " + highScore[goalcount] + "sec";
            if (Social.localUser.authenticated == true)
            {
               
                Social.ReportScore((int)(GameObject.Find("Canvas").GetComponent<control>().highScore[goalcount] * 1000f), LeaderBoard, (bool success) => { });
               
            }

        }
        if (highScore[goalcount] <= 0.5f)
        {
            if (Social.localUser.authenticated == true)
            {

                Social.ReportProgress(GPGSIds.achievement_fast_fast_fast, 100f, (bool success) => { });
               
            }
            if (highScore[goalcount] <= 0.4f)
            {
                if (Social.localUser.authenticated == true)
                {

                    Social.ReportProgress(GPGSIds.achievement_are_you_sure_youre_a_person, 100f, (bool success) => { });
                  
                }
            }
            if (highScore[5] <= 0.5f && highScore[6] <= 0.5f && highScore[7] <= 0.5f && highScore[8] <= 0.5f && highScore[9] <= 0.5f && highScore[10] <= 0.5f)
            {
                if (Social.localUser.authenticated == true)
                {

                    Social.ReportProgress(GPGSIds.achievement_thank_you_for_loving_our_application, 100f, (bool success) => { });
                  
                }
            }
        }
        StartCoroutine("wait");
        if (removeAd == false)
        {


            adscount++;
            if (adscount % 5 == 0)
            {

                GameObject.Find("Ads").GetComponent<FullAdsVP>().show();

            }
            GameObject.Find("Ads").GetComponent<BannerAds1>().showBanner();

        }
    }

  
    public void testStart()
    {
        StartCoroutine("test");


    }
    public IEnumerator test()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 3.0f));
        count++;
        temp = Instantiate(target, new Vector3(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height),-1), Quaternion.identity);
        //temp.transform.parent = GameObject.Find("Canvas").gameObject.transform;
        if (count == goalcount)
            yield break;
        StartCoroutine("test");
        
    }

    bool removeAd;
   public void removeAds()
    {
        GameObject.Find("Ads").SetActive(false);
        removeAd = true;
        PlayerPrefs.SetInt("removeAds", 1);
        PlayerPrefs.Save();
    }


}
