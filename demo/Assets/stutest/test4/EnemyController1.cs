using UnityEngine;
using UnityEngine.UI;

public class EnemyController1 : MonoBehaviour
{
    private Transform target; // Ŀ��
    private Transform top; // ��ͷ
    private Transform firePoint; // �����
    private Transform hp; // Ѫ��
    private GameObject bulletPrefab; // �ڵ�Ԥ����
    private float rotateSpeed = 0.4f; // ̹��ת���ٶ�
    private float fireWaitTime = float.MaxValue; // �����ϴο����ѵȴ���ʱ��
    private float bulletCoolTime = 1f; // �ڵ���ȴʱ��

    private void Start()
    {
        target = GameObject.Find("Player/Top").transform;
        top = transform.Find("Top");
        firePoint = transform.Find("Top/Gun/FirePoint");
        hp = transform.Find("HP");
        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullet");
    }

    private void Update()
    {
        fireWaitTime += Time.deltaTime;
        LookAtTarget();
        float angle = Vector3.Angle(target.position - top.position, top.forward);
        if (LookAtTarget())
        {
            Fire();
        }
        HPLookAtCamera();
    }

    private bool LookAtTarget()
    {
        Vector3 dir = target.position - top.position;
        float angle = Vector3.Angle(dir, top.forward);
        if (angle > 5)
        {
            int axis = Vector3.Dot(Vector3.Cross(dir, top.forward), Vector3.up) > 0 ? -1 : 1;
            GetComponent<Rigidbody>().angularVelocity = axis * Vector3.up * rotateSpeed;
            return false;
        }
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        return true;
    }

    private void HPLookAtCamera()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 target = new Vector3(cameraPos.x, hp.position.y, cameraPos.z);
        hp.LookAt(target);
    }

    private void Fire()
    {
        if (fireWaitTime > bulletCoolTime)
        {
            BulletInfo bulletInfo = new BulletInfo("EnemyBullet", Color.yellow, top.forward, 5f, 10f);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // ͨ��Ԥ���崴���ڵ�
            bullet.AddComponent<BulletController>().SetBulletInfo(bulletInfo);
            fireWaitTime = 0;
        }
    }
}