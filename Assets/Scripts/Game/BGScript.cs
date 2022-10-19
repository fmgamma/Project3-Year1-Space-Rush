using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    [SerializeField] private Sprite[] BGSpriteSheetindex = null;
    private int index;
    private float elapsed;
    private SpriteRenderer BGSpriteSheet;


    // Start is called before the first frame update
    void Start()
    {
        elapsed = 0;
        BGSpriteSheet = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 1)
        {
            ++index;
            elapsed = 0;
        }

        index %= BGSpriteSheetindex.Length;
        BGSpriteSheet.sprite = BGSpriteSheetindex[index];
    }
}
