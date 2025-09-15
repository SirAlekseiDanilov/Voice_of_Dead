using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VoD {

    public class Player : MonoBehaviour {
        [SerializeField] private int currentHealth;
        /// <summary>
        /// Очки жизни.
        /// </summary>
        public int HitPoints => currentHealth;
        /// <summary>
        /// Максимально возможное кол-во очков жизни (на старте).
        /// </summary>
        private int maxHealth;
        /// <summary>
        /// Слайдер кол-ва жизней Игрока в UI.
        /// </summary>
        public Slider healthSlider;

        /// <summary>
        /// Тело игрока.
        /// </summary>
        [SerializeField] private Transform body;
        public Transform Body => body;

        /*
        private void Awake() {
            healthSlider = GameObject.FindGameObjectWithTag("UI_H").GetComponent<Slider>();
        }
        */

        private void Start() {
            maxHealth = currentHealth;
        }


        public void TakeDamage(int amount) {
            currentHealth -= amount;
            healthSlider.value = currentHealth / (float)maxHealth;
            if (currentHealth <= 0) {
                Dead();
            }
            ;
        }

        private void Dead() {
            Destroy(gameObject);
            EventDeath?.Invoke();
        }

        [SerializeField] private UnityEvent EventDeath;
        public UnityEvent EventOnDeath => EventDeath;
    }
}