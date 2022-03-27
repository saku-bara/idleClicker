using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
// using System.Debug; 

public class Enemy : MonoBehaviour
{

    [Header("Points")]
    public int scoreGiven;

    [Header("Characteristics")]
    public int health;
    public int enemyDamage;
    public float speed;
    public bool isAnimated = false;
    public float attackRange;

    [Header("gameObjects")]
    private GameObject player;
    private Animator anim = null;
        
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if(isAnimated)
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
        death();
    }

    void FixedUpdate()
    {
        if (health > 0 && Player.health > 0)
        {
            moveToHero();
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
    }

    public async Task death()
    {
        if (health <= 0)
        {
            if (isAnimated)
            {
                anim.SetTrigger("death");
            }
            this.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().material.color = Color.red;
            
            if (isAnimated)
            {
                await Task.Delay(500);
            }
            Destroy(gameObject);
            ScoreManager.score += scoreGiven;
            UnityEngine.Debug.Log(gameObject.name + " is defeated!");
        }
    }

    void moveToHero()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    async Task Attack()
    {
        float attackRangeX = this.transform.position.y - player.transform.position.y;
        if (attackRangeX >= -attackRange && attackRangeX <= attackRange)
        {
            Player.health -= enemyDamage;
            Destroy(gameObject);
            player.GetComponent<Renderer>().material.color = Color.red;
            await Task.Delay(200);
            player.GetComponent<Renderer>().material.color = Color.white;

        }
    }

}