using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }

    protected Rigidbody2D _rigidbody2D = null;
    protected Vector2 moveDirection = Vector2.zero;
    protected Vector2 velocity = Vector2.zero;
    protected bool facingRight = false;
    protected bool facingUp = false;

    [SerializeField] private float _moveSpeed = 5.0f;

    public virtual void Move (Vector2 moveDir)
    {
        moveDirection = moveDir;
    }

    protected virtual void Awake ()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start () { }

    protected virtual void Update() { }

    protected virtual void FixedUpdate()
    {
        velocity = moveDirection * _moveSpeed;
        _rigidbody2D.velocity = velocity;
    }

    protected virtual void Flip(bool xAxisFlip, bool yAsixFlip)
    {
        var localScale = transform.localScale;

        if (xAxisFlip)
        {
            facingRight = !facingRight;
            localScale.x *= -1;
        }

        if (yAsixFlip)
        {
            facingUp = !facingUp;
            localScale.y *= -1;
        }

        transform.localScale = localScale;
    }
}
