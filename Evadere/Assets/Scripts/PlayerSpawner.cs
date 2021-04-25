using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public float x;
    public float y;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(x,0,y);
        Instantiate(player,transform.position,player.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
