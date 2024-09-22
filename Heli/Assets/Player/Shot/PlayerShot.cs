using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject shotObject;
    PlayerShotController playerShotController;
    GameObject playerShotPositionObject;
    // Start is called before the first frame update
    void Start()
    {
        playerShotController = new PlayerShotController();
        // ショットを発射するオブジェクト
        // プレイヤーのやや前方にある
        playerShotPositionObject = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerShotController.Shot())
        {
            Instantiate(shotObject, playerShotPositionObject.transform.position, transform.rotation);
        }
    }
}
