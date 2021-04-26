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
    private float timer;
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        attack = false;
        Player = GameObject.FindWithTag("Player");
        print("Player found at "+Player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
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
            if (timer >= 5){
                Roam();
                timer = 0;
            }
        }
    }

    void Roam()
    {
        float dx = Random.Range(-20,20);
        float dz = Random.Range(-20,20);
        float x = transform.position.x + dx;
        float z = transform.position.z + dz;
        enemy.SetDestination(new Vector3(x,0,z));
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            anim.SetTrigger("isAttacking");
            anim.SetBool("isCrawling",true);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player"){
            anim.SetTrigger("isAttacking");
            anim.SetBool("isCrawling",true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player"){
            anim.SetTrigger("isAttacking");
            anim.SetBool("isCrawling",true);
        }
    }

}
