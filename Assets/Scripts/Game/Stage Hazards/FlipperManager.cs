using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperManager : MonoBehaviour
{
    [SerializeField] private Sprite flipperIdle = null;
    [SerializeField] private Sprite flipperActivated = null;

    private SpriteRenderer flipperSprite;
    private float flipperCooldown;
    private float flipperAnimation;

    // Start is called before the first frame update
    void Start()
    {
        flipperSprite = GetComponent<SpriteRenderer>();
        flipperCooldown = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (flipperAnimation > 0)
        {
            flipperAnimation -= Time.deltaTime;
            flipperSprite.sprite = flipperActivated;
        }
        else
        {
            flipperSprite.sprite = flipperIdle;
        }

        flipperCooldown -= Time.deltaTime;
        if (flipperCooldown <= 0)
        {
            flipperAnimation = 0.15f;
            flipperCooldown = Random.Range(1.0f, 3.0f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (flipperAnimation > 0 && collision.collider.CompareTag("Player"))
        {
            Vector2 bumpOffset = new Vector2 (transform.localPosition.x, transform.localPosition.y - 1.0f);
            Vector2 playerPos = new Vector2(collision.collider.transform.position.x, collision.collider.transform.position.y);

            Vector2 launchDirection = playerPos - bumpOffset;
            Rigidbody2D playerBody = collision.collider.GetComponent<Rigidbody2D>();
            playerBody.AddForce(launchDirection.normalized * 12, ForceMode2D.Impulse);
        }
    }

}
