using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//准备数据结构类
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
        //声明对象 并初始化数据
        PlayerInfo3 p = new PlayerInfo3();
        p.name = "假面骑士1号";
        p.age = 24;
        p.sex = true;
        p.speed = 56.7f;
        p.ids = new int[] { 1, 2, 3 };
        p.ids2 = new List<int>() { 4, 5, 6 };
        p.dic = new Dictionary<int, string>() { { 1, "啊" }, { 2, "哈" } };
        p.item1 = new Item3(1, 10);
        p.item2 = new List<Item3>() { new Item3(2, 4), new Item3(3, 99) };
        //序列化此对象
        //（把类对象序列化为了Json字符串）
        string jsonStr = JsonMapper.ToJson(p);
        //把序列化后的字符串存到本地
        File.WriteAllText(Application.persistentDataPath + "/PlayerInfoJson3.json", jsonStr);
        Debug.Log(Application.persistentDataPath);
    }
}
