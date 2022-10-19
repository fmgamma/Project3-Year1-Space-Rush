using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownRespawn : MonoBehaviour
{
    [SerializeField] private PlayerManager player1 = null;
    [SerializeField] private PlayerManager player2 = null;

    private Collider2D collision;
    private SpriteRenderer sprite;

    void Start()
    {
        collision = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!player1.isCrowned && !player2.isCrowned)
        {
            collision.enabled = true;
            sprite.enabled = true;
        }
    }
}
