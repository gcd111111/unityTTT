using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

//unity提供的特性  每次编译后都会执行  编辑器模式下
[InitializeOnLoad]
public class BuildHotFixEditor
{
    private const string scriptAssembliesDir = "Library/ScriptAssemblies";//加载路径
    private const string codeDir = "Assets/Res/Code/";//生成的dll和pdb文件夹存放的位置
    private const string hotfixDll = "Unity.HotFix.dll";//加载文件夹名称
    private const string hotfixPdb = "Unity.HotFix.pdb";//加载文件夹名称
    static BuildHotFixEditor()
    {
        //编译后将原有的文件覆盖掉
        File.Copy(Path.Combine(scriptAssembliesDir, hotfixDll),
            Path.Combine(codeDir, hotfixDll + ".bytes"), true);

        File.Copy(Path.Combine(scriptAssembliesDir, hotfixPdb),
            Path.Combine(codeDir, hotfixPdb + ".bytes"), true);
        Debug.Log("复制hotfix文件成功");
    }
}

