using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    enum State { Ready, Play, GameOver };
    State state;

    void Start()
    {
        state = State.Play;
        new TimeScaleManager().UpdateTimeScale(1f);
    }

    void Update()
    {
        if (state == State.GameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void ToGameOver()
    {
        state = State.GameOver;
        new TimeScaleManager().UpdateTimeScale(0f);
    }
}
