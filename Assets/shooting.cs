using UnityEngine;

public class shooting : MonoBehaviour
{
    public Animator Anim;
    public GameObject Projectile;
    public Transform Barrel;
    public float ShootingFrequency=0.5f;
    private float ctime;
    public float BulletSpeed=7;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ctime>=ShootingFrequency){
            if(Input.GetMouseButton(0)){
            Anim.SetTrigger("shoot");
            ctime=0;
            GameObject Clone=Instantiate(Projectile,Barrel.position,Barrel.rotation);
            Clone.GetComponent<Rigidbody>().AddForce(Barrel.forward*BulletSpeed,ForceMode.Impulse);

        }
        }
       else{
        ctime+=Time.deltaTime;
       }
    }
}
