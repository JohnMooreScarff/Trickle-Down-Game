using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGen : MonoBehaviour
{
    public Tilemap tilemap;
    public AnimatedTile waterTile, landTile, farmlandTile, forestTile, mountainTile, coalTile, ironTile;

    public enum TileType
    {
        Water,
        Land,
        Farmland,
        Forest,
        Mountain,
        Coal,
        Iron
    }

    private TileType[,] mapGrid;
    private int mapWidth = 500;
    private int mapHeight =500;
    public float scale = 0.1f;

    void Start()
    {
        mapGrid = new TileType[mapWidth, mapHeight];

        // Generate base terrain
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                float noiseValue = Mathf.PerlinNoise(x * scale, y * scale);

                if (noiseValue < 0.3f)
                    mapGrid[x, y] = TileType.Water;
                else if (noiseValue < 0.5f)
                    mapGrid[x, y] = TileType.Land;
                else if (noiseValue < 0.7f)
                    mapGrid[x, y] = TileType.Forest;
                else
                    mapGrid[x, y] = TileType.Mountain;
            }
        }

        RenderMap();
    }

    bool IsNearTileType(int x, int y, TileType type)
    {
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int nx = x + dx;
                int ny = y + dy;
                if (nx >= 0 && nx < mapWidth && ny >= 0 && ny < mapHeight)
                {
                    if (mapGrid[nx, ny] == type)
                        return true;
                }
            }
        }
        return false;
    }

    void RenderMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                AnimatedTile tileToPlace = null;
                switch (mapGrid[x, y])
                {
                    case TileType.Water: tileToPlace = waterTile; break;
                    case TileType.Land: tileToPlace = landTile; break;
                    case TileType.Farmland: tileToPlace = farmlandTile; break;
                    case TileType.Forest: tileToPlace = forestTile; break;
                    case TileType.Mountain: tileToPlace = mountainTile; break;
                    case TileType.Coal: tileToPlace = coalTile; break;
                    case TileType.Iron: tileToPlace = ironTile; break;
                }
                if (tileToPlace != null)
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileToPlace);
            }
        }
    }
}
