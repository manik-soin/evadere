using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 100;
    public HealthBar healthBar;

    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {

        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP : " + Controls.currentHealth;
        healthBar.SetHealth(Controls.currentHealth);
    }
}
