using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDirector : MonoBehaviour
{
    enum GameScene { Ready, Play, GameOver, Clear }
    [SerializeField] GameScene gameScene;

    // Start is called before the first frame update
    void Start()
    {
        gameScene = GameScene.Play;
    }

    public bool IsPlay()
    {
        return gameScene == GameScene.Play;
    }

    public bool IsClear()
    {
        return gameScene == GameScene.Clear;
    }

    public void ToClear()
    {
        gameScene = GameScene.Clear;
    }
}
