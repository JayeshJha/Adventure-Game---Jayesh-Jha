using UnityEngine;

using UnityEngine.AI;
public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent Agent;
    private GameObject Player;
    public Animator Anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agent=GetComponent < NavMeshAgent > ();
        Player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(Player.transform.position);
        Anim.SetFloat("Speed",Agent.velocity.magnitude);
    }
}
