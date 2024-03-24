using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirectorScript : MonoBehaviour
{

    enum State{
        Ready,Play,GameOver
    }
    State state;

    public PlayerScript player;
    public WarningObjectGenerator warning_object_generator;
    public Button start_button;
    public GameObject title_logo;
    public GameObject gameover_logo;
    public Text score_text;

    private Button btn;

    void Start()
    {
        //最初は準備状態にする
        SetReady();
        btn = start_button.GetComponent<Button>();
        btn.onClick.AddListener(PressSartButton);
        
    }

    void Update()
    {
        switch(state){
            //スタートボタンを押したらゲームスタート
            case State.Ready:
                break;
            case State.Play:
                //プレイヤーが死んだらゲームオーバー              
                if(player.isDead){
                    SetGameOver();
                }                
                break;
            case State.GameOver:
                //タップしたらタイトルへ戻る
                if (Input.GetMouseButtonDown(0))
                {
                    Reload();
                }
                break;
        }
    }
    //ゲーム準備時の処理
    void SetReady(){
        state = State.Ready;
        gameover_logo.gameObject.SetActive(false);
        //オブジェクトは生成しない
        warning_object_generator.gameObject.SetActive(false);
        score_text.text = "";
    }

    //ゲームスタートする処理
    void SetPlay(){
        state = State.Play;
        //タイトルとボタンを消す
        title_logo.gameObject.SetActive(false);
        btn.gameObject.SetActive(false);
        //オブジェクトを生成するようにする
        warning_object_generator.gameObject.SetActive(true);
    }

    //ゲームオーバーになる処理
    void SetGameOver(){
        state = State.GameOver;
        //ゲームオーバーのロゴを表示させる
        gameover_logo.gameObject.SetActive(true);
        //スコアを表示させる
        score_text.text = "スコア "+ (warning_object_generator.generate_num-1).ToString();
    }
    
    //ゲームをリロードする処理
    void Reload(){
        Application.LoadLevel(Application.loadedLevel);
    }

    //スタートボタンを押したらゲームを始める
    void PressSartButton(){
        SetPlay();
    }

}
