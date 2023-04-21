using System;
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
        RaycastHit hit;
        //wektor prowadz¹cy od zombiaka do gracza
        Vector3 playerVector = player.position - transform.position;
        //testowy raycast
        Debug.DrawRay(transform.position, playerVector, Color.yellow);
        //"wzrok" zombiaka
        if(Physics.Raycast(transform.position, playerVector, out hit))
        {
            Debug.Log("Widzê: " + hit.transform.gameObject.name);
        }

        //transform.LookAt(player.position);

        //transform.Translate(Vector3.forward * Time.deltaTime);
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            agent.destination = player.position;
            agent.isStopped = false;
        } else
        {
            agent.isStopped = true;
        }
            
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
