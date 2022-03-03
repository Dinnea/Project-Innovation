using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseSprite : MonoBehaviour
{
    [Header("Sprites")] 
    [SerializeField] Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int normalChance = Mathf.FloorToInt(100.0f/ (sprites.Length-1));
        int smallChance = 100 - (normalChance * (sprites.Length - 1));
        int randomChance = Random.Range(1, 101);
        
        if (randomChance <= 12)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (randomChance <= 24)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if ( randomChance <= 36)
        {
            spriteRenderer.sprite = sprites[2];
        }
        else if (randomChance <= 48)
        {
            spriteRenderer.sprite = sprites[3];
        }
        else if (randomChance <= 60)
        {
            spriteRenderer.sprite = sprites[4];
        }
        else if (randomChance <= 72)
        {
            spriteRenderer.sprite = sprites[5];
        }
        else if (randomChance <= 84)
        {
            spriteRenderer.sprite = sprites[6];
        }
        else if (randomChance <= 96)
        {
            spriteRenderer.sprite = sprites[7];
        }
        else if (randomChance < 101)
        {
            spriteRenderer.sprite = sprites[8];
        }
    }
}
