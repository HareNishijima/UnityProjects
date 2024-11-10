using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile blockTile;

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 12; y < 30; y += 3)
        {

            int x = Random.Range(-15, 15);
            int diff = Random.Range(-1, 2);

            tilemap.SetTile(new Vector3Int(x - 1, y + diff, 0), blockTile);
            tilemap.SetTile(new Vector3Int(x, y + diff, 0), blockTile);
            tilemap.SetTile(new Vector3Int(x + 1, y + diff, 0), blockTile);

        }

    }
}
