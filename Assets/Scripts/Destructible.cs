using UnityEngine;

namespace VoD {
    public class Destructible : MonoBehaviour {

        #region Properties

        /// <summary>
        /// Объект игнорирует повреждения.
        /// </summary>
        [SerializeField] private bool Indestructible;
        public bool IsIndestructible => Indestructible;

        /// <summary>
        /// Стартовое кол-во хитпоинтов.
        /// </summary>
        [SerializeField] private int HitPointsAll;

        /// <summary>
        /// Текущие хит поинты
        /// </summary>
        private int HitPointsCurrent;
        public int HitPoints => HitPointsCurrent;

        //[SerializeField] private ImpactEffect ExplosionPrefab;

        #endregion

        #region Public API

        /// <summary>
        /// Применение урона к объекту.
        /// </summary>
        /// <param name="damage"></param>
        public void ApplyDamage(int damage) {
            if (Indestructible)
                return;

            HitPointsCurrent -= damage;

            if (HitPointsCurrent <= 0)
                OnDeath();
        }

        public void AddHitPoints(float hp) {
            HitPointsCurrent = (int)Mathf.Clamp(HitPointsCurrent + hp, 0, HitPointsAll);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Переоределяемое событие уничтожения объекта, когда хит поинты ниже нуля.
        /// </summary>
        protected virtual void OnDeath() {
            /*
            if (ExplosionPrefab != null) {
                var explosion = Instantiate(ExplosionPrefab.gameObject);
                explosion.transform.position = transform.position;
            }
            */
            Destroy(gameObject);

            //EventOnDeath?.Invoke();
        }

        private void Start() {
            HitPointsCurrent = HitPointsAll;
        }

        #endregion

    }
}