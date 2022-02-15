using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public GameObject prefabBullet;
    public float jump;
    public float speed;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float MoveHorizontal;
    private bool feetOnTheGround;
    private float timeToShoot;
    private int Health = 3;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        MoveHorizontal = Input.GetAxisRaw("Horizontal");
        if (MoveHorizontal < 0.0f) transform.localScale = new Vector3(-0.1f, 0.1f, 1.0f); 
        else if (MoveHorizontal > 0.0f) transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);

        Animator.SetBool("Movement", MoveHorizontal != 0.0f);
        Animator.SetBool("Jump", feetOnTheGround);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.3f))
        {

            feetOnTheGround = true;

        }else feetOnTheGround= false;



        if (Input.GetKeyDown(KeyCode.W) && feetOnTheGround)
        { 
            Jump();
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > timeToShoot + 0.4f)
        {

            Fire();
            timeToShoot = Time.time;
        }
    }

    private void Fire()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.1f) direction = Vector3.right;
        else direction = Vector3.left;
        GameObject bullet = Instantiate(prefabBullet, transform.position + direction * 0.4f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }

    private void Jump()
    {

        Rigidbody2D.AddForce(Vector2.up * jump); 

    }

    private void FixedUpdate()
    { //para las fisicas, es mucho mas constante en los fps

        Rigidbody2D.velocity = new Vector2(MoveHorizontal, Rigidbody2D.velocity.y); 


    }

    public void Hit()
    {

        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);

    }


}
