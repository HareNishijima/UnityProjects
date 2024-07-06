using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVec
{
    private readonly Vector2 maxVec;

    private readonly Vector2 playerVec;

    public PlayerVec(Vector2 vec){

        if(maxVec.x < vec.x || maxVec.y < vec.y){
            throw new System.ArgumentOutOfRangeException();
        }

        playerVec = vec;
    }

    public PlayerVec setPlayerVec(Vector2 vec){
        return new PlayerVec(vec);
    }
}
