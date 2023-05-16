using System;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Transform firePoint; // 开火点
    private GameObject bulletPrefab; // 炮弹预设体
    private float tankMoveSpeed = 4f; // 坦克移动速度
    private float tankRotateSpeed = 2f; // 坦克转向速度
    private float fireWaitTime = float.MaxValue; // 距离上次开火已等待的时间
    private float bulletCoolTime = 0.15f; // 炮弹冷却时间

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
    { // 坦克移动
        if (Math.Abs(hor) > 0.1f || Math.Abs(ver) > 0.1f)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * tankMoveSpeed * ver;
            GetComponent<Rigidbody>().angularVelocity = Vector3.up * tankRotateSpeed * hor;
        }
    }

    private void Fire()
    { // 开炮
        if (fireWaitTime > bulletCoolTime)
        {
            BulletInfo bulletInfo = new BulletInfo("PlayerBullet", Color.red, transform.forward, 10f, 15f);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.AddComponent<BulletController>().SetBulletInfo(bulletInfo);
            fireWaitTime = 0f;
        }
    }
}