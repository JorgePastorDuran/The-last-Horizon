using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject hero;
    public GameObject prefabBullet;

    private Animator animator;
    private float timeToShoot;
    private int Health = 2;


    private void Start()
    {
        animator= GetComponent<Animator>();
    }


    void Update()
    {
        if (hero == null) return;

        

        Vector3 direction = hero.transform.position - transform.position;  
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.15f, 0.15f, 1.0f);
        else transform.localScale = new Vector3(-0.15f, 0.15f, 1.0f);


        float distance = Mathf.Abs(hero.transform.position.x - transform.position.x);

        animator.SetBool("Attach", distance < 1.3f && hero!= null); //Animation attach

        if (distance < 1.3f && Time.time > timeToShoot + 0.35f)
        {

            Fire();
            timeToShoot = Time.time;

        }
    }


    private void Fire() {

        Vector3 direction;
        if (transform.localScale.x == 0.15f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(prefabBullet, transform.position + direction * 0.6f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);


    }



    public void Hit()
    {

        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);

    }

}
