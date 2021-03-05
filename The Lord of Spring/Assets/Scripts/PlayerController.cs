using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController2D
{
    [SerializeField] private Transform _firePoint = null;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start ()
    {
        base.Start();

        ChangeFirePoint(new Vector3(0.0f, -0.03f, 0.0f));
    }

    protected override void Update()
    {
        CheckKeysDown();
        CheckKeysUp();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void CheckKeysDown()
    {
        if (Input.GetKey(GameController.Instance.MoveUp))
        {
            moveDirection.y = 1.0f;
            ChangeFirePoint(new Vector3(0.0f, 0.03f, 0.0f));
        }
        
        if (Input.GetKey(GameController.Instance.MoveDown))
        {
            moveDirection.y = -1.0f;
            ChangeFirePoint(new Vector3(0.0f, -0.03f, 0.0f));
        }
        
        if (Input.GetKey(GameController.Instance.MoveLeft))
        {
            moveDirection.x = -1.0f;
            ChangeFirePoint(new Vector3(-0.03f, 0.0f, 0.0f));
        }
        
        if (Input.GetKey(GameController.Instance.MoveRight))
        {
            moveDirection.x = 1.0f;
            ChangeFirePoint(new Vector3(0.03f, 0.0f, 0.0f));
        }
    }

    private void CheckKeysUp ()
    {
        if (Input.GetKeyUp(GameController.Instance.MoveUp) || Input.GetKeyUp(GameController.Instance.MoveDown))
        {
            moveDirection.y = 0.0f;
        }

        if (Input.GetKeyUp(GameController.Instance.MoveLeft) || Input.GetKeyUp(GameController.Instance.MoveRight))
        {
            moveDirection.x = 0.0f;
        }
    }

    private void Attack ()
    {

    }

    private void SpecialAttack ()
    {

    }

    private void ChangeFirePoint (Vector3 location)
    {
        _firePoint.localPosition = location;
    }
}
