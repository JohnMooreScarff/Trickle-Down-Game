using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using TMPro;
public class MapGen : MonoBehaviour
{
    public Tilemap tilemapsurface;
    public Tilemap tilemapunder;
    public RuleTile sandTile, waterTile, DeepwaterTile, landTile, farmlandTile, forestTile, MountainlowTile, mountainTile, MountainhighTile, coalTile, ironTile, snowTile;

    public enum TileType { None, Sand, Water, Deepwater, Land, Farmland, Forest, Mountainlow, Mountain, Mountainhigh, Coal, Iron, Snow }

    private TileType[,] mapGrid;
    private TileType[,] mapGridUnder;
    private TileType[,] previousMapGrid;
    private TileType[,] previousMapGridUnder;
    private float[,] SavedNoiseValue;
    private float[,] maskValues;
    float mask;
    private int mapWidth = 500;
    private int mapHeight = 500;
    public float scale;
    [Range(-1.00f,1.00f)]
    public float sealevel;

    private float offsetX;
    private float offsetY;

    void Start()
    {
        scale = Random.Range(0.001f, 0.012f);
        offsetX = Random.Range(0f, 10000f);
        offsetY = Random.Range(0f, 10000f);

        mapGrid = new TileType[mapWidth, mapHeight];
        mapGridUnder = new TileType[mapWidth, mapHeight];
        previousMapGrid = new TileType[mapWidth, mapHeight];
        previousMapGridUnder = new TileType[mapWidth, mapHeight];
        SavedNoiseValue = new float[mapWidth, mapHeight];
        maskValues = new float[mapWidth, mapHeight];
        FractalNoise();
        genmapover();
        genmapunder();
        RenderMap();    
        StartCoroutine(searise());
    }
    IEnumerator searise()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            sealevel += 0.002f;
            genmapover();
            RenderMap();
        }
    }
   

    float GenerateFractalNoise(float x, float y, int octaves, float persistence, float lacunarity)
    {
        float amplitude = 7f;
        float frequency = 4f;
        float noiseHeight = 8f;
        float maxAmplitude = 2f;

        for (int i = 0; i < octaves; i++)
        {
            float sampleX = (x + offsetX) * scale * frequency;
            float sampleY = (y + offsetY) * scale * frequency;
            float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

            noiseHeight += perlinValue * amplitude;
            maxAmplitude += amplitude;

            amplitude *= persistence;
            frequency *= lacunarity;
        }

        noiseHeight /= maxAmplitude;
        return (noiseHeight + 1) / 2f;
    }

    float ApplyRadialMask(int x, int y)
    {
        float centerX = mapWidth / 2f;
        float centerY = mapHeight / 2f;
        float maxDistance = Mathf.Sqrt(centerX * centerX * 3 + centerY * centerY * 2);

        float dx = x - centerX;
        float dy = y - centerY;
        float distance = Mathf.Sqrt(dx * dx + dy * dy);

        return Mathf.Clamp01(1 - (distance / maxDistance));
    }
    float ApplyRadialMaskU(int x, int y)
    {
        
        float dx = x;
        float dy = y;
        float distance = Mathf.Sqrt(dx * dx + dy * dy);

        return Mathf.Clamp01(1 - (distance/3));
    }
    void FractalNoise()
    {   
        int octaves = 8;
        float amplitude = 0.5f;
        float frequency  = 2f;

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                SavedNoiseValue[x,y] = GenerateFractalNoise(x, y, octaves, amplitude, frequency );
                maskValues[x,y] = ApplyRadialMask(x, y);
            }
        }
    }

    void genmapover()
    {

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                float noiseValue = SavedNoiseValue[x,y];
                noiseValue *= maskValues[x,y];

                if (noiseValue < 0.45f + sealevel)
                    mapGrid[x, y] = TileType.Deepwater;
                else if (noiseValue < 0.5f + sealevel)
                    mapGrid[x, y] = TileType.Water;
                else if (noiseValue < 0.52f)
                    mapGrid[x, y] = TileType.Sand;
                else if (noiseValue < 0.57f)
                    mapGrid[x, y] = TileType.Land;
                else if (noiseValue < 0.6f)
                    mapGrid[x, y] = TileType.Farmland;
                else if (noiseValue < 0.67f)
                    mapGrid[x, y] = TileType.Land;
                else if (noiseValue < 0.69f)
                    mapGrid[x, y] = TileType.Forest;
                else if (noiseValue < 0.7f)
                    mapGrid[x, y] = TileType.Mountainlow;
                else if (noiseValue < 0.73f)
                    mapGrid[x, y] = TileType.Mountain;
                else if (noiseValue < 0.81f)
                    mapGrid[x, y] = TileType.Mountainhigh;
                else
                mapGrid[x, y] = TileType.Snow;
            }
        }
                   
    }
    void genmapunder()
    {
        int octavesU = 2;
        float amplitudeU = 1f;
        float frequencyU  = Random.Range(0.50f,3.00f);

        for (int x = 0; x < mapWidth; x++)
            {
            for (int y = 0; y < mapHeight; y++)
            {
                float noiseValueU = GenerateFractalNoise(x, y, octavesU, amplitudeU, frequencyU );

                if (noiseValueU < 0.5f)
                    mapGridUnder[x, y] = TileType.Coal;
                else if (noiseValueU > 0.95f)
                    mapGridUnder[x, y] = TileType.Iron;
                else
                    mapGridUnder[x, y] = TileType.None;
                
            }
        }
    }
    void RenderMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (mapGrid[x, y] != previousMapGrid[x, y])
                {
                    RuleTile tileToPlace = null;
                    switch (mapGrid[x, y])
                    {
                        case TileType.Sand: tileToPlace = sandTile; break;
                        case TileType.Water: tileToPlace = waterTile; break;
                        case TileType.Deepwater: tileToPlace = DeepwaterTile; break;
                        case TileType.Land: tileToPlace = landTile; break;
                        case TileType.Farmland: tileToPlace = farmlandTile; break;
                        case TileType.Forest: tileToPlace = forestTile; break;
                        case TileType.Mountain: tileToPlace = mountainTile; break;
                        case TileType.Mountainlow: tileToPlace = MountainlowTile; break;
                        case TileType.Mountainhigh: tileToPlace = MountainhighTile; break;
                        case TileType.Snow: tileToPlace = snowTile; break;
                        default: tileToPlace = null; break;
                    }

                    tilemapsurface.SetTile(new Vector3Int(x, y, 0), tileToPlace);
                    previousMapGrid[x, y] = mapGrid[x, y];
                }

                if (mapGridUnder[x, y] != previousMapGridUnder[x, y])
                {
                    RuleTile undergroundTileToPlace = null;
                    switch (mapGridUnder[x, y])
                    {
                        case TileType.Coal: undergroundTileToPlace = coalTile; break;
                        case TileType.Iron: undergroundTileToPlace = ironTile; break;
                        default: undergroundTileToPlace = null; break;
                    }

                    tilemapunder.SetTile(new Vector3Int(x, y, 0), undergroundTileToPlace);
                    previousMapGridUnder[x, y] = mapGridUnder[x, y];
                }
            }
        }
}
}
