using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    /// <summary>
    /// 转换到游戏场景
    /// </summary>
    public void Scene1()
    {
        SceneManager.LoadScene("GameTest");
        //方式二 SceneManager.LoadScene(1);
    }
 
}
