using UnityEngine;
using UnityEngine.UI;
 
public class SkillCD : MonoBehaviour
{
    //private Image skillWhiteImage;
    //private Text skillWaitText;
    public Image skillWhiteImage;
    public Text skillWaitText;
    private bool hasReleaseSkill = false;
    private float skillInterval = 2; // ������ȴʱ��
    private float skillWaitTime = 0; // �ͷż��ܺ�ȴ�ʱ��

    private void Start()
    {
        //���ַ�����ȡ�������ݲ���ԭ��
        //skillWhiteImage = transform.Find("White").GetComponent<Image>();
        //skillWaitText = transform.Find("Text").GetComponent<Text>();

        //skillWhiteImage = transform.Find("Circle/White").gameObject.GetComponent<Image>();
        //skillWaitText = transform.Find("Circle/Text").gameObject.GetComponent<Text>();
        skillWhiteImage.fillAmount = 0;
    }

    private void Update()
    {
        skillWaitTime += Time.deltaTime;
        if (!hasReleaseSkill && Input.GetMouseButtonDown(0))
        {
            releaseSkill();
        }
        waitSkill();
    }

    private void releaseSkill()
    { // �ͷż���
        skillWhiteImage.fillAmount = 1;
        skillWaitText.text = skillInterval.ToString("0.0");
        hasReleaseSkill = true;
        skillWaitTime = 0;
    }

    private void waitSkill()
    { // �ȴ����ܵ���
        if (hasReleaseSkill)
        {
            float resTime = skillInterval - skillWaitTime;
            skillWhiteImage.fillAmount = resTime / skillInterval;
            skillWaitText.text = resTime.ToString("0.0");
            if (skillWaitTime > skillInterval)
            {
                hasReleaseSkill = false;
                skillWaitText.text = "";
            }
        }
    }
}