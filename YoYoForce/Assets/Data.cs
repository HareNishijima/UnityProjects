using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static float enemy_limit_screen_x;
    public static float enemy_limit_screen_y;

    [Header("Audio")]
    public AudioClip _bgm;
    public static AudioClip bgm;
    public AudioClip _enemy_dead_se;
    public static AudioClip enemy_dead_se;
    public AudioClip _shot_se;
    public static AudioClip shot_se;
    public AudioClip _building_dead_se;
    public static AudioClip building_dead_se;
    public AudioClip _game_over_se;
    public static AudioClip game_over_se;

    [Header("Particle")]
    public GameObject _enemy_dead_particle;
    public static GameObject enemy_dead_particle;
    public GameObject _building_dead_particle;
    public static GameObject building_dead_particle;
    public GameObject _yoyo_dead_particle;
    public static GameObject yoyo_dead_particle;

    public List<GameObject> _building_list = new List<GameObject>();
    public static List<GameObject> building_list = new List<GameObject>();

    public GameObject _hit_obj;
    public static GameObject hit_obj;

    public GameObject _canvas_obj;
    public static GameObject canvas_obj;

    public GameObject _hit_canvas_obj;
    public static GameObject hit_canvas_obj;

    public Camera _camera_obj;
    public static Camera camera_obj;

    public static float insta_span;
    public static int insta_simultaneous;
    public static float insta_speed;
    public static int insta_speed_inc_level;

    public static float building_aim_point;

    public static int score;
    public static int level;

    void Awake()
    {

        enemy_dead_se = _enemy_dead_se;
        enemy_dead_particle = _enemy_dead_particle;

        shot_se = _shot_se;
        building_dead_se = _building_dead_se;
        game_over_se = _game_over_se;

        building_dead_particle = _building_dead_particle;
        yoyo_dead_particle = _yoyo_dead_particle;

        bgm = _bgm;

        score = 0;
        level = 0;

        building_list = _building_list;
        hit_obj = _hit_obj;
        canvas_obj = _canvas_obj;
        hit_canvas_obj = _hit_canvas_obj;
        camera_obj = _camera_obj;

        insta_span = 2f;
        insta_simultaneous = 1;
        insta_speed = 2f;
        insta_speed_inc_level = 30;

        building_aim_point = 0f;

        enemy_limit_screen_x = 9f;
        enemy_limit_screen_y = 6f;
    }

    //画面外に出たら破壊
    public static void OverScreenDestroy(GameObject obj, float x, float y)
    {
        if (Mathf.Abs(obj.transform.position.x) > x || Mathf.Abs(obj.transform.position.y) > y)
        {
            Destroy(obj.gameObject);
        }
    }

    //2点間の角度を取得
    public static float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dif = target - start;
        float rad = Mathf.Atan2(dif.y, dif.x);
        return rad * Mathf.Rad2Deg;
    }

    //オブジェクトの簡易移動関数
    public static IEnumerator ObjectMoveCoroutine(GameObject obj, float time, Vector3 start_pos, Vector3 target_pos)
    {
        Vector3 move = new Vector3(0f, 0f, 0f);
        float time_lerp = 0f;
        //オブジェクトの移動
        for (float timer = 0f; timer < time; timer += Time.deltaTime)
        {
            //timerをtimeを1とした0~1の数字に変換
            time_lerp = Mathf.InverseLerp(0, time, timer);
            //time_lerpの大きさに応じて座標の設定
            move.x = Mathf.Lerp(start_pos.x, target_pos.x, time_lerp);
            move.y = Mathf.Lerp(start_pos.y, target_pos.y, time_lerp);
            obj.transform.position = move;
            yield return null;
        }
        //最後に補正
        obj.transform.position = target_pos;
    }
}
