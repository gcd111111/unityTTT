using UnityEngine;

public class Tank : MonoBehaviour
{

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.Translate(0, 0, ver * Time.deltaTime * 3);
        transform.Rotate(Vector3.up * hor * Time.deltaTime * 120f);
    }
}