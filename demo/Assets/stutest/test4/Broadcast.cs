using UnityEngine;
using UnityEngine.UI;

public class Broadcast : MonoBehaviour
{
    private Text text;
    private string originText;
    private float intervalTime = 0.02f;
    private float waitTime;
    private int index = 0;
    private string headTag = "<color=green>";
    private string endTag = "</color>";

    private void Start()
    {
        text = GetComponent<Text>();
        originText = text.text;
    }

    private void Update()
    {
        waitTime += Time.deltaTime;
        if (waitTime > intervalTime && index <= originText.Length)
        {
            text.text = headTag + originText.Insert(index++, endTag);
            waitTime = 0;
        }
    }
}