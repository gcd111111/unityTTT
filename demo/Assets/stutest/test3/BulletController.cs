using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    private BulletInfo bulletInfo; // 炮弹信息

    private void Start()
    {
        gameObject.name = bulletInfo.name;
        GetComponent<MeshRenderer>().material.color = bulletInfo.color;
        float lifeTime = bulletInfo.fireRange / bulletInfo.speed; // 存活时间
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.GetComponent<Rigidbody>().velocity = bulletInfo.flyDir * bulletInfo.speed;
    }

    public void SetBulletInfo(BulletInfo bulletInfo)
    {
        this.bulletInfo = bulletInfo;
    }
}