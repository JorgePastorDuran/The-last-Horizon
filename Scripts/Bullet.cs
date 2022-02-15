using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public AudioClip ShootSound;

    private Rigidbody2D Rigidbody2D;
    private Vector2 bulletDirection; 

    void Start()
    {

        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(ShootSound);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = bulletDirection * Speed;
    }

    public void SetDirection(Vector2 direction) 
    {

        bulletDirection = direction;

    }

    public void BulletIsDestroy() {


        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HeroMovement hero = collision.GetComponent<HeroMovement>();
        EnemyBehavior enemy = collision.GetComponent<EnemyBehavior>();
        MortalEnemy mortalEnemy = collision.GetComponent<MortalEnemy>();
        if (hero != null)
        {            
            hero.Hit();
        }

        if (enemy != null)
        {
            
           enemy.Hit();
        }

        if (mortalEnemy != null)
        {

            mortalEnemy.Hit();
        }

        BulletIsDestroy();
    }

}
