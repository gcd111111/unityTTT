using UnityEngine;
using Cinemachine;

public class freelook1 : MonoBehaviour
{
    private CinemachineFreeLook vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        // �Լ�ͨ�������ȡ x��y����������ͨ��ҡ�˻�ȡ�������Ҿ���Ȼʹ�� Mouse X �� Mouse Y��
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");
        // ����ƶ�
        vcam.m_XAxis.m_InputAxisValue = x;
        vcam.m_YAxis.m_InputAxisValue = y;
    }
}
