using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile blockTile;

    public int startY;
    public int EndY;

    // Start is called before the first frame update
    void Start()
    {
        // 等間隔に大きい足場を生成する
        for (int y = startY; y < EndY; y += 10)
        {
            int x = Random.Range(-4, 5);

            tilemap.SetTile(new Vector3Int(x - 3, y, 0), blockTile);
            tilemap.SetTile(new Vector3Int(x - 2, y, 0), blockTile);
            tilemap.SetTile(new Vector3Int(x - 1, y, 0), blockTile);
            tilemap.SetTile(new Vector3Int(x, y, 0), blockTile);
            tilemap.SetTile(new Vector3Int(x + 1, y, 0), blockTile);
            tilemap.SetTile(new Vector3Int(x + 2, y, 0), blockTile);
            tilemap.SetTile(new Vector3Int(x + 3, y, 0), blockTile);
        }

    }
}
