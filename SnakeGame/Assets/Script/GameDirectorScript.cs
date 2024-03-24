using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDirectorScript : MonoBehaviour
{
    //マップに関する情報
    const int map_size_x = 25;
    const int map_size_y = 18;
    //MAX 25,18
    const float offset_x = ((map_size_x + 1) * 0.5f) / 2f;
    const float offset_y = ((map_size_y + 1) * 0.5f) / 2f;

    private int map_size;
    private int map_used;

    private GameObject[,] map;


    //ゲームオブジェクト
    public GameObject snake;
    public GameObject wall;
    public GameObject food;

    public CameraScript camera_sc;

    private float time;
    private float span;
    public float speed;
    public static int score;

    [Header("音源")]
    public AudioClip start_se;
    public AudioClip input_se;
    public AudioClip get_se;
    public AudioClip miss_se;
    public AudioClip clear_se;

    //状態
    enum State
    {
        Ready, Play,GameOver
    }
    State state;

    //先頭のヘビ
    private Vector2 head_snake_pos;
    //末尾のヘビ
    private Vector2 tail_snake_pos;
    private Vector2 get_tail_snake_move;
    //移動方向
    private Vector2 move;
    //キー入力
    private Vector2 input_move;

    //アニメーションスピード
    public static float anim_speed;

    //ゲームの設定
    [Header("マップ端の壁")]
    public bool start_wall;
    [Header("食べ物の数")]
    public int start_food;
    [Header("追加の壁")]
    private bool add_wall;
    [Header("が出来る頻度")]
    private int add_wall_num;
    [Header("レベルアップ")]
    public int levelup;

    public OptionScript option_script;
    public GameObject score_board;
    public Animator score_board_anim;

    // Start is called before the first frame update
    void Start()
    {
        //初期宣言
        score_board_anim = score_board.GetComponent<Animator>();
        map = new GameObject[map_size_x + 2, map_size_y + 2];


        //ゲームプレイ準備
        ToReady();

    }

    // Update is called once per frameanimatoranimator
    void Update()
    {

        switch (state)
        {
            case State.Ready:
                //移動方向にキーを入力するとゲーム開始(スタート位置と方向は固定)
                input_move = new Vector2((int)Input.GetAxisRaw("Horizontal"), -(int)Input.GetAxisRaw("Vertical"));
                //入力した進行方向が反対方向でなく、iv!=((0,0)||(not0,not0))の時に進行方向を更新する(xorでやりたかった)
                //if ((v!=iv*-1) && ((iv!=new Vector2(0,0)) || iv!=new Vector2(0,0)))
                if ((move != input_move * -1) && (input_move != new Vector2(0, 0)) && !(input_move.x != 0 && input_move.y != 0))
                {
                    move = input_move;
                    AudioScript.Play(start_se);
                    state = State.Play;
                }
                else
                {
                    return;
                }
                break;
            case State.Play:
                //時間が経過しキー入力を受け付けるようになる
                time += Time.deltaTime * speed;
                InputMove(move);
                break;
            case State.GameOver:
                //スコアボードとオプション画面が下から現れる
                return;
        }

        //一定時間が経過するとヘビが移動方向に向かって移動する
        if (span < time)
        {
            if (move != input_move)
            {
                AudioScript.Play(input_se);
            }

            //移動方向の確定
            move = input_move;
            action();
            time = 0f;
        }
    }

    void action()
    {

        //マップ外へ移動しようとしている場合、moveを変更してマップの反対側から出現するようにする
        if (head_snake_pos.x + move.x > map_size_x + 1)
        {
            move.x -= map_size_x+2;
        } else if (head_snake_pos.x + move.x < 0)
        {
            move.x += map_size_x + 2;
        }
        if (head_snake_pos.y + move.y > map_size_y + 1)
        {
            move.y -= map_size_y + 2;
        }
        else if (head_snake_pos.y + move.y < 0)
        {
            move.y += map_size_y + 2;
        }

        //現在の先頭のヘビ(次のターンでは2番目になるヘビ)に移動方向を保存させる
        map[(int)head_snake_pos.x, (int)head_snake_pos.y].GetComponent<SnakeScript>().move = move;

        //先頭のヘビの情報を更新
        head_snake_pos += move;

        //先頭のヘビの座標をチェックする
        //食べ物を食べた、もしくはゲームオーバーならここでreturn　※末尾のヘビを消さない
        if (SnakeCheck(snake, (int)head_snake_pos.x, (int)head_snake_pos.y))
        {
            return;
        }

        //次のターンで末尾になるヘビの座標を取得する
        //現在の末尾のヘビに自身を破壊するアニメーションを実行させる
        get_tail_snake_move = map[(int)tail_snake_pos.x, (int)tail_snake_pos.y].GetComponent<SnakeScript>().SnakeDest();
        map[(int)tail_snake_pos.x, (int)tail_snake_pos.y] = null;
        tail_snake_pos += get_tail_snake_move;
    }

    //移動方向入力
    void InputMove(Vector2 v)
    {
        Vector2 iv = new Vector2((int)Input.GetAxisRaw("Horizontal"), -(int)Input.GetAxisRaw("Vertical"));
        //入力した進行方向が反対方向でなく、iv!=((0,0)||(not0,not0))の時に進行方向を更新する(xorでやりたかった)
        //if ((v!=iv*-1) && ((iv!=new Vector2(0,0)) || iv!=new Vector2(0,0)))
        if ((v != iv * -1) && (iv != new Vector2(0, 0)) && !(iv.x != 0 && iv.y != 0))
        {
            input_move = iv;

        }
        return;
    }


    //map配列内のチェック(ヘビ用)
    //指定した座標にあるオブジェクトの種類で実行内容が異なる
    bool SnakeCheck(GameObject obj, int x, int y)
    {
        //何もない
        if (map[x, y] == null)
        {
            //ヘビの頭を配置
            SetObj(obj, x, y);
            return false;
        }
        //食べ物がある
        else if (map[x, y].tag == "Food")
        {

            AudioScript.Play(get_se);

            //食べ物の破壊とヘビの頭を配置
            map[x, y].GetComponent<ObjectScript>().Dest();
            SetObj(obj, x, y);

            //ランダムな場所に食べ物を配置してポイントの増加
            RandomSetObj(food, head_snake_pos,move);
            score++;
            map_used++;

            //レベルアップ
            if ((score & levelup)==0)
            {
                LevelUp();
            }

            //追加の壁の生成
            if (add_wall_num!=0 && (score % add_wall_num) == 0)
            {
                RandomSetObj(wall,head_snake_pos, move);
                map_used++;
            }
            return true;
        }
        else//ヘビか壁ならば処理の停止
        {
            //カメラのアニメーション
            camera_sc.Shake(0.5f, 0.1f);
            AudioScript.Play(miss_se);
            ToGameOver();
            return true;
        }

    }

    //指定した座標にオブジェクトを配置する　※配置可能かの判断は行わない
    void SetObj(GameObject obj, int x, int y)
    {
        map[x, y] = Instantiate(obj, GetPos(x, y), Quaternion.identity);
    }

    //配列内での座標に応じたゲーム内での座標を返す
    Vector3 GetPos(int x,int y)
    {
        return new Vector3(x*0.5f- offset_x, -y*0.5f+ offset_y, 0f);
    }

    //ランダムでマップの空いている場所にオブジェクトを配置する
    //ただしプレイヤーの進行方向には配置しない
    void RandomSetObj(GameObject obj, Vector2 p, Vector2 v)
    {
        /* ヘビ+画面上にある食べ物+壁を計算し、その合計数がマップサイズの1/2以上を占めていた場合
         * whileループで座標をランダムで決めて配置する方法から
         * forループでマップの全要素を取得、要素がnullのインデックスを抽出しリストにまとめる
         * そのリストからランダムで一つ選択し、その座標に配置する
         * この時リスト長が0であればゲームクリア
         */

        //マップの使用済みスペースがマップサイズの半分以上の時に実行
        if (map_used >= ((float)map_size / 2f))
        {
            int list_count=0;
            List<Vector2> map_list=new List<Vector2>();

            //マップの全要素を取得
            //(未実装)ヘビが長いほど胴のヘビの座標は中々変化しなくなるので毎回全取得する必要はない
            for(int i=0;i< map_size_x+2; i++)
            {
                for (int j = 0; j < map_size_y+2; j++)
                {
                    if (map[i, j] == null)
                    {
                        map_list.Add(new Vector2(i, j));
                        list_count++;
                    }
                }
            }
            //list_countが0ならばもう配置する場所がないのでゲーム終了
            if (list_count == 0)
            {
                //ゲームクリア！
                AudioScript.Play(clear_se);
                ToGameOver();
                return;
            }

            //マップの空いた場所をランダムに一つ選択しその場所に配置
            Vector2 set_pos = map_list[Random.Range(0, list_count)];
            SetObj(obj, (int)set_pos.x, (int)set_pos.y);
            return;
        }
        else
        {
            //無限ループにはさせない
            for(int i=0;i<100;i++)
            {
                Vector2 set_pos = new Vector2(Random.Range(1, map_size_x + 1), Random.Range(1, map_size_y + 1));

                //進行方向によってx,y座標のどちらかが一致していた場合やり直し
                if ((v.x != 0) && (set_pos.y == p.y)) continue;
                else if ((v.y != 0) && (set_pos.x == p.x)) continue;

                if (map[(int)set_pos.x, (int)set_pos.y] == null)
                {
                    SetObj(obj, (int)set_pos.x, (int)set_pos.y);
                    break;
                }
            }
        }


    }

    //壁の作成
    void StartWallGenerate()
    {
        //外壁を作る
        for (int i = 0; i < map_size_x + 2; i++)
        {
            SetObj(wall, i, 0);
            SetObj(wall, i, map_size_y + 1);
        }
        for (int i = 1; i < map_size_y + 1; i++)
        {
            SetObj(wall, 0, i);
            SetObj(wall, map_size_x + 1, i);
        }
    }

    //レベルアップ
    void LevelUp()
    {
        if (span <= 0.1f)
        {
            return;
        }

        span -= 0.001f;
        anim_speed -= 0.001f;

    }

    //設定の反映
    void OptionReflection()
    {
        start_food = option_script.food_num;
        add_wall_num = option_script.block_num;
        start_wall = option_script.start_wall;
    }

    //ゲームオーバーになる処理
    void ToGameOver()
    {

        //一時停止
        StartCoroutine(Coroutine());
        //スコアの更新
        option_script.TextUpdate(option_script.score_text,score);
        //スコアボードがアニメーションを行う
        score_board_anim.SetTrigger("Set");
        state = State.GameOver;
    }

    //外部から呼び出す初期化宣言
    public void CallToReady()
    {
        ToReady();
    }

    //初期化宣言
    void ToReady()
    {
        //オプションの反映
        OptionReflection();
        score = 0;
        map_used = 0;
        span = 0.2f;
        time = span;
        anim_speed = 1f;

        int _start=0;
        int _end_i= map_size_x + 2;
        int _end_j= map_size_y + 2;

        if (start_wall)
        {
            map_size = map_size_x * map_size_y;
            //既に壁が配置してあるならば再配置する必要はない
            if ((map[0, 0]!=null) && (map[0, 0].gameObject.tag == "Wall"))
            {            
                _start = 1;
                _end_i = map_size_x + 1;
                _end_j = map_size_y + 1;
                MapInit(_start, _end_i, _end_j);
            }
            else
            {
                MapInit(_start, _end_i, _end_j);
                StartWallGenerate();
            }
        }
        else
        {
            map_size = (map_size_x + 2) * (map_size_y + 2);
            MapInit(_start, _end_i, _end_j);
        }



        //頭、胴、尾のヘビを初期配置する
        SetObj(snake, 3, 4);
        SetObj(snake, 2, 4);
        SetObj(snake, 1, 4);
        map_used += 3;
        //先頭のヘビ以外は進行方向を保存する
        map[2, 4].GetComponent<SnakeScript>().move = new Vector2(1, 0);
        map[1, 4].GetComponent<SnakeScript>().move = new Vector2(1, 0);
        //先頭のヘビと末尾のヘビがある座標を保存する
        head_snake_pos = new Vector2(3, 4);
        tail_snake_pos = new Vector2(1, 4);

        //移動方向の設定
        move = new Vector2(1, 0);
        input_move = new Vector2(0, 0);

        //食べ物をランダムに配置
        for (int i = 0; i < start_food; i++)
        {
            RandomSetObj(food, head_snake_pos, move);
            map_used++;
        }

        state = State.Ready;
    }

    //マップの初期化
    void MapInit(int _s,int _i,int _j)
    {
        for (int i = _s; i < _i; i++)
        {
            for (int j = _s; j < _j; j++)
            {

                if (map[i, j] != null)
                {
                    map[i, j].GetComponent<ObjectScript>().Dest();
                }
                map[i, j] = null;
            }
        }
    }

    //数秒だけ停止
    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2f);
    }

}

