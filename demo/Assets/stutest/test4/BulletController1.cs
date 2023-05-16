using UnityEngine;
using UnityEngine.UI;

public class BulletController1 : MonoBehaviour
{
    private BulletInfo1 bulletInfo; // �ڵ���Ϣ
    private volatile bool isDying = false;

    private void Start()
    {
        gameObject.name = bulletInfo.name;
        GetComponent<MeshRenderer>().material.color = bulletInfo.color;
        float lifeTime = bulletInfo.fireRange / bulletInfo.speed; // ���ʱ��
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.GetComponent<Rigidbody>().velocity = bulletInfo.flyDir * bulletInfo.speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isDying)
        {
            return;
        }
        if (IsHitEnemy(gameObject.name, other.gameObject.name))
        {
            other.transform.Find("HP/Health").GetComponent<Image>().fillAmount -= 0.1f;
            isDying = true;
            Destroy(gameObject, 0.1f);
        }
        else if (IsHitPlayer(gameObject.name, other.gameObject.name))
        {
            GameObject.Find("PlayerHP/Panel/Health").GetComponent<Image>().fillAmount -= 0.1f;
            isDying = true;
            Destroy(gameObject, 0.1f);
        }
    }

    public void SetBulletInfo(BulletInfo1 bulletInfo)
    {
        this.bulletInfo = bulletInfo;
    }

    private bool IsHitEnemy(string name, string otherName)
    { // ������о�
        return name.Equals("PlayerBullet") && otherName.Equals("Enemy");
    }

    private bool IsHitPlayer(string name, string otherName)
    { // ��������
        return name.Equals("EnemyBullet") && otherName.Equals("Player");
    }
}