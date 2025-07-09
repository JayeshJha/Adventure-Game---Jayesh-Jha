using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
public class PlayFabTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request,OnSuccess,OnFailure);
        
    }
    void points(){
        var request2 = new UpdatePlayerStatisticsRequest {
        Statistics = new List<StatisticUpdate> {
            new StatisticUpdate {
                StatisticName = "HighScore",
                Value = 10
            }
        }
    };
   PlayFabClientAPI.UpdatePlayerStatistics(request2,
        result => Debug.Log("Score submitted!"),
        error => Debug.LogError("Failed to submit score: " + error.GenerateErrorReport()));

    }
    void OnSuccess(LoginResult Result){
        Debug.Log("Login Worked");
    }
void OnFailure(PlayFabError Result){
       Debug.LogError("PlayFab login failed: " + Result.GenerateErrorReport());
}
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            points();
        }
    }
}
