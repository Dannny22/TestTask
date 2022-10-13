using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public float dist;
    NavMeshAgent nav;
    public float radius = 10;
    public float HP = 100f;
    public bool Dead;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Player.transform.position, transform.position);

        if (dist > radius)
        {
            nav.enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("idle");
        }
        else if (dist < radius)
        {
            nav.enabled = true;
            nav.SetDestination(Player.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("run");
        }

        if (dist < 1)
        {
            nav.enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("attack");
        }

        if (HP <= 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("dead");
            nav.enabled = false;
            Dead = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerDamage")
        {
           HP = HP - 25;
        }
    }
}
