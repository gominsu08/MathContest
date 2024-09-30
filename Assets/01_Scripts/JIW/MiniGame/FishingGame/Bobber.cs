using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bobber : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private FishingRod _fishingRod;

    private LineRenderer _line;
    private HingeJoint2D _joint;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _line = GetComponent<LineRenderer>();
    }

    public void InitAndFire(Vector3 dir, FishingRod rod, float force = 13f)
    {
        _fishingRod = rod;
        
        _line.SetPosition(1, _fishingRod._firePos.position);
        _line.enabled = true;
        
        dir = new Vector3(dir.x, dir.y * 1.25f, dir.z);
        _rigid.AddForce(dir * force,ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(_rigid.velocity.y, _rigid.velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        if (_fishingRod != null)
            _line.SetPosition(0, transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }
}
