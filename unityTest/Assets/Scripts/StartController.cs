using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    /// <summary>
    /// ת������Ϸ����
    /// </summary>
    public void Scene1()
    {
        SceneManager.LoadScene("GameTest");
        //��ʽ�� SceneManager.LoadScene(1);
    }
 
}
