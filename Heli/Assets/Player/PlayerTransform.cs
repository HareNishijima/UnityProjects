using UnityEngine;

class PlayerTransform
{
    public Vector2 position;
    public Quaternion quaternion;
    float speed = 10f;

    public PlayerTransform(Vector2 p, Quaternion q)
    {
        position = p;
        quaternion = q;
    }

    public PlayerTransform Controller(Vector2 input)
    {
        // 入力値から移動するベクトルを計算し、新しい座標を更新
        Vector2 moveVec = input * speed;
        Vector2 newPosition = moveVec * Time.deltaTime + position;

        float angleZ = quaternion.eulerAngles.z;
        if (angleZ > 180f) angleZ -= 360f;
        float newAngleZ = angleZ;
        if (input.x != 0f)
        {
            newAngleZ += -input.x;
        }
        else if (input.y != 0f)
        {
            newAngleZ += input.y;
        }
        else
        {
            // newAngleZが徐々に0に近づく
        }
        newAngleZ = Mathf.Clamp(newAngleZ, -45f, 45f);
        Quaternion qua = Quaternion.Euler(0f, 0f, newAngleZ);

        return new PlayerTransform(newPosition, qua);
    }

    float Mapping(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return Mathf.Lerp(outMin, outMax, Mathf.InverseLerp(inMin, inMax, value));
    }
}