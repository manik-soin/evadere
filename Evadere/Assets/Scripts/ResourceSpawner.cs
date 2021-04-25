using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    private RoomTemplates templates;
    private int rand;
    public List<GameObject> points;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        for (int i=0; i<points.Count; i++) {
            GameObject resource = templates.resources[i];
            // templates.resources.RemoveAt(0);
            Instantiate(resource, points[i].transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
