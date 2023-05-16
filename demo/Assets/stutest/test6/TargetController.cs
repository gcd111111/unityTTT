using UnityEngine;

public class TargetController : MonoBehaviour
{
    private CharacterController character;
    private float speedRate = 4f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 speed = new Vector3(hor, 0, ver) * speedRate;
        character.SimpleMove(speed);
    }
}