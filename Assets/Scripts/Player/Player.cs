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
        /// Голова игрока.
        /// </summary>
        [SerializeField] private Transform head;
        public Transform Head => head;

        /// <summary>
        /// Тело игрока.
        /// </summary>
        [SerializeField] private Transform body;
        public Transform Body => body;

        /// <summary>
        /// Рука игрока.
        /// </summary>
        [SerializeField] private Transform arm;
        public Transform Arm => arm;

        /// <summary>
        /// Оружие.
        /// </summary>
        [SerializeField] private Weapon weapon;
        public Weapon Weapon { get => weapon; set => weapon = value; }

        /// <summary>
        /// Поворачивать ли персонажем картинку оружия на сцене.
        /// </summary>
        [SerializeField] private bool weaponImageIsRotate;
        public bool WeaponImageIsRotate { get => weaponImageIsRotate; set => weaponImageIsRotate = value; }

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

        public void AngleSet(float angle, Vector2 norm) {
            Vector3 angle3 = new Vector3(0f, 0f, angle);
            headAngle = angle;
            headAngleNorm = norm;
            head.eulerAngles = angle3;
            if (weaponImageIsRotate) arm.eulerAngles = angle3;
            // лишнее...
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