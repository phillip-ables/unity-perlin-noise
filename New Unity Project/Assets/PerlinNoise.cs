using UnityEngine;

public class PerlinNoise : MonoBehaviour {

    public int width = 256;
    public int height = 256;

    void Start ()
    {
        Renderer renderer = GetComponent<Renderer>();  //reference to our current renderer
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height); //creating a texture from scratch so we need to create a texture variable
        //generate a perlin noise map for the texture
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        return texture;
    }

    Color CalculateColor (int x, int y)
    {
        float xCoord = x / width;
        float yCoord = y / height;

        float smaple = Mathf.PerflinNoise(x, y);
        return new Color(sample, sample, sample);
    }
}
