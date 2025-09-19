using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VoD {

    public class Player : MonoBehaviour {

        [Header("Health:")]

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
        /// Связи:
        /// </summary>
        [Header("Links:")]

        /// <summary>
        /// Тело игрока.
        /// </summary>
        [SerializeField] private Transform body;
        public Transform Body => body;
        /// <summary>
        /// Оружие.
        /// </summary>
        [SerializeField] private Weapon weapon;
        public Weapon Weapon => weapon;

        //[Header("Movement")]

        [Header("Info:")]

        [SerializeField] private float headAngle;
        /// <summary>
        /// Головы поворот.
        /// </summary>
        public float HeadAngle { get => headAngle; set => headAngle = value; }
        
        [SerializeField] private Vector2 headAngleNorm;
        public Vector2 HeadAngleNorm { get => headAngleNorm; set => headAngleNorm = value; }
        // задание лучше функцией

        /// <summary>
        /// События:
        /// </summary>
        [Header("Events:")]
        
        [SerializeField] private UnityEvent EventDeath;
        public UnityEvent EventOnDeath => EventDeath;


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

    }
}