using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponMovementController : MonoBehaviour
{
    [Title("Settings")]
    [SerializeField] float floatOffset;
    [SerializeField] float moveSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float decceleration;
    [SerializeField] float velPower;

    [Title("References")]
    [SerializeField] Transform floatTarget;
    private Rigidbody2D rb;

    Vector3 floatPosDirection;
    Vector3 movementVel;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckDistanceToFloat();
    }

    Vector3 GetFloatDirection()
    {
        floatPosDirection = floatTarget.position - transform.position;
        Debug.Log(floatPosDirection.magnitude);
        return floatPosDirection;
    }

    void CheckDistanceToFloat()
    {
        if (GetFloatDirection().magnitude > floatOffset)
        {
            MoveToTarget();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void MoveToTarget()
    {
        float targetSpeedHorizontal = GetFloatDirection().normalized.x * moveSpeed;
        float targetSpeedVertical = GetFloatDirection().normalized.y * moveSpeed;
        float speedDifX = targetSpeedHorizontal - rb.velocity.x;
        float speedDifY = targetSpeedVertical - rb.velocity.y;
        float accelRateX = (Mathf.Abs(speedDifX) > 0.01f) ? acceleration : decceleration;
        float accelRateY = (Mathf.Abs(speedDifY) > 0.01f) ? acceleration : decceleration;

        float movementX = Mathf.Pow(Mathf.Abs(speedDifX) * accelRateX, velPower) * Mathf.Sign(speedDifX);
        float movementY = Mathf.Pow(Mathf.Abs(speedDifY) * accelRateY, velPower) * Mathf.Sign(speedDifY);

        movementVel.x = movementX * Vector2.right.x;
        movementVel.y = movementY * Vector2.up.y;

        rb.AddForce(movementVel);
    }
}
