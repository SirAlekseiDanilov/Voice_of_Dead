using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    /// <summary>
    /// Тело персонажа (привязка).
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// Персонажа скорость.
    /// </summary>
    public float speed = 0.5f;
    /// <summary>
    /// Направление от пользователя.
    /// </summary>
    [SerializeField] private Vector2 moveVector;

    [SerializeField] private float angle;
    private float delta = 0.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        UserPress();
        if (moveVector != Vector2.zero) {
            Move();
            Rotator();
        }
    }
    /// <summary>
    /// Пользовательский ввод.
    /// </summary>
    private void UserPress() {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
    }

    /// <summary>
    /// Передвижение.
    /// </summary>
    private void Move() {
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
    }
    /// <summary>
    /// Вращение.
    /// </summary>
    private void Rotator() {
        // наоборот оси от камеры направлены...
        print(moveVector);
        //angle = 0;
        if (moveVector.x > delta) {
            angle = -90;
            if (moveVector.y > delta) {
                angle += 45;
            }
            if (moveVector.y < -delta) {
                angle -= 45;
            }
            else {
                angle = 90;
                if (moveVector.y > delta) {
                    angle += 45;
                }
                if (moveVector.y < -delta) {
                    angle -= 45;
                }
            }
        }
        print(angle);
        transform.localRotation =
            Quaternion.Euler(0f, 0f, (float)angle);

        //Vector3 v = new Vector3(0, 0, (float)angle);
        //transform.Rotate(v);
        //transform.Rotate = v;
        /*
        double angle = Math.Atan(moveVector.y / moveVector.x) * 180 / Math.PI + 90;
        print(angle);
        //rb.MoveRotation((float)angle);
        */

        //Debug.DrawRay(transform.position, moveVector.normalized, color: Color.blue, 1);
        //print(moveVector.normalized);

        /*
        // GeometryKrash.Vehicle
        rb.AddTorque(TorqueControl * m_Mobility * Time.fixedDeltaTime, ForceMode2D.Force);
        rb.AddTorque(-rb.angularVelocity * (m_Mobility / m_MaxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
        */


        //transform.right = rb.velocity.normalized;
        // transform.rotation = Quaternion.LookRotation(moveVector, Vector3.up);

        /*
        Vector2 correct = Vector2.zero;
        correct.x = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        correct.y = Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        Debug.DrawRay(transform.position, correct, color: Color.blue, 1);
        */

        /*
        Vector3 worldDirectionToPointForward = rb.velocity.normalized;
        Vector3 localDirectionToPointForward = Vector3.right;

        Vector3 currentWorldForwardDirection = transform.TransformDirection(
                localDirectionToPointForward);
        float angleDiff = Vector3.SignedAngle(currentWorldForwardDirection,
                worldDirectionToPointForward, Vector3.forward);

        transform.Rotate(Vector3.forward, angleDiff, Space.World);
        */
    }
}