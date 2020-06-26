using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using P2Playworks.ModularFrameworks;

public class ObjectTextureScroller : MonoBehaviour
{
    [Range(-1, 1)]
    public int xDirection = 1;

    [Range(-1, 1)]
    public int yDirection = 0;

    [Range(0f, 1f)]
    public float speed = 0.1f;

    private Renderer mainRenderer;

    private void Awake()
    {
        mainRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        var offsetX = Time.time * speed;
        var offsetY = Time.time * speed;

        var offset = new Vector2(offsetX, offsetY) * new Vector2(xDirection, yDirection);

        mainRenderer.material.mainTextureOffset = offset;
    }
}