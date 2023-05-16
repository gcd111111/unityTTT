//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IE : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
//        //---------------启动协程
//        // 形式一
//        //StartCoroutine(CorutineTest());
//        //StartCoroutine(CorutineTest("arg"));
//        //// 形式二, 此方式最多只能传1个参数
//        //StartCoroutine("CorutineTest");
//        //StartCoroutine("CorutineTest", "arg");
//        //// 形式三
//        //IEnumerator corutin = CorutineTest();
//        //StartCoroutine(corutin);

//        //-----------------停止协程
//        //public void StopCoroutine(Coroutine routine);
//        //public void StopCoroutine(IEnumerator routine);
//        //public void StopCoroutine(string methodName); // 只能停止用字符串方法启动的协程
//        //public void StopAllCoroutines();
//        //yield break; // 跳出协程
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    //创建协程
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
//    //{ // 此时程序中不能再有其他Start方法
//    //    yield return StartCoroutine(CorutineTest());
//    //}
//}

//---------------------中断指令
//// 协程在所有脚本的FixedUpdate执行之后,等待一个fixed时间间隔之后再继续执行
//yield return WaitForFixedUpdate();
//// 协程将在下一帧所有脚本的Update执行之后,再继续执行
//yield return null;
//// 协程在延迟指定时间,且当前帧所有脚本的 Update全都执行结束后才继续执行
//yield return new WaitForSeconds(seconds);
//// 与WaitForSeconds类似, 但不受时间缩放影响
//yield return WaitForSecondsRealtime(seconds);
//// 协程在WWW下载资源完成后,再继续执行
//yield return new WWW(url);
//// 协程在指定协程执行结束后,再继续执行
//yield return StartCoroutine();
//// 当返回条件为假时才执行后续步骤
//yield return WaitWhile();
//// 等待帧画面渲染结束
//yield return new WaitForEndOfFrame();

//---------------案例一：
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
//-------------------案例二：
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

        //过时
        //WWW www = new WWW("https://i0.hdslb.com/bfs/article/f04bc0a016e6d88c602047a39364a42cb27ea170.jpg@942w_531h_progressive.jpeg");
        //yield return www; // 等待www下载完毕
        //while (!www.isDone)
        //{
        //    Debug.Log("CorutineTest, progress = " + www.progress); // 打印下载进度
        //    yield return null; // 等待www下载完毕
        //}
        //Texture2D texture = www.texture;
        //texture.name = "girl";
        //image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        //GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width, texture.height);
        //File.WriteAllBytes(Application.dataPath + "/Resources/Texture/girl.jpeg", www.bytes); // 保存图片


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