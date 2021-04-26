using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxScript : MonoBehaviour
{

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Character")
        {

            Debug.Log("Health Pack Collision Detected");
            Debug.Log(other.gameObject.name);
            if (Controls.currentHealth < 100)
            {
                Controls.currentHealth = 100;

                Debug.Log("Health Collected");
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.text = "";
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
