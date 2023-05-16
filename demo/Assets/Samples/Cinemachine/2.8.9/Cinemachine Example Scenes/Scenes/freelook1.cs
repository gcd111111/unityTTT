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
        // 自己通过代码获取 x、y分量，比如通过摇杆获取，这里我就仍然使用 Mouse X 和 Mouse Y吧
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");
        // 相机移动
        vcam.m_XAxis.m_InputAxisValue = x;
        vcam.m_YAxis.m_InputAxisValue = y;
    }
}
