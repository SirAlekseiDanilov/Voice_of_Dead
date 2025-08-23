using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace VoD {

    /// <summary>
    /// Снаряд.
    /// </summary>
    public class Projectile_ : Projectile {
        // Типы повреждений
        public enum DamageType { Base, Magic }
        [SerializeField] private DamageType m_DamageType;

        /// <summary>
        /// Замедление врага.
        /// </summary>
        [SerializeField] private bool m_Slow = false;

        // Звуки выстрела (Важно! - не перекрыть Авэйки)
        [SerializeField] private Sound m_ShotSound = Sound.Arrow;
        // Звуки попадания снаряда.
        [SerializeField] private Sound m_HitSound = Sound.ArrowHit;

        private void Start() { m_ShotSound.Play(); }

        /// <summary>
        /// Нанесение урона врагу.
        /// </summary>
        /// <param name="hit"></param>
        protected override void OnHit(RaycastHit2D hit) {
            var enemy = hit.collider.transform.root.GetComponent<Enemy>();

            if (enemy != null) {
                enemy.TakeDamage(m_Damage, m_DamageType);
                m_HitSound.Play();
                if (m_Slow) { enemy.GetComponent<SpaceShip>().HalfMaxLinearVelocity(); }
            }

        }
    }
}