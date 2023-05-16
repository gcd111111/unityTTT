
//using UnityEngine;

//public class RigidbodyController : MonoBehaviour
//{
//    private Rigidbody rig;

//    void Start()
//    {
//        rig = GetComponent<Rigidbody>();
//    }

//    void Update()
//    {
//        float hor = Input.GetAxis("Horizontal");
//        float ver = Input.GetAxis("Vertical");
//        float up = Mathf.Sqrt(hor * hor + ver * ver);
//        if (up > 0.1)
//        {
//            rig.velocity = new Vector3(hor, up, ver);
//        }
//    }
//}
//using UnityEngine;

//public class RigidbodyController : MonoBehaviour
//{
//    private Rigidbody rig;

//    void Start()
//    {
//        rig = GetComponent<Rigidbody>();
//    }

//    void Update()
//    {
//        float hor = Input.GetAxis("Horizontal");
//        float ver = Input.GetAxis("Vertical");
//        float up = Mathf.Sqrt(hor * hor + ver * ver);
//        if (up > 0.1)
//        {
//            rig.AddForce(new Vector3(hor, 0, ver) * 10); // 添加推力
//        }
//    }
//}

using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    private Rigidbody rig;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 在(0,0,0)坐标处添加10米范围内的300N的爆炸力
            rig.AddExplosionForce(300, Vector3.zero, 10);
        }
    }
}