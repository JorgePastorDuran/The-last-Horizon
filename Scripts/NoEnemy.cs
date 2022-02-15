using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEnemy : MonoBehaviour
{
    public GameObject hero;



    void Update()
    {
        if (hero != null)
        {
            Vector3 direction = hero.transform.position - transform.position;
            if (direction.x >= 0.0f) transform.localScale = new Vector3(0.133f, 0.133f, 0.133f);
            else transform.localScale = new Vector3(-0.133f, 0.133f, 0.133f);

        }
    }
}
