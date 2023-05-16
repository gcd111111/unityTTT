using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController111 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Slope Limit：爬坡最大角度
        //Step Offset：爬梯最大高度
        //Skin Width：皮肤厚度
        //Min Move Distance：最小移动距离
        //Center、Radius、Height：角色用于检测碰撞的胶囊体中心、半径、高
        //说明：CharacterController 继承 Collider，并且其碰撞体是一个胶囊体。
        // CharacterController 中控制角色移动的方法如下：

        //public CollisionFlags Move(Vector3 motion)
        //public bool SimpleMove(Vector3 speed)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//using UnityEngine;
 
//public class PlayerController : MonoBehaviour
//{
//    private CharacterController character;
//    private float speedRate = 4f;

//    private void Start()
//    {
//        character = GetComponent<CharacterController>();
//    }

//    private void Update()
//    {
//        float hor = Input.GetAxis("Horizontal");
//        float ver = Input.GetAxis("Vertical");
//        Vector3 speed = new Vector3(hor, 0, ver) * speedRate;
//        character.SimpleMove(speed);
//    }
//}