using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCharacter : MonoBehaviour
{
    public GameObject Hero;
    void Update()
    {

        if (Hero != null)
        {
            Vector3 position = transform.position;
            position.x = Hero.transform.position.x;
            transform.position = position;
        }
    }
}
