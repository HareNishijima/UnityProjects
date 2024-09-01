using UnityEngine;

public class PlayerShotController
{
    Controller controller;
    float lastShotTime;
    // 発射後、次の発射が可能になるまでの時間
    float coolTime;

    // Start is called before the first frame update
    public PlayerShotController()
    {
        controller = new Controller();
        lastShotTime = Time.time;
        coolTime = 0.1f;
    }

    // Update is called once per frame
    public bool Shot()
    {
        bool fire1Input = controller.Fire1Input();
        if (!fire1Input) return false;

        // 最後に発射した時間と現在の時間の差がクールタイム以上ならtrue
        float lastShotTimeSpan = Time.time - lastShotTime;
        if (lastShotTimeSpan > coolTime)
        {
            lastShotTime = Time.time;
            return true;
        }
        return false;
    }
}
