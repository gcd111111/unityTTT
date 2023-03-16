using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

//unity�ṩ������  ÿ�α���󶼻�ִ��  �༭��ģʽ��
[InitializeOnLoad]
public class BuildHotFixEditor
{
    private const string scriptAssembliesDir = "Library/ScriptAssemblies";//����·��
    private const string codeDir = "Assets/Res/Code/";//���ɵ�dll��pdb�ļ��д�ŵ�λ��
    private const string hotfixDll = "Unity.HotFix.dll";//�����ļ�������
    private const string hotfixPdb = "Unity.HotFix.pdb";//�����ļ�������
    static BuildHotFixEditor()
    {
        //�����ԭ�е��ļ����ǵ�
        File.Copy(Path.Combine(scriptAssembliesDir, hotfixDll),
            Path.Combine(codeDir, hotfixDll + ".bytes"), true);

        File.Copy(Path.Combine(scriptAssembliesDir, hotfixPdb),
            Path.Combine(codeDir, hotfixPdb + ".bytes"), true);
        Debug.Log("����hotfix�ļ��ɹ�");
    }
}

