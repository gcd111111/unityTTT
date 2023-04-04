//using UnityEngine;
//using UnityEngine.AddressableAssets;

////方式一：通过Addressable Name来加载资源
//public class Main : MonoBehaviour
//{
//    void Start()
//    {
//        //Addressables.LoadAssetAsync<GameObject>("Assets/Res/Prefabs/Cube.prefab").Completed += (handle) =>
//        //{
//        //    // 预设物体
//        //    GameObject prefabObj = handle.Result;
//        //    // 实例化
//        //    GameObject cubeObj = Instantiate(prefabObj);
//        //};

//        Addressables.InstantiateAsync("Assets/Res/Prefabs/Cube.prefab").Completed += (handle) =>
//    {
//        // 已实例化的物体
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
//        // 虽然这里使用了Task，但并没有使用多线程
//        GameObject prefabObj = await Addressables.LoadAssetAsync<GameObject>("Assets/Res/Prefabs/Cube.prefab").Task;
//        // 实例化
//        GameObject cubeObj = Instantiate(prefabObj);

//        // 也可直接使用InstantiateAsync方法
//        // GameObject cubeObj = await Addressables.InstantiateAsync("Assets/Prefabs/Cube.prefab").Task;
//    }
//}


//方式二：通过AssetReference来加载资源
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
//        //    // 预设
//        //    GameObject spherePrefab = obj.Result;
//        //    // 实例化
//        //    GameObject sphereObj = Instantiate(spherePrefab);
//        //};

//        spherePrefabRef.InstantiateAsync().Completed += (obj) =>
//        {
//            // 已实例化的物体
//            GameObject sphereObj = obj.Result;
//        };
//    }
//}


//加载外部资源  
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
            // 图片
            Texture2D tex2D = obj.Result;
            img.texture = tex2D;
            img.GetComponent<RectTransform>().sizeDelta = new Vector2(tex2D.width, tex2D.height);
        };
    }
}
