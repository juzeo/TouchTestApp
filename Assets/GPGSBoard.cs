using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class GPGSBoard : MonoBehaviour
{
    public void Awake()
    {
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool bSuccess) =>{ });
        }
    public void LeaderBoard()
    {
        if (Social.localUser.authenticated == false)
        {
            Awake();
        }

        Social.Active.ShowLeaderboardUI();
    }



    }