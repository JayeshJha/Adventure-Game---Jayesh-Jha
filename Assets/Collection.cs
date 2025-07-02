using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Collection : MonoBehaviour
{   public int TotalCollection;
public TMP_Text CoinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter (Collision Craft){
        Debug.Log("Hello");
        if(Craft.gameObject.tag=="Collectable"){
Destroy(Craft.gameObject);
TotalCollection+=1;
CoinText.text=GameObject.FindGameObjectsWithTag("Collectable").Length.ToString()+" Remaining";
if(TotalCollection>=8 && SceneManager.GetActiveScene().name=="SampleScene"){
SceneManager.LoadScene ("Level2");}
if(TotalCollection>=5 && SceneManager.GetActiveScene().name=="Level2"){
SceneManager.LoadScene ("Win");    
}

    }
}
}


