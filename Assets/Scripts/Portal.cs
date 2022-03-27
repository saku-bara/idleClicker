using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class Portal : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject[] allEnemies;
    private int numOfEnemies;
    public float mainTimer = 4f;
    public float timer = 2f;

    void Start()
    {
        numOfEnemies = allEnemies.Length;
    }

    void FixedUpdate()
    {
        // PortalSwitchOn();    
        timer -= Time.deltaTime;
        if (timer <= 0 && Player.health > 0)
        {
            Instantiate(allEnemies[numOfEnemies - 1], spawnPoint.position, transform.rotation);
            numOfEnemies--;
            timer = mainTimer;
            if (numOfEnemies == 0)
            {
                numOfEnemies = allEnemies.Length;
            }
        }
    }
}