using UnityEngine;

public class BulletInfo
{
    public string name; // �ڵ���
    public Color color; // �ڵ���ɫ
    public Vector3 flyDir; // �ڵ��ɳ�����
    public float speed; // �ڵ������ٶ�
    public float fireRange; // �ڵ����

    public BulletInfo(string name, Color color, Vector3 flyDir, float speed, float fireRange)
    {
        this.name = name;
        this.color = color;
        this.flyDir = flyDir;
        this.speed = speed;
        this.fireRange = fireRange;
    }
}