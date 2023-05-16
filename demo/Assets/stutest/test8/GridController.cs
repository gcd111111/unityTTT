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
//                // ÿ��������ת��Ϊ3���߶�, ÿ������ʹ��2��, ��Ӧ�Ķ���������: 0, 1, 1, 2, 2, 0, ͨʽ: (j + 1) % 6 / 2, j �ķ�Χ: 0 ~ 5
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
//----------------��Ӳ���
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
//                // ÿ��������ת��Ϊ3���߶�, ÿ������ʹ��2��, ��Ӧ�Ķ���������: 0, 1, 1, 2, 2, 0, ͨʽ: (j + 1) % 6 / 2, j �ķ�Χ: 0 ~ 5
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
//-------------------���Ʊ��������������
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
        mesh.subMeshCount = 2; // ����2��������
                               // ��һ���ֻ����������ڲ�
        SubMeshDescriptor subMeshDescriptor1 = new SubMeshDescriptor(0, divide, MeshTopology.Triangles);
        mesh.SetSubMesh(0, subMeshDescriptor1);
        // �ڶ����ֻ����߶�
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
                // ÿ��������ת��Ϊ3���߶�, ÿ������ʹ��2��, ��Ӧ�Ķ���������: 0, 1, 1, 2, 2, 0, ͨʽ: (j + 1) % 6 / 2, j �ķ�Χ: 0 ~ 5
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