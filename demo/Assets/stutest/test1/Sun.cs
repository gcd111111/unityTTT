
using UnityEngine;
 
public class Sun : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(-2 * Vector3.up);
    }
}