using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorSc : MonoBehaviour
{

    int score;
    int time;
    public float speed;
    UIDirectorSc ui_dir_sc;
    AudioDirectorSc audio_dir_sc; 
    enum State{Ready,Play,GameOver};
    State state;
    public int max_time;

    // Start is called before the first frame update
    void Awake()
    {  
        ui_dir_sc=GameObject.FindWithTag("UIDirector").GetComponent<UIDirectorSc>();
        audio_dir_sc=GameObject.FindWithTag("AudioDirector").GetComponent<AudioDirectorSc>();
        ToReady();
    }


    void Update(){
        switch(state){
	        case State.Ready:
                //スタートボタンを押したら始める
                
		        break;
	        case State.Play:
                if(time<=0){
                    ToGameOver();
                }
		        break;
	        case State.GameOver:
		        break;
        }        
    }

    public void ToReady(){
        state=State.Ready;  
        time=max_time;
        score=0;
        speed=0.02f;
        ui_dir_sc.TimeTextUpdate(time);  
        GetComponent<KaiGeneratorSc>().enabled=false;
        ui_dir_sc.TitleText("回工船");
        ui_dir_sc.TitleTextBool(true);
        ui_dir_sc.ResultText(false,score);
        ui_dir_sc.ResultScreenBool(false);
        ui_dir_sc.HowToScreenBool(true);
    }

    public void ToPlay(){
        state=State.Play;
        StartCoroutine(CoroutineTime());
        GetComponent<KaiGeneratorSc>().enabled=true;
        GetComponent<PickUpSc>().enabled=true;
        ui_dir_sc.TitleTextBool(false);
        audio_dir_sc.AudioOneShot(2);
        ui_dir_sc.HowToScreenBool(false);
    }

    public void ToGameOver(){
        state=State.GameOver;
        GetComponent<KaiGeneratorSc>().enabled=false;
        GetComponent<PickUpSc>().enabled=false;
        ui_dir_sc.TitleText("作業終了");
        ui_dir_sc.ResultText(true,score);
        ui_dir_sc.TitleTextBool(true);
        audio_dir_sc.AudioOneShot(0);
        ui_dir_sc.ResultScreenBool(true);
    }

    public void ToRetry(){
        state=State.Play;
        //タグ"Kai"のオブジェクトを全破壊する
        GameObject[] obj_array=GameObject.FindGameObjectsWithTag("Kai");
        foreach(GameObject obj in obj_array){
            Destroy(obj);
        }
        time=max_time;
        score=0;
        speed=0.02f;
        ui_dir_sc.TimeTextUpdate(time);
        ui_dir_sc.ResultScreenBool(false);
        ui_dir_sc.ResultText(false,score);
        StartCoroutine(CoroutineTime());
        GetComponent<KaiGeneratorSc>().enabled=true;
        GetComponent<PickUpSc>().enabled=true;
        ui_dir_sc.TitleTextBool(false);
        audio_dir_sc.AudioOneShot(2);
    }

    public void IncScore(int v){
        score+=v;
    }
    
    void IncTime(int v){
        time+=v;
        ui_dir_sc.TimeTextUpdate(time);
    }

    void IncSpeed(float v){
        speed+=v;
    }

    public int ReturnScore(){
        return score;
    }

    IEnumerator CoroutineTime(){
        while(state==State.Play){
            IncTime(-1);
            IncSpeed(0.001f);
            yield return new WaitForSeconds(1f);
        }
    } 

}
