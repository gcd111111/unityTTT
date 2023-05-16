using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MinimapController minimapController; // 小地图控制器
    private Transform firePoint; // 开火点
    private GameObject bulletPrefab; // 炮弹预设体
    private float tankMoveSpeed = 4f; // 坦克移动速度
    private float tankRotateSpeed = 2f; // 坦克转向速度
    private Vector3 predownMousePoint; // 鼠标按下时的位置
    private Vector3 currMousePoint; // 当前鼠标位置
    private float fireWaitTime = float.MaxValue; // 距离上次开火已等待的时间
    private float bulletCoolTime = 0.15f; // 炮弹冷却时间

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
    { // 坦克移动
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
    { // 坦克旋转
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
    { // 坦克开炮
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