using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D map;

    public ColorToPrefs[] colorMapings;

	// Use this for initialization
	void Start () {
        GenerateLevel();
    }
    
    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for(int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        
        if(pixelColor.a == 0)
        {
            // the pixel is transparent let's ignore it
            return;
        }
        Debug.Log(pixelColor);
        foreach(ColorToPrefs colorMaping in colorMapings)
        {
            if(colorMaping.color.Equals(pixelColor))
            {
                Vector2 posision = new Vector2(x, y);
                Instantiate(colorMaping.prefab, posision, Quaternion.identity, transform);
            }
        }
    }


}
