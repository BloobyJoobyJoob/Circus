using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Sprite[] backgroundSprites;
    public SpriteRenderer spriteRenderer;
    public Transform player;

    public float moveSpeed;

    public int blurRadius;
    public int blurIterations;

    private Vector3 startPosition;

    private void Awake()
    {
        LinearBlur linearBlur = new LinearBlur();

        for (int i = 0; i < backgroundSprites.Length; i++)
        {
            Texture2D tex = linearBlur.Blur(backgroundSprites[i].texture, blurRadius, blurIterations);
            Sprite sprite;
            sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 50);
            backgroundSprites[i] = sprite;
        }
        spriteRenderer.sprite = backgroundSprites[1];

        startPosition = transform.position;
    }
    private void Update()
    {
        transform.position = (player.position * moveSpeed) + startPosition;
    }
}
