using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Player idle sprites
    [SerializeField] private Sprite[] playerIdleSheet = null;
    [SerializeField] private Sprite[] playerRunSheet = null;
    [SerializeField] private Sprite playerJump = null;
    [SerializeField] private Sprite[] playerTurnSheet = null;

    // Enum class to determine which state the player is in
    enum PlayerState { Idle, Run, Jump, Turn };

    // Index for swapping to player sprites
    private int index;

    private float elapsed;
    private PlayerState state;
    private PlayerInput player;
    private SpriteRenderer playerSprite;
    private Rigidbody2D _playerRB;

    void Start()
    {
        index = 0;
        elapsed = 0;
        state = PlayerState.Idle;
        player = GetComponent<PlayerInput>();
        playerSprite = GetComponent<SpriteRenderer>();
        _playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 0.15f)
        {
            ++index;
            elapsed = 0;
        }

        switch (state)
        {
            case PlayerState.Idle:
                index %= playerIdleSheet.Length;
                playerSprite.sprite = playerIdleSheet[index];
                break;
            case PlayerState.Run:
                index %= playerRunSheet.Length;
                playerSprite.sprite = playerRunSheet[index];
                break;
            case PlayerState.Jump:
                index = 0;
                playerSprite.sprite = playerJump;
                break;
            case PlayerState.Turn:
                if (index > playerTurnSheet.Length - 1)
                {
                    index = playerTurnSheet.Length - 1;
                }
                playerSprite.sprite = playerTurnSheet[index];
                break;
        }

        float playerX = Input.GetAxis(player.playerAxis);


        if (playerX > 0)        // If player is turning right
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            if (_playerRB.velocity.x > 2)
            {
                ChangeState(PlayerState.Run);
            }
            else
            {
                ChangeState(PlayerState.Turn);
            }
        }
        else if (playerX < 0)   // If player is turning left
        {
            gameObject.transform.localScale = new Vector3(-0.3f, 0.3f, 1);
            if (_playerRB.velocity.x < -2)
            {
                ChangeState(PlayerState.Run);
            }
            else
            {
                ChangeState(PlayerState.Turn);
            }
        }
        else
        {
            ChangeState(PlayerState.Idle);
        }

        if (!player.onGround && _playerRB.velocity.y > 0)
        {
            ChangeState(PlayerState.Jump);
        }

    }

    private void ChangeState(PlayerState newState)
    {
        if (newState != state)
        {
            state = newState;
            index = 0;
            elapsed = 0;
        }
    }


}
