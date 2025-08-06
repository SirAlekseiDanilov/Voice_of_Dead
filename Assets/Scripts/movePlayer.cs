using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 0.5f;
    [SerializeField] private Vector2 moveVector;
    /// <summary>
    /// Направление (вращение) игрока.
    /// </summary>
    private Vector2 faceRotation;

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