using UnityEngine;

namespace VoD {

    public class PlatformerCharacter : MonoBehaviour {
        public float moveSpeed = 5f;
        public float jumpForce = 10f;
        private Rigidbody2D rb;
        private bool isGrounded;
        private bool movingRight = true; // направление движения

        void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update() {
            // Постоянное движение в выбранном направлении
            float direction = movingRight ? 1 : -1;
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

            // Прыжок по нажатию клавиши (например, Space)
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
    }
}