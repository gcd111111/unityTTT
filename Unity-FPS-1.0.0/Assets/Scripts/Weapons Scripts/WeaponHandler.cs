using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//武器瞄准
public enum WeaponAim {
    NONE,
    SELF_AIM,//自己瞄准
    AIM//正常瞄准
}
//武器射击
public enum WeaponFireType {
    SINGLE,//单反
    MULTIPLE//连发
}
//武器弹药
public enum WeaponBulletType {
    BULLET,//子弹
    ARROW,//箭
    SPEAR,//矛
    NONE
}

public class WeaponHandler : MonoBehaviour {

    private Animator anim;

    public WeaponAim weapon_Aim;

    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private AudioSource shootSound, reload_Sound;

    public WeaponFireType fireType;

    public WeaponBulletType bulletType;

    public GameObject attack_Point;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation() {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    public void Aim(bool canAim) {
        anim.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }

    void Turn_On_MuzzleFlash() {
        muzzleFlash.SetActive(true);
    }

    void Turn_Off_MuzzleFlash() {
        muzzleFlash.SetActive(false);
    }

    void Play_ShootSound() {
        shootSound.Play();
    }

    void Play_ReloadSound() {
        reload_Sound.Play();
    }

    void Turn_On_AttackPoint() {
        attack_Point.SetActive(true);
    }

    void Turn_Off_AttackPoint() {
        if(attack_Point.activeInHierarchy) {
            attack_Point.SetActive(false);
        }
    }

}

