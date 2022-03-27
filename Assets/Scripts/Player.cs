using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    public static int health = 100;
    public Text healthText;

    public int maxHealth = 100;
        
    public int currentHealth;
   // public Slider healthBar;
   // public HealthBar healthBar;
    public GameObject panelRestart;

  //  void Start()
  //  {
  //      currentHealth = maxHealth;
 //       healthBar.SetMaxHealth(maxHealth);
  //  }

    void Update()
    {
        dead();
        healthText.text = health.ToString();
        healthText.text = health + "/100";
      //  healthBar.value = health;
    }

    void dead()
    {
        if (health <= 0)
        {
            panelRestart.SetActive(true);
        }
    }

    public async Task TakeDamage(int damage)
    {
        health -= damage;
        if (health > 0)
        {
            GetComponent<Renderer>().material.color = Color.red;
            await Task.Delay(200);
            GetComponent<Renderer>().material.color = Color.white;
        }
       // healthBar.SetHealth(currentHealth);
    }

}