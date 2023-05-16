//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IE : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
//        //---------------����Э��
//        // ��ʽһ
//        //StartCoroutine(CorutineTest());
//        //StartCoroutine(CorutineTest("arg"));
//        //// ��ʽ��, �˷�ʽ���ֻ�ܴ�1������
//        //StartCoroutine("CorutineTest");
//        //StartCoroutine("CorutineTest", "arg");
//        //// ��ʽ��
//        //IEnumerator corutin = CorutineTest();
//        //StartCoroutine(corutin);

//        //-----------------ֹͣЭ��
//        //public void StopCoroutine(Coroutine routine);
//        //public void StopCoroutine(IEnumerator routine);
//        //public void StopCoroutine(string methodName); // ֻ��ֹͣ���ַ�������������Э��
//        //public void StopAllCoroutines();
//        //yield break; // ����Э��
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    //����Э��
//    private IEnumerator CorutineTest()
//    {
//        Debug.Log("CorutineTest, 1");
//        yield return null;
//        Debug.Log("CorutineTest, 2");
//        yield return new WaitForSeconds(0.05f);
//        Debug.Log("CorutineTest, 3");
//        yield return new WaitForFixedUpdate();
//        Debug.Log("CorutineTest, 4");
//        yield return new WWW("https://mazwai.com/download_new.php?hash=b524357ef93c1e6ad0245c04c721e479");
//        Debug.Log("CorutineTest, 5");
//    }
//    //private IEnumerator Start()
//    //{ // ��ʱ�����в�����������Start����
//    //    yield return StartCoroutine(CorutineTest());
//    //}
//}

//---------------------�ж�ָ��
//// Э�������нű���FixedUpdateִ��֮��,�ȴ�һ��fixedʱ����֮���ټ���ִ��
//yield return WaitForFixedUpdate();
//// Э�̽�����һ֡���нű���Updateִ��֮��,�ټ���ִ��
//yield return null;
//// Э�����ӳ�ָ��ʱ��,�ҵ�ǰ֡���нű��� Updateȫ��ִ�н�����ż���ִ��
//yield return new WaitForSeconds(seconds);
//// ��WaitForSeconds����, ������ʱ������Ӱ��
//yield return WaitForSecondsRealtime(seconds);
//// Э����WWW������Դ��ɺ�,�ټ���ִ��
//yield return new WWW(url);
//// Э����ָ��Э��ִ�н�����,�ټ���ִ��
//yield return StartCoroutine();
//// ����������Ϊ��ʱ��ִ�к�������
//yield return WaitWhile();
//// �ȴ�֡������Ⱦ����
//yield return new WaitForEndOfFrame();

//---------------����һ��
//using System.Collections;
//using UnityEngine;

//public class IE : MonoBehaviour
//{
//    private void Start()
//    {
//        Debug.Log("Start-before");
//        StartCoroutine(CorutineTest(3));
//        Debug.Log("Start-after");
//    }

//    private void Update()
//    {
//        Debug.Log("Update");
//    }

//    private IEnumerator CorutineTest(int count)
//    {
//        Debug.Log("CorutineTest, start");
//        yield return null;
//        for (int i = 0; i < count; i++)
//        {
//            Debug.Log("CorutineTest, " + i);
//            yield return null;
//        }
//        Debug.Log("CorutineTest, end");
//    }
//}
//-------------------��������
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class IE : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        StartCoroutine(DownLoadPicture());
    }

    private IEnumerator DownLoadPicture()
    {

        //��ʱ
        //WWW www = new WWW("https://i0.hdslb.com/bfs/article/f04bc0a016e6d88c602047a39364a42cb27ea170.jpg@942w_531h_progressive.jpeg");
        //yield return www; // �ȴ�www�������
        //while (!www.isDone)
        //{
        //    Debug.Log("CorutineTest, progress = " + www.progress); // ��ӡ���ؽ���
        //    yield return null; // �ȴ�www�������
        //}
        //Texture2D texture = www.texture;
        //texture.name = "girl";
        //image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        //GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width, texture.height);
        //File.WriteAllBytes(Application.dataPath + "/Resources/Texture/girl.jpeg", www.bytes); // ����ͼƬ


        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://i0.hdslb.com/bfs/article/f04bc0a016e6d88c602047a39364a42cb27ea170.jpg@942w_531h_progressive.jpeg");
        yield return www.SendWebRequest();

        while (!www.isDone)
        {
            Debug.Log("CoroutineTest, progress = " + www.downloadProgress); 
            yield return null;
        }

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + www.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            texture.name = "girl";
            image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width, texture.height);

            byte[] bytes = texture.EncodeToJPG(); // Convert texture to JPG byte array
            File.WriteAllBytes(Application.dataPath + "/Resources/Texture/girl.jpeg", bytes); // Save image to file
        }
    }
}