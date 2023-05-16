//using System;
//using UnityEngine;

//public class GridController : MonoBehaviour
//{

//    private void Start()
//    {
//        ForAllChildren(transform, RebuildMesh);
//    }

//    private void RebuildMesh(Transform transform)
//    {
//        MeshFilter meshFilter = transform.GetComponent<MeshFilter>();
//        if (meshFilter != null && meshFilter.mesh != null)
//        {
//            int[] indices = MakeIndices(meshFilter.mesh.triangles);
//            meshFilter.mesh.SetIndices(indices, MeshTopology.Lines, 0);
//        }
//    }

//    private int[] MakeIndices(int[] triangles)
//    {
//        int[] indices = new int[2 * triangles.Length];
//        for (int i = 0; i < triangles.Length; i += 3)
//        {
//            for (int j = 0; j < 6; j++)
//            {
//                // 每个三角形转换为3条线段, 每个顶点使用2次, 对应的顶点序列是: 0, 1, 1, 2, 2, 0, 通式: (j + 1) % 6 / 2, j 的范围: 0 ~ 5
//                indices[2 * i + j] = triangles[i + (j + 1) % 6 / 2];
//            }
//        }
//        return indices;
//    }

//    private void ForAllChildren(Transform transform, Action<Transform> action)
//    {
//        action.Invoke(transform);
//        for (int i = 0; i < transform.childCount; i++)
//        {
//            ForAllChildren(transform.GetChild(i), action);
//        }
//    }
//}
//----------------添加材质
//using System;
//using UnityEngine;
//using UnityEngine.Rendering;

//public class GridController : MonoBehaviour
//{
//    public Material material;

//    private void Start()
//    {
//        ForAllChildren(transform, RebuildMesh);
//    }

//    private void RebuildMesh(Transform transform)
//    {
//        MeshFilter meshFilter = transform.GetComponent<MeshFilter>();
//        MeshRenderer meshRenderer = transform.GetComponent<MeshRenderer>();
//        if (meshFilter != null && meshFilter.mesh != null && meshRenderer != null)
//        {
//            meshRenderer.material = material;
//            int[] indices = MakeIndices(meshFilter.mesh.triangles);
//            meshFilter.mesh.SetIndices(indices, MeshTopology.Lines, 0);
//        }
//    }

//    private int[] MakeIndices(int[] triangles)
//    {
//        int[] indices = new int[2 * triangles.Length];
//        for (int i = 0; i < triangles.Length; i += 3)
//        {
//            for (int j = 0; j < 6; j++)
//            {
//                // 每个三角形转换为3条线段, 每个顶点使用2次, 对应的顶点序列是: 0, 1, 1, 2, 2, 0, 通式: (j + 1) % 6 / 2, j 的范围: 0 ~ 5
//                indices[2 * i + j] = triangles[i + (j + 1) % 6 / 2];
//            }
//        }
//        return indices;
//    }

//    private void ForAllChildren(Transform transform, Action<Transform> action)
//    {
//        action.Invoke(transform);
//        for (int i = 0; i < transform.childCount; i++)
//        {
//            ForAllChildren(transform.GetChild(i), action);
//        }
//    }
//}
//-------------------绘制表面和三角形网格
using System;
using UnityEngine;
using UnityEngine.Rendering;
 
public class GridController : MonoBehaviour
{
    public Material material;

    private void Start()
    {
        ForAllChildren(transform, RebuildMesh);
    }

    private void RebuildMesh(Transform transform)
    {
        MeshFilter meshFilter = transform.GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = transform.GetComponent<MeshRenderer>();
        if (meshFilter != null && meshFilter.mesh != null && meshRenderer != null)
        {
            InitMaterials(meshRenderer);
            int[] indices = MakeIndices(meshFilter.mesh.triangles);
            InitSubMesh(meshFilter.mesh, indices, indices.Length / 3);
        }
    }

    private void InitMaterials(MeshRenderer meshRenderer)
    {
        Material[] materials = new Material[meshRenderer.materials.Length + 1];
        meshRenderer.materials.CopyTo(materials, 0);
        materials[materials.Length - 1] = material;
        meshRenderer.materials = materials;
    }

    private void InitSubMesh(Mesh mesh, int[] indices, int divide)
    {
        mesh.SetIndexBufferParams(indices.Length, IndexFormat.UInt32);
        mesh.SetIndexBufferData(indices, 0, 0, indices.Length);
        mesh.subMeshCount = 2; // 设置2个子网格
                               // 第一部分绘制三角形内部
        SubMeshDescriptor subMeshDescriptor1 = new SubMeshDescriptor(0, divide, MeshTopology.Triangles);
        mesh.SetSubMesh(0, subMeshDescriptor1);
        // 第二部分绘制线段
        SubMeshDescriptor subMeshDescriptor2 = new SubMeshDescriptor(divide, indices.Length - divide, MeshTopology.Lines);
        mesh.SetSubMesh(1, subMeshDescriptor2);
    }

    private int[] MakeIndices(int[] triangles)
    {
        int[] indices = new int[3 * triangles.Length];
        triangles.CopyTo(indices, 0);
        for (int i = 0; i < triangles.Length; i += 3)
        {
            for (int j = 0; j < 6; j++)
            {
                // 每个三角形转换为3条线段, 每个顶点使用2次, 对应的顶点序列是: 0, 1, 1, 2, 2, 0, 通式: (j + 1) % 6 / 2, j 的范围: 0 ~ 5
                indices[triangles.Length + 2 * i + j] = triangles[i + (j + 1) % 6 / 2];
            }
        }
        return indices;
    }

    private void ForAllChildren(Transform transform, Action<Transform> action)
    {
        action.Invoke(transform);
        for (int i = 0; i < transform.childCount; i++)
        {
            ForAllChildren(transform.GetChild(i), action);
        }
    }
}