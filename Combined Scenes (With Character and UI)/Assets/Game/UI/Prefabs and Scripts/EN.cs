using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EN : MonoBehaviour
{
    public int maxEN = 100;
    public int currentEN;
    public EN_bar enBar;

    public Text enText;
    // Start is called before the first frame update
    void Start()
    {
        currentEN = Controls.cellsCollected;
        enBar.SetMaxEN(maxEN);
    }

    // Update is called once per frame
    void Update()
    {
        currentEN = Controls.cellsCollected;
        enText.text = "Energy : " + currentEN*20 + "%";
        
        enBar.SetEN(currentEN);
        
    }
}
