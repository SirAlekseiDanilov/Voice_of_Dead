using UnityEngine;
using UnityEngine.UI;

namespace VoD {

    /// <summary>
    /// Оружие.
    /// </summary>
    public abstract class Weapon : MonoBehaviour {

        [Header("Weapon:")]

        /// <summary>
        /// Свойства оружия.
        /// </summary>
        #region Properties

        [SerializeField] private string names;
        /// <summary>
        /// Наименование оружия.
        /// </summary>
        public string WeaponName { get => names; set => names = value; }


        [SerializeField] private int damage;
        /// <summary>
        /// Урон оружия.
        /// </summary>
        public int WeaponDamage { get => damage; set => damage = value; }


        [SerializeField] private float periodicity;
        /// <summary>
        /// Частота использования оружия сек. (между выстрелами).
        /// </summary>
        public float WeaponPeriodicity { get => periodicity; set => periodicity = value; }

        [SerializeField] private float distance;
        /// <summary>
        /// Дальность действия оружия.
        /// </summary>
        public float WeaponDistance { get => distance; set => distance = value; }

        /// <summary>
        /// Картинка оружия на сцене.
        /// </summary>
        [SerializeField] private Sprite image;


        /*
        [Header("Weapon2:")]

        [SerializeField] private int w_Damage2;
        /// <summary>
        /// Урон оружия.
        /// </summary>
        public int WeaponDamage2 { get => w_Damage2; set => w_Damage2 = value; }
        */

        #endregion

        /// <summary>
        /// Методы оружия:
        /// </summary>
        #region Public API

        //[ContextMenu("Attack!")]
        public abstract void Attack();

        #endregion
    }
}
