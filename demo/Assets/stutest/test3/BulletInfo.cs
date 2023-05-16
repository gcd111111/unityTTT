using UnityEngine;

public class BulletInfo
{
    public string name; // 炮弹名
    public Color color; // 炮弹颜色
    public Vector3 flyDir; // 炮弹飞出方向
    public float speed; // 炮弹飞行速度
    public float fireRange; // 炮弹射程

    public BulletInfo(string name, Color color, Vector3 flyDir, float speed, float fireRange)
    {
        this.name = name;
        this.color = color;
        this.flyDir = flyDir;
        this.speed = speed;
        this.fireRange = fireRange;
    }
}