
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
//            rig.AddForce(new Vector3(hor, 0, ver) * 10); // �������
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
            // ��(0,0,0)���괦���10�׷�Χ�ڵ�300N�ı�ը��
            rig.AddExplosionForce(300, Vector3.zero, 10);
        }
    }
}