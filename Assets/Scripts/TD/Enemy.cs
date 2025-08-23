using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace VoD {

    [RequireComponent(typeof(Destructible))]
    [RequireComponent(typeof(PatrolController))]
    public class Enemy : MonoBehaviour {

        // Типы брони
        public enum ArmorType { Base = 0, Magic = 1 }

        /// <summary>
        /// Тип брони врага.
        /// </summary>
        [SerializeField] private ArmorType m_armorType;

        /// <summary>
        /// Определение урона.
        /// </summary>
        private static Func<int, Projectile_.DamageType, int, int>[]
            ArmorDamageFunctions =
        {
            (int power, Projectile_.DamageType type, int armor) =>
            {// ArmorType.Base
                switch (type)
                {
                    case Projectile_.DamageType.Magic: return power;
                    default: return Mathf.Max(1, power - armor);
                }
            },

            (int power, Projectile_.DamageType type, int armor) =>
            {// ArmorType.Magic
                if (Projectile_.DamageType.Base == type)
                    armor = armor / 2;
                return Mathf.Max(1, power - armor);
            },
        };


        /// <summary>
        /// Величина наносимого урона Игроку (этим врагом).
        /// </summary>
        [SerializeField] private int m_damage = 1;

        /// <summary>
        /// Количество награды (золота) за уничтожение этого врага.
        /// </summary>
        [SerializeField] private int m_gold = 1;

        /// <summary>
        /// Количество брони (блокирующей входящий урон).
        /// </summary>
        [SerializeField] private int m_armor = 0;

        /// <summary>
        /// Привязка к разрушаемому объекту (в самом себе).
        /// </summary>
        private Destructible m_destructible;

        private void Awake() {
            // Связываю свой же компонент.
            m_destructible = GetComponent<Destructible>();
        }


        /// <summary>
        /// Персональное событие уничтожения данного врага.
        /// </summary>
        public event Action OnEnd;
        // Вызов перед его уничтожением - только Unity (чужие не тронут)
        private void OnDestroy() { OnEnd?.Invoke(); }

        /// <summary>
        /// Задание параметров.
        /// </summary>
        /// <param name="asset"></param>
        public void Use(EnemyAsset asset) {
            #region Визуальные параметры

            // Ищу компонент КАРТИНКА.
            var sr = transform.Find("Sprite").GetComponent<SpriteRenderer>();

            // Устанавливаю цвет (фона картинке).
            sr.color = asset.color;
            // Устанавливаю размер (масштаб).
            sr.transform.localScale = new Vector3(asset.spriteScale.x, asset.spriteScale.y, 1);
            // Устанавливаю анимацию.
            sr.GetComponent<Animator>().runtimeAnimatorController = asset.animations;

            #endregion

            #region Игровые параметры

            // Командую установить скорость перемещения (кидаю СпейсШипу команду).
            GetComponent<SpaceShip>().Use(asset);

            // Ищу дочерний компонент КОЛЛАЙДЕР.
            GetComponentInChildren<CircleCollider2D>().radius = asset.radius;

            // Получаю величину наносимого урона из настроек.
            m_damage = asset.damage;

            // Получаю величину брони урона из настроек.
            m_armor = asset.armor;

            // Получаю тип брони из настроек.
            m_armorType = asset.armorType;

            // Получаю величину награды (золота) из настроек.
            m_gold = asset.gold;

            #endregion
        }

        /*
        /// <summary>
        /// Нанесение урона Игроку.
        /// </summary>
        public void DamagePlayer() {
            //print($"Player takes {damage}");

            Player.Instance.ReduceLife(m_damage);
            // Альтернатива:
            //(Player.Instance as TD_Player).ReduceLife(m_damage);
        }

        /// <summary>
        /// Получение награды (золота) Игроком.
        /// </summary>
        public void GivePlayerGold() {
            //print($"Player takes {m_gold}");

            Player.Instance.ChangeGold(m_gold);
            // Альтернатива:
            //(Player.Instance as TD_Player).ChangeGold(m_gold);
        }
        */

        /// <summary>
        /// Получение урона.
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage, Projectile_.DamageType damageType) {
            // Расчёт урона, проходящего через броню (через массив функций).
            m_destructible.ApplyDamage(
                ArmorDamageFunctions[(int)m_armorType](
                    damage, damageType, m_armor));
            //m_destructible.ApplyDamage(Mathf.Max(1, damage - m_armor));
        }

    }

#if UNITY_EDITOR

    /// <summary>
    /// Кастомный класс для редактора (достучаться до небес).
    /// </summary>
    [CustomEditor(typeof(Enemy))]
    public class EnemyInspector : Editor {
        /// <summary>
        /// Переопределяю метод для просмотра типов врагов.
        /// </summary>
        public override void OnInspectorGUI() {
            //base.OnInspectorGUI();
            //GUILayout.Label("jhdk");

            EnemyAsset ea = EditorGUILayout.ObjectField(
                null, typeof(EnemyAsset), false) as EnemyAsset;

            // Проверяю выбран ли в поле НаборСвойствВрага ?
            if (ea) {
                // Отрисовываю его на экране.
                (target as Enemy).Use(ea);
            }
        }
    }
#endif
}