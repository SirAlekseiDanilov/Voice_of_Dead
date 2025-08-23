using UnityEngine;

namespace VoD {

    /// <summary>
    /// Путь ИИ.
    /// </summary>
    public class Patch : MonoBehaviour {

        [SerializeField] private CircleArea startArea;
        public CircleArea StartArea { get { return startArea; } }

        /// <summary>
        /// Стан врага.
        /// </summary>
        [SerializeField] private GameObject EnemySpawn;

        private Vector3 pointCashOutput;
        private Vector3 pointCashInput;

        /// <summary>
        /// Массив точек (маршрута)
        /// </summary>
        [SerializeField] private AIPointPatrol[] points;

        /// <summary>
        /// Количество точек (в массиве).
        /// </summary>
        public int Lenghth { get => points.Length; }

        /// <summary>
        /// Точка по её индексу
        /// </summary>
        /// <param name="i">Индекс точки</param>
        /// <returns></returns>
        public AIPointPatrol this[int i] { get => points[i]; }


        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;

            pointCashOutput = EnemySpawn.transform.position;

            foreach (var point in points) {
                pointCashInput = point.transform.position;
                Gizmos.DrawSphere(pointCashInput, point.Radius);
                Gizmos.DrawLine(pointCashOutput, pointCashInput);
                pointCashOutput = pointCashInput;
            }
        }

    }
}