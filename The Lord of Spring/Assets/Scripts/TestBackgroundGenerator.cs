using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class TestBackgroundGenerator : MonoBehaviour
{
    [SerializeField] private int _pixelWidth = 100;
    [SerializeField] private int _pixelHeight = 100;
    [SerializeField] private int _xOrigin = 0;
    [SerializeField] private int _yOrigin = 0;
    [SerializeField] private float scale = 1.0f;

    private Texture2D _noiseTexture;
    private Color[] _pixels;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _noiseTexture = new Texture2D(_pixelWidth, _pixelHeight);
        _pixels = new Color[_pixelWidth * _pixelHeight];

        CalcuateNoise();

        var sprite = Sprite.Create(_noiseTexture, new Rect(0, 0, _noiseTexture.width, _noiseTexture.height), new Vector2 (0.5f, 0.5f), 100);
        _spriteRenderer.sprite = sprite;
    }

    private void CalcuateNoise ()
    {
        var y = 0.0f;

        while (y < _noiseTexture.height)
        {
            var x = 0.0f;
            while (x < _noiseTexture.width)
            {
                var xCoord = _xOrigin + x / _noiseTexture.width * scale;
                var yCoord = _yOrigin + y / _noiseTexture.height * scale;
                var sample = Mathf.PerlinNoise(xCoord, yCoord);
                _pixels[(int) y * _noiseTexture.width + (int) x] = new Color(sample, sample, sample);
                x++;
            }
            y++;
        }

        _noiseTexture.SetPixels(_pixels);
        _noiseTexture.Apply();
    }
}
