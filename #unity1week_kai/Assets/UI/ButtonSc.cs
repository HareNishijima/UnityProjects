using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSc : MonoBehaviour
{
    GameDirectorSc game_dir_sc;
    void Start(){
        game_dir_sc=GameObject.FindWithTag("GameDirector").GetComponent<GameDirectorSc>();
    }

    public void StartButton(){
        this.gameObject.SetActive(false);
        game_dir_sc.ToPlay();
    }

    public void RetryButton(){
        //gameObject.transform.parent.gameObject.SetActive(false);
        game_dir_sc.ToRetry();
    }

    public void ShareButton(){
        //本文＋ハッシュタグツイート（画像なし）
        int money=game_dir_sc.ReturnScore();
        naichilab.UnityRoomTweet.Tweet ("YOUR-GAMEID", "回工船で"+money.ToString()+"円稼ぎました！", "unityroom", "unity1week");      
        //game_dir_sc.ToReady();
    }

    public void OptionButton(){
        //音量ゲージ

        //リトライボタン
    }

}
