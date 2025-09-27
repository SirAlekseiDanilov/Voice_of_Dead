using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoD {

    public class movePlayer : MonoBehaviour {
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

        private float angle;
        private Vector2 angleNorm;


        private float delta = 0.01f;

        private Player player;
        private Transform bodyPlayer;

        void Awake() {
            rb = GetComponent<Rigidbody2D>();
            player = GetComponent<Player>();
            bodyPlayer = player.Body;
            //angle = GetComponent<Player>().HeadAngle;
        }

        void Update() {
            UserPress();

            //Move();
            //Rotator();

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
            // print(moveVector);
            if (moveVector.x > delta & moveVector.y > delta) { angle = 360-45; angleNorm = new Vector2(0.5f, 0.5f); }
            if (moveVector.x > delta & moveVector.y < -delta) { angle = 360-135; angleNorm = new Vector2(0.5f, -0.5f); }
            if (moveVector.x < -delta & moveVector.y > delta) { angle = 45; angleNorm = new Vector2(-0.5f, 0.5f); }
            if (moveVector.x < -delta & moveVector.y < -delta) { angle = 135; angleNorm = new Vector2(-0.5f, -0.5f); }

            if (moveVector.x > delta & moveVector.y >= -delta & moveVector.y <= delta) { angle = 360-90; angleNorm = Vector2.right; }
            if (moveVector.x >= -delta & moveVector.x <= delta & moveVector.y < -delta) { angle = 180; angleNorm = Vector2.down; }
            if (moveVector.x >= -delta & moveVector.x <= delta & moveVector.y > delta) { angle = 0; angleNorm = Vector2.up; }
            if (moveVector.x < -delta & moveVector.y >= -delta & moveVector.y <= delta) { angle = 90; angleNorm = Vector2.left; }
            // print(angle);
            // transform.localRotation = Quaternion.Euler(0f, 0f, (float)angle);


            bodyPlayer.eulerAngles = new Vector3(0f, 0f, angle);
            player.HeadAngle = angle;
            player.HeadAngleNorm = angleNorm;
        }
    }
}


#region Test

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

/*
private void Rotator() {
    // наоборот оси от камеры направлены...
    // print(moveVector);
    if (moveVector.x > delta & moveVector.y > delta) { angle = 360 - 45; angleNorm = new Vector2(0.5f, -0.5f); }
    if (moveVector.x > delta & moveVector.y < -delta) { angle = 360 - 135; angleNorm = new Vector2(-0.5f, -0.5f); }
    if (moveVector.x < -delta & moveVector.y > delta) { angle = 45; angleNorm = new Vector2(0.5f, 0.5f); }
    if (moveVector.x < -delta & moveVector.y < -delta) { angle = 135; angleNorm = new Vector2(0.5f, -0.5f); }

    if (moveVector.x > delta & moveVector.y >= -delta & moveVector.y <= delta) { angle = 360 - 90; angleNorm = Vector2.left; }
    if (moveVector.x >= -delta & moveVector.x <= delta & moveVector.y < -delta) { angle = 180; angleNorm = Vector2.down; }
    if (moveVector.x >= -delta & moveVector.x <= delta & moveVector.y > delta) { angle = 0; angleNorm = Vector2.up; }
    if (moveVector.x < -delta & moveVector.y >= -delta & moveVector.y <= delta) { angle = 90; angleNorm = Vector2.right; }
    // print(angle);
    // transform.localRotation = Quaternion.Euler(0f, 0f, (float)angle);


    bodyPlayer.eulerAngles = new Vector3(0f, 0f, angle);
    player.HeadAngle = angle;
    player.HeadAngleNorm = angleNorm;
}
*/

#endregion