using UnityEngine;

namespace VoD {

    [CreateAssetMenu]
    public sealed class EnemyAsset : ScriptableObject {
        #region Визуальные параметры
        [Header("Внешность")]
        // Цвет.
        public Color color = Color.white;
        // Масштаб.
        public Vector2 spriteScale = new Vector2(3, 3);
        // Анимация.
        public RuntimeAnimatorController animations;
        #endregion

        #region Игровые параметры
        [Header("Суть")] // Игровые параметры

        // Скорость передвижения.
        public float moveSpeed = 1.0f;

        // 
        public int score = 1;

        // Жизни.
        public int hp = 1;

        // Тип брони.
        public Enemy.ArmorType armorType;

        // Броня.
        public int armor = 0;

        // Радиус объекта (из Масштаба).
        public float radius = 0.25f;

        // Величина урона от этого объекта.
        public int damage = 1;

        // Величина награды (золота) за уничтожение этого объекта.
        public int gold = 1;

        #endregion
    }
}