using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperCollision : MonoBehaviour
{
    [SerializeField] private Sprite bumperIdle = null;
    [SerializeField] private Sprite bumperHit = null;
    private SpriteRenderer bumperSprite;
    private float hitCooldown;

    void Start()
    {
        bumperSprite = GetComponent<SpriteRenderer>();
        hitCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitCooldown > 0)
        {
            bumperSprite.sprite = bumperHit;
            hitCooldown -= Time.deltaTime;
        }
        else
        {
            bumperSprite.sprite = bumperIdle;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 playerPos = new Vector2 (collision.collider.transform.position.x, collision.collider.transform.position.y);
            Vector2 posDifference = playerPos - new Vector2(transform.position.x, transform.position.y);
            Rigidbody2D playerBody = collision.collider.GetComponent<Rigidbody2D>();
            Vector2 bumperScale = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y);
            playerBody.AddForce(posDifference.normalized * bumperScale * 12, ForceMode2D.Impulse);;

            hitCooldown = 0.15f;
        }
    }

}
