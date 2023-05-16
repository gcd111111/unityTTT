using System;
using System.Collections.Generic;
using UnityEngine;

public class RectPainter
{ // 矩形选框渲染器
    private const float border = 5; // 矩形选框的边界宽度
    private static RectPainter instance; // 单例
    private RectTransform selectTrans; // 选框
    private List<Transform> targets; // 选中的游戏对象

    private RectPainter()
    {
        selectTrans = GameObject.Find("Canvas/SelectBox").transform as RectTransform;
        Camera.main.GetComponent<SceneController1>().camChangedHandler += DrawRect;
    }

    public static RectPainter GetInstance()
    { // 获取单例
        if (instance == null)
        {
            instance = new RectPainter();
        }
        return instance;
    }

    public static void DrawRect(List<Transform> targets)
    { // 绘制被选中物体的外边框(包含子对象)
        if (instance != null)
        {
            instance.targets = targets;
            Rect rect = RectDetector.GetRect(targets);
            instance.DrawRect(rect);
        }
    }

    public static void DrawCurrRect(List<Transform> targets)
    { // 绘制被选中物体的外边框(不包含子对象)
        if (instance != null)
        {
            instance.targets = targets;
            Rect rect = RectDetector.GetCurrRect(targets);
            instance.DrawRect(rect);
        }
    }

    public static List<Transform> DrawRect(Transform root, Rect rect)
    { // 绘制root下面的在rect内的物体的外边框
        if (instance != null)
        {
            instance.targets = new List<Transform>();
            ForAllChildren(root, trans => {
                Rect rect1 = RectDetector.GetCurrRect(trans);
                if (ContainsRect(rect, rect1))
                {
                    instance.targets.Add(trans);
                }
            });
            instance.DrawCurrRect();
            return instance.targets;
        }
        return null;
    }

    private void DrawRect()
    { // 绘制边框(包含子对象)
        Rect rect = RectDetector.GetRect(targets);
        DrawRect(rect);
    }

    private void DrawCurrRect()
    { // 绘制边框(不包含子对象)
        Rect rect = RectDetector.GetCurrRect(targets);
        DrawRect(rect);
    }

    private void DrawRect(Rect rect)
    { // 绘制边框
        selectTrans.position = new Vector3(rect.x - border, rect.y - border, 0);
        selectTrans.sizeDelta = new Vector2(rect.width + border * 2, rect.height + border * 2);
    }

    private static bool ContainsRect(Rect rect1, Rect rect2)
    { // 判断rect1是否包含rect2
        if (rect1.width <= 0 || rect1.height <= 0 || rect2.width <= 0 || rect2.height <= 0)
        {
            return false;
        }
        if (rect2.xMin < rect1.xMin || rect2.yMin < rect1.yMin || rect2.xMax > rect1.xMax || rect2.yMax > rect1.yMax)
        {
            return false;
        }
        return true;
    }

    private static void ForAllChildren(Transform transform, Action<Transform> action)
    { // 对所有子对象执行活动
        if (transform == null || action == null)
        {
            return;
        }
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            action(children[i]);
        }
    }
}