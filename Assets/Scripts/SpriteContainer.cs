using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct SpriteContainer
{
    [SerializeField] private string title;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;


    public void Generate()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}