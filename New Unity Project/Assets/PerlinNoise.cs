using UnityEngine;

public class PerlinNoise : MonoBehaviour {

    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public float offSetX = 100f;
    public float offSetY = 100f;

    void Start()
    {
        offSetX = Random.Range(0f, 99999f);
        offSetY = Random.Range(0f, 99999f);
    }

    void Update ()
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
        texture.Apply();
        return texture;
    }

    Color CalculateColor (int x, int y)
    {
        float xCoord = (float)x / width * scale + offSetX; //coordinates are 20 bigger to give the effect of zooming in , crammed more perlin noise into our area
        float yCoord = (float)y / height * scale + offSetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
