using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirectorScript : MonoBehaviour
{


    enum State{Title,Play,GameOver}
    State state;

    public GameObject rogo_obj;
    private SpriteRenderer rogo_renderer;
    public Sprite title;
    public Sprite gameover;
    public EnemyGeneratorScript em_gene_sc;
    public AudioDirectorScript ad_dir_sc;
    public UIDirectorScript ui_dir_sc;

    public GameObject ranking_button;
    public GameObject start_button;
    public GameObject restart_button;

    //シングルトン
    private static GameDirectorScript instance;
    void Awake(){
        //DontDestroyOnLoad(this);
        if(instance==null) instance = this;
        rogo_renderer = rogo_obj.GetComponent<SpriteRenderer>();
    }

    public static GameDirectorScript GetInstance()
    {
        return instance;
    }


    public static void CallGameOver()
    {
        GetInstance().ToGameOver();
    }
    
    void Start(){

        ToTitle();
    }


    public void StartButton()
    {
        ToPlay();
    }

    public void ReStartButton(){
        ToRetry();
    }


    void ToTitle(){
        rogo_renderer.sprite = title;
        state = State.Title;
        EnemyData.player_dead = false;
        em_gene_sc.enabled = false;
        ad_dir_sc.enabled = false;
        start_button.SetActive(true);
        ranking_button.SetActive(false);
        restart_button.SetActive(false);
    }

    void ToPlay(){
        //プレイヤーの動作や敵の出現などに関するオブジェクトを探してアクティブにする
        state = State.Play;
        AudioDirectorScript.Play(Data.bgm);
        StartCoroutine(Data.ObjectMoveCoroutine(rogo_obj, 1f, rogo_obj.transform.position, new Vector3(0f, 8f, 0f)));
        em_gene_sc.enabled = true;
        ad_dir_sc.enabled = true;
        start_button.SetActive(false);
    }

    void ToGameOver(){
        state = State.GameOver;
        rogo_obj.transform.position = new Vector3(0f, 1f, 0f);
        rogo_renderer.sprite = gameover;
        //BGMだけを停止したかったが出来なかった(出来ないわけではないと思う)
        AudioDirectorScript.Stop();
        AudioDirectorScript.Play(Data.building_dead_se);
        AudioDirectorScript.Play(Data.game_over_se);
        EnemyData.player_dead = true;
        em_gene_sc.enabled = false;
        ad_dir_sc.enabled = false;
        ranking_button.SetActive(true);
        restart_button.SetActive(true);
    }

    void ToRetry(){
        state = State.Play;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
