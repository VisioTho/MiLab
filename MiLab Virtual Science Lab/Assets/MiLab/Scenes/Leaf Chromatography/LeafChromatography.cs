using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafChromatography : MonoBehaviour
{
    public Material paperMaterial;
    public Color[] pigmentColors;

    private Texture2D chromatogramTexture;

    void Start()
    {
        // Create a texture to represent the chromatogram
        chromatogramTexture = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        GetComponent<Renderer>().material = paperMaterial;
        GetComponent<Renderer>().material.mainTexture = chromatogramTexture;

        // Extract pigments from a banana leaf
        ExtractPigmentsFromLeaf();

        // Apply the pigment colors to the chromatogram texture
        ApplyPigmentColorsToTexture();
    }

    void ExtractPigmentsFromLeaf()
    {
        // Create a color array to hold the pigment colors
        pigmentColors = new Color[3];

        // Simulate extraction of pigments from a banana leaf
        pigmentColors[0] = new Color(0.5f, 0.5f, 0.5f); // chlorophyll a
        pigmentColors[1] = new Color(0.4f, 0.6f, 0.2f); // chlorophyll b
        pigmentColors[2] = new Color(1f, 0.8f, 0f); // xanthophylls
        Debug.Log("Code executes");
    }

    void ApplyPigmentColorsToTexture()
    {
        // Apply the pigment colors to the chromatogram texture
        for (int i = 0; i < pigmentColors.Length; i++)
        {
            int xStart = i * (chromatogramTexture.width / pigmentColors.Length);
            int xEnd = (i + 1) * (chromatogramTexture.width / pigmentColors.Length);
            for (int x = xStart; x < xEnd; x++)
            {
                for (int y = 0; y < chromatogramTexture.height; y++)
                {
                    chromatogramTexture.SetPixel(x, y, pigmentColors[i]);
                    Debug.Log("This code runs");
                }
            }
        }

        // Apply changes to the texture
        chromatogramTexture.Apply();
    }
}
