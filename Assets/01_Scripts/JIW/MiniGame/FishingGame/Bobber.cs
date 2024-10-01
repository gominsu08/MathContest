using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Bobber : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private FishingRod _fishingRod;
    private Collider2D _collider;

    private LineRenderer _line;
    private AnswerFish _getFish;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _line = GetComponent<LineRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    public void InitAndFire(Vector3 dir, FishingRod rod, float force = 13f)
    {
        _fishingRod = rod;
        
        _line.SetPosition(1, _fishingRod._firePos.position);
        _line.enabled = true;
        
        dir = new Vector3(dir.x, dir.y * 1.25f, dir.z);
        _rigid.AddForce(dir * force,ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (_getFish != null)
        {
            _getFish.transform.position = transform.position;
            
        }
    }

    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(_rigid.velocity.y, _rigid.velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        if (_fishingRod != null)
            _line.SetPosition(0, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out AnswerFish fish))
        {
            _getFish = fish;
            transform.DOMove(_fishingRod.transform.position, 3f).SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    Debug.Log("?");
                    _getFish._collider.isTrigger = true;
                    _collider.isTrigger = true;
                    AnswerCheck.Instance.AnswerChecker(_getFish.GetAnswer());
                    Destroy(this.gameObject);
                });
        }
    }

    private void OnDestroy()
    {
        _fishingRod.isFire = false;
    }
}
