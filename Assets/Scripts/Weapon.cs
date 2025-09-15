using UnityEngine;

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

        [SerializeField] private string w_Name;
        /// <summary>
        /// Наименование оружия.
        /// </summary>
        public string WeaponName { get => w_Name; set => w_Name = value; }


        [SerializeField] private int w_Damage;
        /// <summary>
        /// Урон оружия.
        /// </summary>
        public int WeaponDamage { get => w_Damage; set => w_Damage = value; }


        [SerializeField] private float w_Periodicity;
        /// <summary>
        /// Частота использования оружия сек. (между выстрелами).
        /// </summary>
        public float WeaponPeriodicity { get => w_Periodicity; set => w_Periodicity = value; }


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
