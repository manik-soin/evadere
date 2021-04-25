using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPieceSpawner : MonoBehaviour
{
    public GameObject centre;
    public GameObject enemy;
    public List<GameObject> spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn",0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(centre,spawnPoints[0].transform.position, Quaternion.identity);
        if (spawnPoints.Count>1) {
            for (int i=1; i< spawnPoints.Count; i++) {
                int spawnEnemy = Random.Range(0, spawnPoints.Count)%2;
                if (spawnEnemy!=0) {
                    Instantiate(enemy,spawnPoints[i].transform.position, Quaternion.identity);
                }
            }
        }
        Destroy(gameObject);
    }
}
