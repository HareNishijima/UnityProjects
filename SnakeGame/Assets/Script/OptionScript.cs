using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour
{
    public int food_num;
    public int block_num;
    public bool start_wall;
    public Text score_text;
    public Text food_text;
    public Text block_text;

    public AudioClip inc_se;
    public AudioClip dec_se;
    public AudioClip ok_se;
    public AudioClip restart_se;

    private int thisgame_food_num;
    private int thisgame_block_num;

    void Awake()
    {
        food_num = 1;
        thisgame_food_num = food_num;
        block_num = 0;
        thisgame_block_num = block_num;
        start_wall = true;
        TextUpdate(food_text, food_num);
        TextUpdate(block_text, block_num);
    }

    public void TextUpdate(Text t,int n)
    {
        t.text = n.ToString();
    }

    public void FoodButton(int v)
    {
        food_num += v;
        food_num = Mathf.Clamp(food_num, 1,99);
        if (v > 0)
        {
            AudioScript.Play(inc_se);
        }
        else
        {
            AudioScript.Play(dec_se);
        }
        TextUpdate(food_text,food_num);
    }

    public void BlockButton(int v)
    {
        block_num += v;
        block_num = Mathf.Clamp(block_num, 0, 99);
        if (v > 0)
        {
            AudioScript.Play(inc_se);
        }
        else
        {
            AudioScript.Play(dec_se);
        }
        TextUpdate(block_text, block_num);
    }

    public void StartWallButton()
    {
        AudioScript.Play(ok_se);
        start_wall = !(start_wall);
    }

    public void ReStartButton(GameDirectorScript game_dir_sc)
    {
        thisgame_food_num = food_num;
        thisgame_block_num = block_num;
        AudioScript.Play(restart_se);
        game_dir_sc.score_board_anim.SetTrigger("Set");
        game_dir_sc.CallToReady();
    }

    public void Tweet()
    {
        AudioScript.Play(ok_se);
        naichilab.UnityRoomTweet.Tweet("hare_snake_game", "ヘビゲームをプレイして\n" +
            "Food：" + thisgame_food_num.ToString()+ "\n"+
            "Block：" + thisgame_block_num.ToString() + "\n" +
            "Score：" + GameDirectorScript.score.ToString() + "\n"+
            "の成績を残しました！"
            , "unity");
    }

}
