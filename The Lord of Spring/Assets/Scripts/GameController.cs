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
    public KeyCode BasicAttack { get { return _basicAttack; } set { _basicAttack = value; } }
    public KeyCode SpeicalAttack { get { return _specialAttack; } set { _specialAttack = value; } }

    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _basicAttack = KeyCode.Space;
    [SerializeField] private KeyCode _specialAttack = KeyCode.R;

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
