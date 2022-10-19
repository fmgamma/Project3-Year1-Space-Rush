using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Renderer bgSprite;
    public float scrollSpeed;

    void Start()
    {
        bgSprite = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(scrollSpeed * Time.time, 0);
        bgSprite.sharedMaterial.mainTextureOffset = offset;
    }
}
