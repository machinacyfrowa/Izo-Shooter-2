using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;

    int hp;
    Vector2 inputVector;
    Rigidbody rb;
    Transform bulletSpawn;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        inputVector = Vector2.zero;    
        rb = GetComponent<Rigidbody>();
        bulletSpawn = transform.Find("BulletSpawn");
        agent = GetComponent<NavMeshAgent>();
        hp = 10;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //obrót z klawiatury
        Vector3 rotation = new Vector3(0, inputVector.x, 0);
        transform.Rotate(rotation);
        //przesuniêcie przy u¿yciu navmesh
        if (inputVector.y > 0)
        {
            agent.isStopped = false;
            agent.destination = transform.position + transform.forward;
        }
        if (inputVector.y == 0)
        {
            agent.isStopped = true;
        }
    }
    private void FixedUpdate()
    {
        //if(inputVector.y == 0)
        //{
        //    //nie trzymamy wciœniêtego "w" ani "s"
        //    rb.velocity = Vector3.zero;
        //} 
        //else
        //{
        //    //metoda z fizyk¹
        //    //wez kierunek do przodu wzglêdem postaci i przemnó¿ przez wychylenie kontrolera
        //    Vector3 movement = transform.forward * inputVector.y;
        //    rb.AddForce(movement, ForceMode.Impulse);
        //}
        //if(inputVector.x == 0)
        //{
        //    rb.angularVelocity = Vector3.zero;
        //} 
        //else
        //{
        //    Vector3 rotation = transform.up * inputVector.x;
        //    rb.AddTorque(rotation, ForceMode.Impulse);
        //}
        
    }

    void OnMove(InputValue inputValue)
    {
        inputVector = inputValue.Get<Vector2>();
    }
    void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10, ForceMode.Impulse);
        Destroy(bullet, 5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.ToString());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zombie"))
        {
            hp--;
        }
        if (other.CompareTag("Heal"))
        {
            hp = 10;
        }
    }

}
