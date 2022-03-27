using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;

    void Update()
    {
        rb.velocity = -transform.up * speed;
        autodestroy();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (hitInfo.gameObject.tag == "Enemy")
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public async Task autodestroy()
    {
        await Task.Delay(3000);
        Destroy(gameObject);
    }

}