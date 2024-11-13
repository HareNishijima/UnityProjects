using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockDeleter : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;

    GameObject MainCameraObject;

    void Start()
    {
        MainCameraObject = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        Vector3 cameraPos = MainCameraObject.transform.position;
        int y = Mathf.CeilToInt(cameraPos.y);

        for (int x = -19; x < 19; x++)
        {
            tilemap.SetTile(new Vector3Int(x, y - 10, 0), null);
        }
    }
}
