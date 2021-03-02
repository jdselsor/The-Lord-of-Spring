using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestPaletteSwapLookUp : MonoBehaviour
{
    public Texture loopUpTexture;

    private Material _material;

    private void OnEnable()
    {
        Shader shader = Shader.Find("Hidden/PaletteSwap");

        if (_material == null)
            _material = new Material(shader);
    }

    private void OnDisable()
    {
        if (_material != null)
            DestroyImmediate(_material);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        _material.SetTexture("_PaletteTex", loopUpTexture);
        Graphics.Blit(source, destination, _material);
    }
}
