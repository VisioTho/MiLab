using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChromatographySimulation : MonoBehaviour
{
    public Texture2D leafTexture;
    public Texture2D paperTexture;
    public Color[] pigmentColors;

    private RawImage paperImage;
    private Color[] paperColors;
    private Color[] results;

    void Start()
    {
        paperImage = GetComponent<RawImage>();
        paperColors = paperTexture.GetPixels();
        results = new Color[paperColors.Length];
    }

    public void RunChromatography()
    {
        // Add the leaf texture to the paper texture
        for (int i = 0; i < paperColors.Length; i++)
        {
            float blendAmount = leafTexture.GetPixelBilinear((float)i / paperColors.Length, 0.5f).grayscale;
            results[i] = Color.Lerp(paperColors[i], pigmentColors[0], blendAmount);
        }

        // Apply the color variations for each pigment
        for (int pigmentIndex = 1; pigmentIndex < pigmentColors.Length; pigmentIndex++)
        {
            for (int i = 0; i < paperColors.Length; i++)
            {
                float previousBlendAmount = (float)(pigmentIndex - 1) / pigmentColors.Length;
                float blendAmount = leafTexture.GetPixelBilinear((float)i / paperColors.Length, 0.5f).grayscale;
                float blendValue = Mathf.Clamp((blendAmount - previousBlendAmount) / (1 - previousBlendAmount), 0f, 1f);
                results[i] = Color.Lerp(results[i], pigmentColors[pigmentIndex], blendValue);
            }
        }

        // Set the new colors for the paper image
        paperTexture.SetPixels(results);
        paperTexture.Apply();
        paperImage.texture = paperTexture;
    }
}
