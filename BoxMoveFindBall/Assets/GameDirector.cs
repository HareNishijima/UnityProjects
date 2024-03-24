using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{

    public static int Size;
    public static string Mode = "Set1";
    public GameObject GoldenBall;
    public GameObject BoxSetScript;
    public GameObject BoxMoveScript;
    public GameObject Count_UI;
    public GameObject Cong_UI;

    public AudioClip SoundMove;
    public AudioClip SoundSelectStart;
    public AudioClip SoundNext;
    public AudioClip SoundFall;
    public AudioClip SoundCrear;

    public GameObject BoxSelectScript;
    Text cont_text;
    Text congratulation_text;

    public static int[] Ball_Level = new int[6] { 1, 2, 2, 3, 4, 5};
    public static int[] Size_Level = new int[6] { 2, 2, 3, 3, 4, 4};
    public static int Level = 0;

    private float time = 0;
    private int pos_x;
    private int pos_z;

    private int move_pos;
    private int move_sel;
    private int count = 0;

    public GameObject Stage;

    public static int Ball_count = 0;
    public static int penalty = 0;

    public static bool BoxMoveCheck = true;

    public GameObject CheckBoxScript;

    public GameObject DestroyBox;

    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        cont_text = Count_UI.GetComponent<Text>();
        congratulation_text=Cong_UI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        switch (Mode){

            case "Set1":
                count = 0;
                Ball_count = 0;
                penalty = 0;
                Size = Size_Level[Level];
                Camera.transform.position = new Vector3(0f, (Size+1.5f)*2+1, 0f);
                Instantiate(Stage, new Vector3(0f, 6f, 0f), Quaternion.identity);
                Mode = "Set2";
                break;

            case "Set2":
                if(time>3){
                    Mode = "BallSet";
                }
                break;
        
           case "BallSet":
                for (int i = 0; i < Ball_Level[Level]; i++){
                    pos_x = Random.Range(-Size, Size+1);
                    pos_z = Random.Range(-Size, Size+1);

                    Physics.Raycast(new Vector3(pos_x, 9f, pos_z), new Vector3(0f, -1f, 0f), out RaycastHit hit);

                    
                    if ( hit.collider.gameObject.tag == "GoldenBall")
                        i --;
                    else
                        Instantiate(GoldenBall, new Vector3(pos_x, 6.0f, pos_z), Quaternion.identity);             
                }

                time = 0;
                Mode = "BoxSet";
                break;

            case "BoxSet":
                if (time > 3)
                    {
                    BoxSetScript.GetComponent<BoxSetScript>().BoxSet();                    
                    GetComponent<AudioSource>().PlayOneShot(SoundFall);
                    time = -2f;
                    Mode = "BoxMoveSet";
                }                  
            break;

            case "BoxMoveSet":
                if(time>0.5){
                    cont_text.text = "";
                    BoxMoveCheck = true;
                    move_pos = Random.Range(-Size, Size+1);
                    move_sel = Random.Range(1, 5);
 
                    if (CheckBoxScript.GetComponent<CheckBoxScript>().CheckBox(move_pos,move_sel))
                    {
                        Mode = "BoxMove";
                    }
                    
                }
                break;

            case "BoxMove":               
                BoxMoveScript.GetComponent<BoxMoveScript>().BoxMove(move_pos, move_sel);
                count++;

                if(count%10==0){
                    GetComponent<AudioSource>().PlayOneShot(SoundMove);
                    Mode = "BoxMoveSet";
                    time = 0;
                    if (count >= 100)
                    {
                        Mode = "BoxSelect";
                        GetComponent<AudioSource>().PlayOneShot(SoundSelectStart);
                    }
                }
                break;

            case "BoxSelect":
                BoxSelectScript.GetComponent<BoxSelectScript>().BoxSelect();

                if (Ball_Level[Level]<=Ball_count){
                    cont_text.text = "Find!";
                    Mode = "Crear";
                    time = 0;                   
                }

                break;

            case "Crear":                
                if(time>6){
                    Instantiate(DestroyBox, new Vector3(0f, 0f, 0f), Quaternion.identity);
                    Mode = "Set1";
                    Level++;
                    if(Level==6){
                        Mode = "GameCrear";
                        GetComponent<AudioSource>().PlayOneShot(SoundCrear);
                    }
                    time = 0;
                }
                else if(time>3){
                    cont_text.text = "";
                    Camera.transform.Translate(0f,0.1f,0f);
                    if(time<3.1f){
                        GetComponent<AudioSource>().PlayOneShot(SoundNext);
                    }
                }
                break;

            case "GameCrear":
                congratulation_text.text = "congratulation!";
                if(time>3){
                    SceneManager.LoadScene("Title");
                }
                break;

        }

    }

   


}
