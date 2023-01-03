using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTargetController : MonoBehaviour
{
    [Title("Settings")]
    [SerializeField] float floatOffset;
    [SerializeField] float moveSpeed;

    [Title("References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject target;
    private PlayerController playerController;

    Vector3 playerMoveDir;
    Vector3 back;
    Vector3 floatPos;


    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        SetFloatTarget();
    }

    private void Update()
    {
        SetFloatTarget();

        //only a test to check position
/*        weapon.transform.localPosition = floatPos;*/

        MoveToBack();
    }

    void SetFloatTarget()
    {
        playerMoveDir = playerController.GetMoveDirection();
        back.x = -playerMoveDir.x;
        back.y = -playerMoveDir.y;
        if (back.magnitude > 0.05f)
        {
            floatPos = back.normalized * floatOffset;
        }
    }

    public Vector3 GetTarget()
    {
        return floatPos;
    }

    void MoveToBack()
    {
        target.transform.localPosition = floatPos;
        //weapon.transform.localPosition = Vector3.Lerp(weapon.transform.localPosition, floatPos, moveSpeed);
    }

}
