using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer crownRender = null;

    //Game timer, do not earn any more points if time is up
    [SerializeField] private TimerManager _timerManager = null;

    //Is this player holding the crown right now?
    public bool isCrowned;

    //The amount of time the player has been crowned for
    public float crownedTime;
    //The player must not be able to steal the crown immediately after it is stolen from them
    public float tagCooldown;

    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
        isCrowned = false;
        crownedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Player falls offscreen, out of bounds
        if (transform.position.y < -25)
        {
            transform.position = spawnPoint;
            isCrowned = false;
        }

        if (tagCooldown > 0)
        {
            tagCooldown -= Time.deltaTime;
        }

        if (_timerManager.timerFloat > 0)
        {
            if (isCrowned)
            {
                crownRender.enabled = true;
                crownedTime += Time.deltaTime;
            }
            else
            {
                crownRender.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagCooldown <= 0 && collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.GetComponent<Collider2D>(), true);
            PlayerManager otherPlayer = collision.GetComponent<PlayerManager>();
            if (otherPlayer.tagCooldown <= 0)
            {
                if (otherPlayer.isCrowned)
                {
                    otherPlayer.isCrowned = false;
                    isCrowned = true;
                    tagCooldown = 1.5f;
                }
                else if (isCrowned)
                {
                    isCrowned = false;
                    otherPlayer.isCrowned = true;
                    tagCooldown = 1.5f;
                }
            }
        }

        if (collision.CompareTag("Crown"))
        {
            isCrowned = true;
            collision.enabled = false;
            SpriteRenderer crownSprite = collision.gameObject.GetComponent<SpriteRenderer>();
            crownSprite.enabled = false;
            tagCooldown = 1.5f;
        }
    }
}
