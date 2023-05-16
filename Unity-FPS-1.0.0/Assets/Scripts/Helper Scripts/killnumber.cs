using UnityEngine;
using UnityEngine.UI;

public class killnumber : MonoBehaviour
{
    [SerializeField]
    private Text Kill_number;

    public void Display_KillStats(int killCount)
    {
        Kill_number.text="ÒÑ»÷É±£º"+killCount.ToString();
    }

}
