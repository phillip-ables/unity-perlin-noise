using UnityEngine;

public class PerlinNoise : MonoBehaviour {

    public int width = 256;
    public int height = 256;

    void Start ()
    {
        Renderer renderer = GetComponent<Renderer>();  //reference to our current renderer
        renderer.material.mainTexture = GenerateTexture();
    }


}
