using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get { return _instance; } }
    private static GameController _instance;

    public KeyCode MoveUp { get { return _moveUp; } set { _moveUp = value; } }
    public KeyCode MoveLeft { get { return _moveLeft; } set { _moveLeft = value; } }
    public KeyCode MoveDown { get { return _moveDown; } set { _moveDown = value; } }
    public KeyCode MoveRight { get { return _moveRight; } set { _moveRight = value; } }
    public KeyCode Dash { get { return _dash; } set { _dash = value; } }
    public int AttackButton { get { return _attackButton; } set { _attackButton = value; } }

    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private int _attackButton = 0;
    [SerializeField] private KeyCode _dash = KeyCode.Space;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
