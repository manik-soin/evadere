using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public int addHealth = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Health Pack Collision Detected");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Character")
        {
            if (Controls.currentHealth < 100)
            {
                Controls.currentHealth += addHealth;
            }

            if (Controls.currentHealth > 100)
            {
                Controls.currentHealth = 100;
            }
            Debug.Log("Health Collected");
            Destroy(gameObject.transform.parent.gameObject);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
