//using UnityEngine;
//using UnityEngine.AddressableAssets;

////��ʽһ��ͨ��Addressable Name��������Դ
//public class Main : MonoBehaviour
//{
//    void Start()
//    {
//        //Addressables.LoadAssetAsync<GameObject>("Assets/Res/Prefabs/Cube.prefab").Completed += (handle) =>
//        //{
//        //    // Ԥ������
//        //    GameObject prefabObj = handle.Result;
//        //    // ʵ����
//        //    GameObject cubeObj = Instantiate(prefabObj);
//        //};

//        Addressables.InstantiateAsync("Assets/Res/Prefabs/Cube.prefab").Completed += (handle) =>
//    {
//        // ��ʵ����������
//        GameObject cubeObj = handle.Result;
//    };
//    }

//}

//using UnityEngine;
//using UnityEngine.AddressableAssets;
//using System.Threading.Tasks;

//public class Main : MonoBehaviour
//{
//    void Start()
//    {
//        InstantiateCube();
//    }

//    private async void InstantiateCube()
//    {
//        // ��Ȼ����ʹ����Task������û��ʹ�ö��߳�
//        GameObject prefabObj = await Addressables.LoadAssetAsync<GameObject>("Assets/Res/Prefabs/Cube.prefab").Task;
//        // ʵ����
//        GameObject cubeObj = Instantiate(prefabObj);

//        // Ҳ��ֱ��ʹ��InstantiateAsync����
//        // GameObject cubeObj = await Addressables.InstantiateAsync("Assets/Prefabs/Cube.prefab").Task;
//    }
//}


//��ʽ����ͨ��AssetReference��������Դ
//using System.Security.Cryptography;
//using UnityEngine;
//using UnityEngine.AddressableAssets;

//public class Main : MonoBehaviour
//{
//    public AssetReference spherePrefabRef;

//    void Start()
//    {
//        //spherePrefabRef.LoadAssetAsync<GameObject>().Completed += (obj) =>
//        //{
//        //    // Ԥ��
//        //    GameObject spherePrefab = obj.Result;
//        //    // ʵ����
//        //    GameObject sphereObj = Instantiate(spherePrefab);
//        //};

//        spherePrefabRef.InstantiateAsync().Completed += (obj) =>
//        {
//            // ��ʵ����������
//            GameObject sphereObj = obj.Result;
//        };
//    }
//}


//�����ⲿ��Դ  
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public RawImage img;
    void Start()
    {
        Addressables.LoadAssetAsync<Texture2D>("Assets/Res/Textures/1.png").Completed += (obj) =>
        {
            // ͼƬ
            Texture2D tex2D = obj.Result;
            img.texture = tex2D;
            img.GetComponent<RectTransform>().sizeDelta = new Vector2(tex2D.width, tex2D.height);
        };
    }
}
