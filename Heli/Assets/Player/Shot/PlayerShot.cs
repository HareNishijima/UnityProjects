using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject shotObject;
    PlayerShotController playerShotController;
    // Start is called before the first frame update
    void Start()
    {
        playerShotController = new PlayerShotController();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerShotController.Shot())
        {
            Instantiate(shotObject, transform.position, transform.rotation);
        }
    }
}
