using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killnumber : MonoBehaviour
{
    public int kill_number = 0;
    private Text Kill_number;
    //µ¥Àý
    public static killnumber instance;
    void Awake()
    {
        MakeInstance();
        Kill_number = GameObject.Find("UI Canvas/totalKillCount").GetComponent<Text>();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //    private void killnumber()
    //    {
    //        killnumber.instance.GetComponent<killnumber>().kill_number = 0;
    //        Kill_number.text = "ÒÑ»÷É±£º" + (killnumber.instance.GetComponent<killnumber>().kill_number + 1).ToString();
    //    }
}
