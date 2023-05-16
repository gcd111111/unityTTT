using UnityEngine;

public class TrailController : MonoBehaviour
{
    private float speedRate = 4f;

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 speed = new Vector3(hor, 0, ver) * speedRate;
        transform.position += speed * Time.deltaTime;
    }
}