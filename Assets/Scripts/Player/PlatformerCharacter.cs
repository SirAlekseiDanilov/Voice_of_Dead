using UnityEngine;

namespace VoD {

    public class PlatformerCharacter : MonoBehaviour {
        /// <summary>
        /// Персонажа скорость.
        /// </summary>
        public float moveSpeed = 5f;
        /// <summary>
        /// Персонажа сила прыжка.
        /// </summary>
        public float jumpForce = 10f;
        /// <summary>
        /// Тело персонажа (привязка).
        /// </summary>
        private Rigidbody2D rb;
        /// <summary>
        /// Положение на земле (да/нет).
        /// </summary>
        private bool isGrounded;
        /// <summary>
        /// Направление движения (да = направо).
        /// </summary>
        private bool movingRight = true; // направление движения

        /// <summary>
        /// Направление от пользователя.
        /// </summary>
        [SerializeField] private Vector2 moveVector;
        private float angle;
        private Vector2 angleNorm;
        private float delta = 0.05f;
        private Player player;

        void Start() {
            rb = GetComponent<Rigidbody2D>();
            player = GetComponent<Player>();
        }

        void Update() {
            // Постоянное движение в выбранном направлении
            float direction = movingRight ? 1 : -1;
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

            // Прыжок по нажатию клавиши (например, Space)
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }

            UserPress();
            if (moveVector != Vector2.zero) {
                Rotator();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            // Проверка столкновения с землей
            if (collision.gameObject.CompareTag("Ground")) {
                isGrounded = true;
            }

            // Обработка столкновений с материалами с разной упругостью
            if (collision.gameObject.CompareTag("Material")) {
                // Получение материала (Physics Material 2D)
                PhysicsMaterial2D material = collision.collider.sharedMaterial;
                if (material != null) {
                    // Отскок с учетом упругости
                    float restitution = material.bounciness;

                    // Изменение направления при отскоке
                    movingRight = !movingRight;

                    // Можно дополнительно регулировать скорость или направление
                    // например, с учетом упругости
                    rb.velocity = new Vector2((movingRight ? 1 : -1) * moveSpeed * restitution, rb.velocity.y);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Ground")) {
                isGrounded = false;
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
        /// Вращение.
        /// </summary>
        private void Rotator() {
            // наоборот оси от камеры направлены...
            // print(moveVector);
            if (moveVector.x > delta & moveVector.y > delta) { angle = 360 - 45; angleNorm = new Vector2(0.5f, 0.5f); }
            if (moveVector.x > delta & moveVector.y < -delta) { angle = 360 - 135; angleNorm = new Vector2(0.5f, -0.5f); }
            if (moveVector.x < -delta & moveVector.y > delta) { angle = 45; angleNorm = new Vector2(-0.5f, 0.5f); }
            if (moveVector.x < -delta & moveVector.y < -delta) { angle = 135; angleNorm = new Vector2(-0.5f, -0.5f); }

            if (moveVector.x > delta & moveVector.y >= -delta & moveVector.y <= delta) { angle = 360 - 90; angleNorm = Vector2.right; }
            if (moveVector.x >= -delta & moveVector.x <= delta & moveVector.y < -delta) { angle = 180; angleNorm = Vector2.down; }
            if (moveVector.x >= -delta & moveVector.x <= delta & moveVector.y > delta) { angle = 0; angleNorm = Vector2.up; }
            if (moveVector.x < -delta & moveVector.y >= -delta & moveVector.y <= delta) { angle = 90; angleNorm = Vector2.left; }

            // сообщил угол игроку (и забыл...)
            player.AngleSet(angle, angleNorm);
        }

    }
}