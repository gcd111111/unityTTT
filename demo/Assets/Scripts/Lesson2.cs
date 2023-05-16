using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//׼�����ݽṹ��
public class PlayerInfo3
{
    public string name;
    public int age;
    public bool sex;
    public float speed;
    public int[] ids;
    public List<int> ids2;
    public Dictionary<int, string> dic;
    public Item3 item1;
    public List<Item3> item2;
    private int testPrivate = 1;
    protected int testProtected = 2;
}
public class Item3
{
    public int id;
    public int num;
    public Item3(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}
public class Lesson2 : MonoBehaviour
{
    void Start()
    {
        //�������� ����ʼ������
        PlayerInfo3 p = new PlayerInfo3();
        p.name = "������ʿ1��";
        p.age = 24;
        p.sex = true;
        p.speed = 56.7f;
        p.ids = new int[] { 1, 2, 3 };
        p.ids2 = new List<int>() { 4, 5, 6 };
        p.dic = new Dictionary<int, string>() { { 1, "��" }, { 2, "��" } };
        p.item1 = new Item3(1, 10);
        p.item2 = new List<Item3>() { new Item3(2, 4), new Item3(3, 99) };
        //���л��˶���
        //������������л�Ϊ��Json�ַ�����
        string jsonStr = JsonMapper.ToJson(p);
        //�����л�����ַ����浽����
        File.WriteAllText(Application.persistentDataPath + "/PlayerInfoJson3.json", jsonStr);
        Debug.Log(Application.persistentDataPath);
    }
}
