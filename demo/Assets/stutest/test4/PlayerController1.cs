using System;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Transform firePoint; // �����
    private GameObject bulletPrefab; // �ڵ�Ԥ����
    private float tankMoveSpeed = 4f; // ̹���ƶ��ٶ�
    private float tankRotateSpeed = 2f; // ̹��ת���ٶ�
    private float fireWaitTime = float.MaxValue; // �����ϴο����ѵȴ���ʱ��
    private float bulletCoolTime = 0.15f; // �ڵ���ȴʱ��

    private void Start()
    {
        firePoint = transform.Find("Top/Gun/FirePoint");
        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullet");
    }

    private void Update()
    {
        fireWaitTime += Time.deltaTime;
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Move(hor, ver);
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Move(float hor, float ver)
    { // ̹���ƶ�
        if (Math.Abs(hor) > 0.1f || Math.Abs(ver) > 0.1f)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * tankMoveSpeed * ver;
            GetComponent<Rigidbody>().angularVelocity = Vector3.up * tankRotateSpeed * hor;
        }
    }

    private void Fire()
    { // ����
        if (fireWaitTime > bulletCoolTime)
        {
            BulletInfo bulletInfo = new BulletInfo("PlayerBullet", Color.red, transform.forward, 10f, 15f);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.AddComponent<BulletController>().SetBulletInfo(bulletInfo);
            fireWaitTime = 0f;
        }
    }
}