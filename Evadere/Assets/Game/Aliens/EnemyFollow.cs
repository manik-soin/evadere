using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent enemy;
    private GameObject Player;
    public float attackRange;
    public bool attack;
    void Start()
    {
        attack = false;
        Player = GameObject.FindWithTag("Player");
        print("Player found at "+Player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        // print("Player's Position according to Aliens: "+Player.transform.position);
        if (distance <= attackRange)
        {
            print("In attack range!!!");
            attack = true;
        }
        if (attack == true)
        {
            enemy.SetDestination(Player.transform.position);
        } else
        {
            float dx = Random.Range(-10,10);
            float dz = Random.Range(-10,10);
            float x = transform.position.x + dx;
            float z = transform.position.z + dz;
            enemy.SetDestination(new Vector3(x,0,z));
        }
    }
}
