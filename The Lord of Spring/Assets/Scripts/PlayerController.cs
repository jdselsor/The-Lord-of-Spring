using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private GameObject _crosshair = null;
    [SerializeField] private float _dashAmount = 50.0f;
    [SerializeField] private LayerMask _dashLayerMask;

    private Rigidbody2D _rigidbody2D = null;
    private SpriteRenderer _spriteRenderer = null;
    private Vector2 _moveDir = Vector2.zero;
    private Vector2 _velocity = Vector2.zero;
    private Vector3 _target = Vector3.zero;

    private bool _canDash;
    private bool _facingRight;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckInputs();

        var mousePos = Input.mousePosition;
        mousePos.z = transform.position.z;

        _target = Camera.main.ScreenToWorldPoint(mousePos);
        _crosshair.transform.position = new Vector2(_target.x, _target.y);
    }

    private void FixedUpdate()
    {
        _velocity = _moveDir * _moveSpeed;
        _rigidbody2D.velocity = _velocity;

        if (_canDash)
        {
            Dash();
        }
    }

    private void CheckInputs ()
    {
        if (Input.GetKey(GameController.Instance.MoveUp))
            _moveDir.y = 1;
        if (Input.GetKey(GameController.Instance.MoveDown))
            _moveDir.y = -1;

        if (Input.GetKey(GameController.Instance.MoveLeft))
        {
            _moveDir.x = -1;

            if (!_facingRight)
            {
                Flip();
            }
        }
        if (Input.GetKey(GameController.Instance.MoveRight))
        {
            _moveDir.x = 1;
            if (_facingRight)
            {
                Flip();
            }
        }

        if (Input.GetKeyDown(GameController.Instance.Dash))
        {
            _canDash = true;
        }

        if (Input.GetKeyUp(GameController.Instance.MoveUp) || Input.GetKeyUp(GameController.Instance.MoveDown))
            _moveDir.y = 0;
        if (Input.GetKeyUp(GameController.Instance.MoveLeft) || Input.GetKeyUp(GameController.Instance.MoveRight))
            _moveDir.x = 0;
    }

    private void Dash ()
    {
        Vector3 dashPosition = transform.position + (Vector3)(_moveDir * _dashAmount);
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, _moveDir, _dashAmount, _dashLayerMask);

        if (raycastHit.collider != null)
        {
            dashPosition = raycastHit.point;
        }

        _rigidbody2D.MovePosition(dashPosition);
        _canDash = false;
    }

    private void Flip ()
    {
        _facingRight = !_facingRight;

        var localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
