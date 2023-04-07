using System.Collections;
using UnityEngine;
using BehaviorDesigner.Runtime;
using UnityEngine.AddressableAssets;

public class AddBT : MonoBehaviour
{
    IEnumerator Start()
    {
        // ��ʼ��Addressables
        yield return Addressables.InitializeAsync();
        // ���BehaviorTree
        var bt = gameObject.AddComponent<BehaviorTree>();
        // ���ò�����ִ��
        bt.StartWhenEnabled = false;
        // ������Ϊ����Դ
        var loader = Addressables.LoadAssetAsync<ExternalBehaviorTree>("Assets/Res/Behavior.asset");
        yield return loader;
        // ����ExternalBehavior
        bt.ExternalBehavior = loader.Result;
        // ִ����Ϊ��
        bt.EnableBehavior();
    }
}
