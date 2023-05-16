using UnityEngine;

public class Earth : MonoBehaviour
{
    private Transform center;

    void Start()
    {
        center = GameObject.FindGameObjectWithTag("Sun").transform;
    }

    void Update()
    {
        transform.RotateAround(center.position, -Vector3.up, 2);
        transform.Rotate(-4 * Vector3.up);
    }
}