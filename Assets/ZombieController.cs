using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;
    float hp;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player.position);
        
        //transform.Translate(Vector3.forward * Time.deltaTime);

        agent.destination = player.position;
    }
    public void ReceiveDamage(int ammount)
    {
        hp -= ammount;
        if (hp <= 0)
            Die();
         
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
