using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;

    public void ShotRight()
    {
        if (Player.health > 0)
        {
            Instantiate(bullet, shotPoint.position, transform.rotation);
        }
    }

}