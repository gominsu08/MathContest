using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bobber : MonoBehaviour
{
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void InitAndFire(Vector3 dir, float force = 13f)
    {
        dir = new Vector3(dir.x, dir.y * 1.25f, dir.z);
        _rigid.AddForce(dir * force,ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(_rigid.velocity.y, _rigid.velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
