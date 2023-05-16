using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class ZXingQRCodeWrapper_ScanQRCode : MonoBehaviour
{
    [Header("�����������")]
    public RawImage cameraTexture;//�����ӳ����ʾ����
    public Text text;//������ʾɨ����Ϣ
    public Button scanningButton;

    private WebCamTexture webCamTexture;//�����ӳ������

    //��ά��ʶ����
    BarcodeReader barcodeReader;//���ļ��Ķ��󣨶�ά����Ϣ����ĵط���



    /// <summary>
    /// Start ��ʼ������
    /// </summary>
    private void Start()
    {
        scanningButton.onClick.AddListener(ScanningButtonClick);
    }


    private void Update()
    {
        if (IsScanning)
        {
            //ÿ��һ��ʱ�����һ��ʶ���ά����Ϣ
            interval += Time.deltaTime;
            if (interval >= 3)
            {
                interval = 0;
                ScanQRCode();//��ʼɨ��
            }
        }
    }


    /// <summary>
    /// �����������׼������
    /// </summary>
    void DeviceInit()
    {
        //1����ȡ���������Ӳ��
        WebCamDevice[] devices = WebCamTexture.devices;
        //2����ȡ��һ�������Ӳ��������
        string deviceName = devices[0].name;//�ֻ����������
        //3������ʵ����һ���������ʾ����
        webCamTexture = new WebCamTexture(deviceName, 400, 300);
        //4����ʾ��ͼƬ��Ϣ
        cameraTexture.texture = webCamTexture;
        //5�������������ʶ��
        webCamTexture.Play();

        //6��ʵ����ʶ���ά����Ϣ�洢����
        barcodeReader = new BarcodeReader();
    }

    Color32[] data;//��ά��ͼƬ��Ϣ�����ص���ɫ��Ϣ������

    /// <summary>
    /// ʶ�������ͼƬ�еĶ�ά����Ϣ
    /// ��ӡ��ά��ʶ�𵽵���Ϣ
    /// </summary>
    void ScanQRCode()
    {
        //7����ȡ����������������ɫ������Ϣ
        data = webCamTexture.GetPixels32();
        //8����ȡͼƬ�еĶ�ά����Ϣ
        Result result = barcodeReader.Decode(data, webCamTexture.width, webCamTexture.height);
        //�����ȡ����ά����Ϣ�ˣ���ӡ����
        if (result != null)
        {
            Debug.Log(result.Text);//��ά��ʶ���������Ϣ
            text.text = result.Text;//��ʾɨ����Ϣ

            //ɨ��ɹ�֮��Ĵ���
            IsScanning = false;
            webCamTexture.Stop();
        }
    }





    bool IsScanning = false;
    float interval = 0.5f;//ɨ��ʶ��ʱ����    
    void ScanningButtonClick()
    {
        DeviceInit();
        IsScanning = true;
    }

}