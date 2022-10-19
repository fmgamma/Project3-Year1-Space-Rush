using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //The horizontal speed of the player
    [SerializeField] private float playerMoveSpeed = 0;
    //The player's jump height
    [SerializeField] private float playerJumpHeight = 0;
    //Maximum speed of the player.
    [SerializeField] private float playerMaxSpeed = 0;
    //Which set of controls wil this player instance use?
    [SerializeField] public string playerAxis = "";
    //Which button will this player use to jump?
    [SerializeField] private KeyCode playerJumpKey = KeyCode.W;
    //Global game timer
    [SerializeField] private TimerManager _timerManager = null;

    private Transform _playerTransform;
    //We need the player's RigidBody2D to perform physics-based movement
    private Rigidbody2D _playerRB;

    private Vector2 _playerVel;
    //Is the player standing on solid ground?
    public bool onGround = false;
    private bool doubleJump = false;
    private Vector2 jump = new Vector2(0.0f, 1.0f);

    void Start()
    {
        _playerTransform = transform;
        _playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_timerManager.timerFloat > 0)
        {
            float playerX = Input.GetAxis(playerAxis) * playerMoveSpeed;

            playerX *= Time.deltaTime;

            _playerRB.AddForce(transform.right * playerX);
            // Cap player horizontal speed
            if (_playerRB.velocity.x > playerMaxSpeed)
            {
                _playerRB.velocity = new Vector2(playerMaxSpeed, _playerRB.velocity.y);
            }
            else if (_playerRB.velocity.x < -playerMaxSpeed)
            {
                _playerRB.velocity = new Vector2(-playerMaxSpeed, _playerRB.velocity.y);
            }

            if (Input.GetKeyDown(playerJumpKey) && (onGround || doubleJump))
            {
                _playerRB.AddForce(jump * playerJumpHeight, ForceMode2D.Impulse);
                if (_playerRB.velocity.y > playerJumpHeight)
                {
                    _playerRB.velocity = new Vector2(_playerRB.velocity.x, playerJumpHeight);
                }
                if (onGround)
                {
                    onGround = false;
                }
                else
                {
                    doubleJump = false;
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform")
            && _playerRB.velocity.y <= 0
            && transform.position.y > collision.collider.transform.position.y)
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform") && transform.position.y > collision.collider.transform.position.y)
        {
            onGround = false;
            doubleJump = true;
        }
    }
}
