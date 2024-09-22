using System;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    private bool _isMove = false;
    private Rigidbody2D _rbCompo;
    private float _moveSpeed;
    
    public void IniaLize(float speed)
    {
        _moveSpeed = speed;
        _rbCompo = GetComponent<Rigidbody2D>();
        _isMove = true;
    }

    public void MoveSet(bool value)
    {
        _isMove = value;
        if (!_isMove)
        {
            _rbCompo.velocity = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        if(!_isMove) return;
        
        _rbCompo.velocity = new Vector2(transform.right.x*_moveSpeed,_rbCompo.velocity.y);
    }
}