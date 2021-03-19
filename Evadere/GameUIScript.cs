using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUIScript : MonoBehaviour
{
    //copy the relavent content below, and place it in the monster script /or the energy source script that can gain energy(?)
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    
    public static int EN = 0;
    public static int life = 5;

    /* Setting on the monster(?)*/
    
    
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        GUI.Label(new Rect(100, 0, 400, 400), "Energy Source: " + EN);
        GUI.Label(new Rect(100, 20, 400, 400), "Life: " + life);
    }

    //place it in the monster script
    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;
        if (name == "player")
        {
            life -= 1;
            Update();
            //and then respawn to somewhere(?)    

        }
    }

    //place it in the energy source script
    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;
        if (name == "player")
        {
            Instantiate(fireEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(myClip, transform.position);
            Destroy(gameObject);

            EN += 1;
            Update();


        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100, 0, 400, 400), "Energy Source: " + EN);
        GUI.Label(new Rect(100, 20, 400, 400), "Life: " + life);

        if (life == 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 500, 100), "GAMEOVER");
            Time.timeScale = 0;
        }
    }

}
