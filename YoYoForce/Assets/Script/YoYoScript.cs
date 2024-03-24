using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YoYoScript : MonoBehaviour
{

    private bool shot;
    private Vector3 point;
    private Vector3 home_pos;
    private Vector3 goal_pos;
    private Vector3 vec;
    private Vector3 move;
    public float speed;
    private float limit;
    private float distance;
    private float theta;
    private float inc_theta;
    public float decay_start_distance;
    private float home_distance;
    private float set_theta;

    private int hit;
    private GameObject hit_obj;
    private Text hit_text;

    private GameObject canvas_obj;

    private float time;

    private LineRenderer renderer;

    /*
     * マウスポインターの場所に向かってヨーヨーが発射される
     * 目的地点との距離に応じて速度が減衰し　目的地点でちょうど速度が0になる
     * そして進行方向が逆になって同じことを行う
     */


    // Start is called before the first frame update
    void Start()
    {
        shot = false;
        home_pos = this.transform.position;
        theta = 0f;
        hit_obj = Data.hit_obj;
        hit_text = hit_obj.GetComponent<Text>();
        canvas_obj = Data.canvas_obj;

        renderer = this.GetComponent<LineRenderer>();
        renderer.SetWidth(0.1f, 0.1f);
        renderer.SetVertexCount(2);
        renderer.SetPosition(0, home_pos);
        renderer.SetPosition(1, home_pos);
        hit = 0;
    }

    void Update(){
        if (!shot)
        {
            hit = 0;
            return;
        }

        distance = Vector3.Distance(this.transform.position, goal_pos);
        renderer.SetPosition(1, this.transform.position);

        if (distance > home_distance)
        {
            shot = false;
            this.transform.position = home_pos;
            theta = 0f;
            move = new Vector3(0f, 0f, 0f);
            hit = 0;
        }else if(distance <= decay_start_distance)
        {
            theta += inc_theta * set_theta;
        }
        transform.position += move * (Mathf.Sin(theta + inc_theta) - Mathf.Sin(theta));

    }

    public void Shot(Vector3 pos){

        if (shot) return;

        shot = true;
        goal_pos = pos;
        goal_pos.z = 0f;   
        inc_theta = Mathf.PI / 2f * Time.deltaTime;               
        home_distance= Vector3.Distance(home_pos, goal_pos);
        hit = 0;

        AudioDirectorScript.Play(Data.shot_se);

        //目的地点と初期地点との距離が既に減衰距離内だった場合はset_thetaの値を変更する
        if (home_distance < decay_start_distance)
        {
            set_theta =  speed / home_distance;
        }
        else{
            set_theta = speed / decay_start_distance;
        }

        move = Vector3.Normalize(goal_pos - home_pos) * speed;

    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            AudioDirectorScript.Play(Data.enemy_dead_se);
            Instantiate(Data.enemy_dead_particle, this.transform.position, Quaternion.Euler(90f, 0f, 0f));
            
            hit_text.text = (++hit).ToString() + "hit";
            //hit数がスコアの上昇数になる
            UIDirectorScript.Score(hit);

            /*
            var graphic = this.GetComponent<Graphic>();
            var camera = graphic.canvas.worldCamera;
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(graphic.rectTransform, col.transform.position, camera , out pos);         
            GameObject insta = Instantiate(hit_obj, canvas_obj.transform);
            insta.GetComponent<RectTransform>().localPosition = pos;

            GameObject insta = Instantiate(hit_obj, Data.canvas_obj.transform);
            //insta.GetComponent<RectTransform>().localPosition = RectTransformUtility.WorldToScreenPoint(

            insta.GetComponent<RectTransform>().localPosition = Data.camera_obj.WorldToScreenPoint(col.transform.position);

            //Data.camera_obj, col.gameObject.transform.position);

            Debug.Log(RectTransformUtility.WorldToScreenPoint(
            Data.camera_obj, col.gameObject.transform.position));
            */

            //Instantiate(hit_obj, Data.canvas_obj.transform);


            //↑屍の山
            GameObject insta_canvas = Instantiate(Data.hit_canvas_obj, col.gameObject.transform.position,Quaternion.identity);
            Instantiate(hit_obj, insta_canvas.transform);
            //GameObject insta = Instantiate(hit_obj, insta_canvas.transform);
            //Vector3 pos= RectTransformUtility.WorldToScreenPoint(Data.camera_obj, col.gameObject.transform.position);
            //ふざけんな　正解例
            //insta_canvas.transform.position = col.gameObject.transform.position;

            Destroy(col.gameObject);
        }

    }


}
