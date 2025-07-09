using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Collection : MonoBehaviour
{   public int TotalCollection;
public TMP_Text CoinText;
public float ctime;
public TMP_Text TimerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
  
  {
        TimerText.text="00:00";
    }

    // Update is called once per frame
    void Update()
    {
        ctime += Time.deltaTime;
        int minute = (int)ctime/60;
        int second = (int)ctime%60;
        TimerText.text=minute.ToString()+":"+second.ToString();
    }
    void OnCollisionEnter (Collision Craft){
        Debug.Log("Hello");
        if(Craft.gameObject.tag=="Collectable"){
Destroy(Craft.gameObject);
TotalCollection+=1;

int remaining=GameObject.FindGameObjectsWithTag("Collectable").Length-1;
CoinText.text=remaining.ToString()+" Remaining";
if(TotalCollection>=8 && SceneManager.GetActiveScene().name=="SampleScene"){
SceneManager.LoadScene ("Level2");}
if(TotalCollection>=5 && SceneManager.GetActiveScene().name=="Level2"){
SceneManager.LoadScene ("Win");    
}


    }
}
}


