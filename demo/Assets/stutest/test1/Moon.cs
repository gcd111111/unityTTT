using UnityEngine;

public class Moon : MonoBehaviour
{
    private Transform center;
    private float theta = 0f;

    void Start()
    {
        center = GameObject.FindGameObjectWithTag("Earth").transform;
    }

    void Update()
    {
        theta = theta + 0.08f;
        transform.position = new Vector3(center.position.x + Mathf.Cos(theta), 0f, center.position.z + Mathf.Sin(theta));
        transform.Rotate(-3 * Vector3.up);
    }
}