using UnityEngine;

namespace VoD {

    /// <summary>
    /// Оружие по окружности бьющее.
    /// </summary>
    public class Weapon_Circle : Weapon {

        // Область специальных характеристик
        [Header("SPECIAL >>>")]

        // Блок настроек:
        [Header("Settings:")]
        [Space(5)]

        [Tooltip("Кривая распределения урона.")]
        [SerializeField] private AnimationCurve damageCurve;
        // от 1 до 1 линией - однаковый урон по всей зоне

        [Tooltip("Картинка зоны поражения оружия.")]
        [SerializeField] private GameObject circle;

        [Tooltip("Коллайдер зоны поражения оружия.")]
        [SerializeField] private CircleCollider2D ccollider;

        private bool isDamaged = false;

        /*
        [Header("Settings:")]
        [Space(5)]

        [Tooltip("Наименование оружия.")]
        [SerializeField] private LineRenderer circleArea;
        */

        private void Start() {
            Assign();
        }

        /// <summary>
        /// Атака:
        /// </summary>
        [ContextMenu("Attack!")]
        public override void Attack() {
            print("Удар ауры !");
            isDamaged = true;
        }

        private void OnTriggerStay2D(Collider2D other) { //OnTriggerStay OnTriggerEnter2D

            if (isDamaged && other.gameObject.tag == "Interactable") {
                float distance = Vector3.Distance(transform.position, other.transform.position);
                float damage = WeaponDamage * damageCurve.Evaluate(Mathf.Clamp01(1 - distance / WeaponDistance));
                other.transform.GetComponent<Destructible>().ApplyDamage((int) damage);
                print(damage);
            }
            isDamaged = false;
        }

        /// <summary>
        /// Присвоение характеристик оружию:
        /// </summary>
        [ContextMenu("Assign!")]
        public new void Assign() {

            //выполняю действия, общие для любого оружия
            base.Assign();

            //задаю особые характеристики данного оружия
            print("Присвоение ауры !");

            ccollider.radius = WeaponDistance;
            circle.transform.localScale = new Vector3(WeaponDistance, WeaponDistance, 1);
            //gameObject.SetActive(true);

        }

    }
}

#region Test

#endregion