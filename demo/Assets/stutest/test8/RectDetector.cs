using System;
using System.Collections.Generic;
using UnityEngine;

public class RectDetector
{ // 边框检测器
    public static Rect GetRect(List<Transform> targets)
    { // 获取物体的外边框(包含子对象)
        if (targets != null && targets.Count > 0)
        {
            Rect[] rects = new Rect[targets.Count];
            for (int i = 0; i < targets.Count; i++)
            {
                rects[i] = GetRect(targets[i]);
            }
            return GetRect(rects);
        }
        return new Rect();
    }

    public static Rect GetCurrRect(List<Transform> targets)
    { // 获取物体的外边框(不包含子对象)
        if (targets != null && targets.Count > 0)
        {
            Rect[] rects = new Rect[targets.Count];
            for (int i = 0; i < targets.Count; i++)
            {
                rects[i] = GetCurrRect(targets[i]);
            }
            return GetRect(rects);
        }
        return new Rect();
    }

    public static Rect GetRect(Transform transform)
    { // 获取物体外边框(包含子物体)
        Rect rect = GetInitRect();
        ForAllChildren(transform, trans => {
            Rect rect1 = GetCurrRect(trans);
            rect.xMin = Mathf.Min(rect.xMin, rect1.xMin);
            rect.yMin = Mathf.Min(rect.yMin, rect1.yMin);
            rect.xMax = Mathf.Max(rect.xMax, rect1.xMax);
            rect.yMax = Mathf.Max(rect.yMax, rect1.yMax);
        });
        return rect;
    }

    public static Rect GetCurrRect(Transform transform)
    { // 获取物体外边框(不包含子对象)
        Rect rect = GetInitRect();
        Vector3[] vertices = GetVertices(transform);
        if (vertices != null && vertices.Length > 0)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(vertices[i]);
                rect.xMin = Mathf.Min(rect.xMin, screenPos.x);
                rect.yMin = Mathf.Min(rect.yMin, screenPos.y);
                rect.xMax = Mathf.Max(rect.xMax, screenPos.x);
                rect.yMax = Mathf.Max(rect.yMax, screenPos.y);
            }
        }
        return rect;
    }

    private static Rect GetRect(Rect[] rects)
    { // 合并一组边框
        if (rects == null || rects.Length == 0)
        {
            return new Rect();
        }
        Rect rect = rects[0];
        for (int i = 1; i < rects.Length; i++)
        {
            rect.xMin = Mathf.Min(rect.xMin, rects[i].xMin);
            rect.yMin = Mathf.Min(rect.yMin, rects[i].yMin);
            rect.xMax = Mathf.Max(rect.xMax, rects[i].xMax);
            rect.yMax = Mathf.Max(rect.yMax, rects[i].yMax);
        }
        return rect;
    }

    private static Rect GetInitRect()
    { // 获取初始的边框
        Rect rect = new Rect();
        rect.xMin = float.MaxValue;
        rect.yMin = float.MaxValue;
        rect.xMax = float.MinValue;
        rect.yMax = float.MinValue;
        return rect;
    }

    private static Vector3[] GetVertices(Transform transform)
    { // 获取网格顶点的世界坐标
        if (transform.GetComponent<MeshFilter>() == null || transform.GetComponent<MeshFilter>().mesh == null)
        {
            return null;
        }
        Vector3[] vertices = transform.GetComponent<MeshFilter>().mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = transform.TransformPoint(vertices[i]);
        }
        return vertices;
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