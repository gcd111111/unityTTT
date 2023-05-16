using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MinimapController minimapController; // С��ͼ������
    private Transform firePoint; // �����
    private GameObject bulletPrefab; // �ڵ�Ԥ����
    private float tankMoveSpeed = 4f; // ̹���ƶ��ٶ�
    private float tankRotateSpeed = 2f; // ̹��ת���ٶ�
    private Vector3 predownMousePoint; // ��갴��ʱ��λ��
    private Vector3 currMousePoint; // ��ǰ���λ��
    private float fireWaitTime = float.MaxValue; // �����ϴο����ѵȴ���ʱ��
    private float bulletCoolTime = 0.15f; // �ڵ���ȴʱ��

    private void Start()
    {
        minimapController = GameObject.Find("MinimapCamera").GetComponent<MinimapController>();
        firePoint = transform.Find("Top/Gun/FirePoint");
        bulletPrefab = (GameObject)Resources.Load("Bullet");
    }

    private void Update()
    {
        Move();
        Rotate();
        Fire();
    }

    private void Move()
    { // ̹���ƶ�
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (Mathf.Abs(hor) > float.Epsilon || Mathf.Abs(ver) > float.Epsilon)
        {
            Vector3 vec = transform.forward * ver + transform.right * hor;
            GetComponent<Rigidbody>().velocity = vec * tankMoveSpeed;
            Vector3 dire = new Vector3(hor, ver, 0);
            dire = dire.normalized * Mathf.Min(dire.magnitude, 1);
        }
    }

    private void Rotate()
    { // ̹����ת
        if (Input.GetMouseButtonDown(1))
        {
            predownMousePoint = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))
        {
            currMousePoint = Input.mousePosition;
            Vector3 vec = currMousePoint - predownMousePoint;
            GetComponent<Rigidbody>().angularVelocity = Vector3.up * tankRotateSpeed * vec.x;
            predownMousePoint = currMousePoint;
        }
    }

    private void Fire()
    { // ̹�˿���
        fireWaitTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && !minimapController.IsClickMinimap() || Input.GetKeyDown(KeyCode.Space))
        {
            if (fireWaitTime > bulletCoolTime)
            {
                BulletInfo bulletInfo = new BulletInfo("PlayerBullet", Color.red, transform.forward, 10f, 15f);
                BulletController bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity).AddComponent<BulletController>();
                bullet.SetBulletInfo(bulletInfo);
                fireWaitTime = 0f;    
            }
        }
    }
}