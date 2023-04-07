using System.Collections;
using UnityEngine;
using BehaviorDesigner.Runtime;
using UnityEngine.AddressableAssets;

public class AddBT : MonoBehaviour
{
    IEnumerator Start()
    {
        // 初始化Addressables
        yield return Addressables.InitializeAsync();
        // 添加BehaviorTree
        var bt = gameObject.AddComponent<BehaviorTree>();
        // 设置不立即执行
        bt.StartWhenEnabled = false;
        // 加载行为树资源
        var loader = Addressables.LoadAssetAsync<ExternalBehaviorTree>("Assets/Res/Behavior.asset");
        yield return loader;
        // 设置ExternalBehavior
        bt.ExternalBehavior = loader.Result;
        // 执行行为树
        bt.EnableBehavior();
    }
}
