using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter (Collision Craft){
        if (Craft.gameObject.tag=="Enemy"){
           SceneManager.LoadScene("Lose");
        }

     }
}
