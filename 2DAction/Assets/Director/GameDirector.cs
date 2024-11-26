using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    SceneDirector sceneDirector;

    // Start is called before the first frame update
    void Start()
    {
        sceneDirector = GetComponent<SceneDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneDirector.IsClear() && Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Sample");
        }
    }
}
