using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blink : MonoBehaviour
{
    // Start is called before the first frame update
    bool fadeAway = true;
    byte i = 255;

   
    private void Update()
    {
        
        if (fadeAway){
            gameObject.GetComponent<Text>().color = new Color32(255, 255, 255, i);
            i -= 1;
            if (i <= 0)
            {
                fadeAway = false;
            }
        }
        else
        {
            gameObject.GetComponent<Text>().color = new Color32(255, 255, 255, i);
            i += 1;
            if (i <= 0)
            {
                fadeAway = true;
            }
        }
        
    }


  
}

