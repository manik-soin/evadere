using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap_room_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Material brightMaterial;

    void OnTriggerEnter(Collider col)
    {
        print("yes");
        if (col.gameObject.tag == "minimap-sphere") {
            transform.GetComponent<Renderer>().material = brightMaterial;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
