using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeadZon : MonoBehaviour
{   
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
