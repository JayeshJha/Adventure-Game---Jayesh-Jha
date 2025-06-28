using UnityEngine;
using UnityEngine.SceneManagement;
public class Collection : MonoBehaviour
{   public int TotalCollection;
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
if(TotalCollection>=8){
SceneManager.LoadScene ("Win");}
    }
}
}


