using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class ZXingQRCodeWrapper_ScanQRCode : MonoBehaviour
{
    [Header("摄像机检测界面")]
    public RawImage cameraTexture;//摄像机映射显示区域
    public Text text;//用来显示扫描信息
    public Button scanningButton;

    private WebCamTexture webCamTexture;//摄像机映射纹理

    //二维码识别类
    BarcodeReader barcodeReader;//库文件的对象（二维码信息保存的地方）



    /// <summary>
    /// Start 初始化函数
    /// </summary>
    private void Start()
    {
        scanningButton.onClick.AddListener(ScanningButtonClick);
    }


    private void Update()
    {
        if (IsScanning)
        {
            //每隔一段时间进行一次识别二维码信息
            interval += Time.deltaTime;
            if (interval >= 3)
            {
                interval = 0;
                ScanQRCode();//开始扫描
            }
        }
    }


    /// <summary>
    /// 开启摄像机和准备工作
    /// </summary>
    void DeviceInit()
    {
        //1、获取所有摄像机硬件
        WebCamDevice[] devices = WebCamTexture.devices;
        //2、获取第一个摄像机硬件的名称
        string deviceName = devices[0].name;//手机后置摄像机
        //3、创建实例化一个摄像机显示区域
        webCamTexture = new WebCamTexture(deviceName, 400, 300);
        //4、显示的图片信息
        cameraTexture.texture = webCamTexture;
        //5、打开摄像机运行识别
        webCamTexture.Play();

        //6、实例化识别二维码信息存储对象
        barcodeReader = new BarcodeReader();
    }

    Color32[] data;//二维码图片信息以像素点颜色信息数组存放

    /// <summary>
    /// 识别摄像机图片中的二维码信息
    /// 打印二维码识别到的信息
    /// </summary>
    void ScanQRCode()
    {
        //7、获取摄像机画面的像素颜色数组信息
        data = webCamTexture.GetPixels32();
        //8、获取图片中的二维码信息
        Result result = barcodeReader.Decode(data, webCamTexture.width, webCamTexture.height);
        //如果获取到二维码信息了，打印出来
        if (result != null)
        {
            Debug.Log(result.Text);//二维码识别出来的信息
            text.text = result.Text;//显示扫描信息

            //扫描成功之后的处理
            IsScanning = false;
            webCamTexture.Stop();
        }
    }





    bool IsScanning = false;
    float interval = 0.5f;//扫描识别时间间隔    
    void ScanningButtonClick()
    {
        DeviceInit();
        IsScanning = true;
    }

}