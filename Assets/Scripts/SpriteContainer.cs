using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct SpriteContainer
{
    [SerializeField] private string title;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;


    public int Generate()
    {
        var randomIndex = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[randomIndex];
        return randomIndex;
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}