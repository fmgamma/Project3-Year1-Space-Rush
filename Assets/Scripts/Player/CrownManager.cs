using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownManager : MonoBehaviour
{
    [SerializeField] private Sprite[] crownSpriteSheet = null;
    private int index;
    private SpriteRenderer crownSprite;
    private float elapsed;

    void Start()
    {
        elapsed = 0;
        crownSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 0.2)
        {
            ++index;
            elapsed = 0;
        }
        index %= crownSpriteSheet.Length;
        crownSprite.sprite = crownSpriteSheet[index];
    }
}
