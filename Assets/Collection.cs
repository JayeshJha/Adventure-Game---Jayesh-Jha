using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using PlayFab.ClientModels;
using System.Collections.Generic;
using PlayFab;
public class Collection: MonoBehaviour {
  public int TotalCollection;
  public TMP_Text CoinText;
  public float ctime;
  public TMP_Text TimerText;
  public int KillCount;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()

  {
    TimerText.text = "00:00";
    var request = new LoginWithCustomIDRequest {
      CustomId = SystemInfo.deviceUniqueIdentifier,
        CreateAccount = true
    };
    PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnFailure);
    
  }

  void OnSuccess(LoginResult Result) {
    Debug.Log("Login Worked");
  }
  void OnFailure(PlayFabError Result) {
    Debug.LogError("PlayFab login failed: " + Result.GenerateErrorReport());
  }
  // Update is called once per frame
  void Update() {
    ctime += Time.deltaTime;
    int minute = (int) ctime / 60;
    int second = (int) ctime % 60;
    TimerText.text = minute.ToString() + ":" + second.ToString();
  }
  void OnCollisionEnter(Collision Craft) {
    if (Craft.gameObject.tag == "Collectable") {
      Destroy(Craft.gameObject);
      TotalCollection += 1;

      int remaining = GameObject.FindGameObjectsWithTag("Collectable").Length - 1;
      CoinText.text = remaining.ToString() + " Remaining";
      if (TotalCollection >= 8 && SceneManager.GetActiveScene().name == "SampleScene") {
        points();
        Invoke("Level1", 3);
      }
      if (TotalCollection >= 5 && SceneManager.GetActiveScene().name == "Level2") {
        points();
        Invoke("Level2", 3);

      }

    }
  }
  void Level1() {
    SceneManager.LoadScene("Level2");
    Debug.Log("Uploading Stats");
  }
  void Level2() {
    SceneManager.LoadScene("Win");
    Debug.Log("Uploading Stat");
  }
  void points() {
    string TitleHighScore = "";
    if (SceneManager.GetActiveScene().name == "SampleScene") {
      TitleHighScore = "HighScoreLvl1";
    }
    if (SceneManager.GetActiveScene().name == "Level2") {
      TitleHighScore = "HighScoreLvl2";
    }
    PlayFabClientAPI.GetPlayerStatistics(new GetPlayerStatisticsRequest(),
      result => {
        foreach(var stat in result.Statistics) {
          if (stat.StatisticName == TitleHighScore) {
            int HighScore = stat.Value;
            if ((int) ctime < HighScore) {
              var request2 = new UpdatePlayerStatisticsRequest {
                Statistics = new List < StatisticUpdate > {
                  new StatisticUpdate {
                    StatisticName = TitleHighScore,
                      Value = (int) ctime
                  }
                }
              };
              var request3 = new UpdatePlayerStatisticsRequest {
                Statistics = new List < StatisticUpdate > {
                  new StatisticUpdate {
                    StatisticName = "EnemiesKilled",
                      Value = KillCount
                  }
                }};

                PlayFabClientAPI.UpdatePlayerStatistics(request2,
                  result => Debug.Log("Score submitted!"),
                  error => Debug.LogError("Failed to submit score: " + error.GenerateErrorReport()));
                PlayFabClientAPI.UpdatePlayerStatistics(request3,
                  result => Debug.Log("Score submitted!"),
                  error => Debug.LogError("Failed to submit score: " + error.GenerateErrorReport()));
              };
            }
          }
      }
      

      ,
      error => {
        Debug.LogError(error.GenerateErrorReport());
      }
);

  }
}
