using System;
using UnityEngine;

public class Arrow : MonoBehaviour, IPoolable
{
    private Rigidbody2D _rbCompo;

    private float _lifeTime = 0;
    private float surTime = 2.5f;
    [SerializeField] private float _speed=10f;
    private DamageCaster _damageCaster;
    private int _damage;
    public void Initalize(Transform trans, int damage)
    {
        transform.SetPositionAndRotation(trans.position, trans.rotation);
        
        _rbCompo = GetComponent<Rigidbody2D>();

        _damageCaster = transform.Find("DamageCaster").GetComponent<DamageCaster>();
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _damageCaster.CastDamage(_damage);
    }

    private void Update()
    {
        _lifeTime += Time.deltaTime;
        if (_lifeTime >= surTime)
        {
            PoolManager.Instance.Push(this);
        }
    }

    private void FixedUpdate()
    {
        _rbCompo.velocity = transform.right * _speed;
    }

    [SerializeField] private string _poolName;
    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;
    public void ResetItem()
    {
        _lifeTime = 0;

    }
}