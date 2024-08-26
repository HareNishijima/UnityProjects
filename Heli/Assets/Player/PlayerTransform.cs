using UnityEngine;

class PlayerTransform {
    public Vector2 position;
    public Quaternion quaternion;
    float speed= 10f;

    public PlayerTransform(Vector2 p, Quaternion q){
        position = p;
        quaternion = q;
    }

    public PlayerTransform Controller(Vector2 input){
        // 入力値から移動するベクトルを計算し、新しい座標を更新
        Vector2 moveVec = input * speed;
        Vector2 newPosition = moveVec * Time.deltaTime + position;

        float r = -input.x;
        if(r == 0f) r = input.y;
        Quaternion qua = Quaternion.Euler(0f, 0f, r * 45f);

        return new PlayerTransform(newPosition, qua);
    }
}