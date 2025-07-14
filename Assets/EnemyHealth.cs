using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
        if (Craft.gameObject.tag=="Projectile"){
            GameObject.Find("Player").GetComponent<Collection>().KillCount++;
            Destroy(Craft.gameObject);
        }

     }
}
