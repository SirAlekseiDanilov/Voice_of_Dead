using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace VoD {

    public class HealthSlot : MonoBehaviour {
        [SerializeField] private Image icoReduce;
        [SerializeField] private Text text;
        private Destructible destructible;

        private int maxHitPoint;

        private void Start() {
            // NetworkSessionManager.Events.PlayerVehicleSpawned += OnPlayerVehicleSpawned;
        }

        /*
        private void OnDestroy() {
            if (NetworkSessionManager.Instance != null) {
                NetworkSessionManager.Events.PlayerVehicleSpawned -= OnPlayerVehicleSpawned;
                destructible.HitPointChanged -= OnHitPointChanged;
            }
        }
        */

        /*
        /// <summary>
        /// Обработчик события
        /// </summary>
        private void OnPlayerVehicleSpawned(Vehicle vehicle) {
            // Отображаю элементы на экране
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);

            StartCoroutine(ViewHP());

            destructible = vehicle;
            destructible.HitPointChanged += OnHitPointChanged;
            maxHitPoint = destructible.HitPoint;
            text.text = maxHitPoint.ToString();
        }
        */

        IEnumerator ViewHP(float time = 1.5f) {
            text.gameObject.SetActive(true);
            yield return new WaitForSeconds(time);
            text.gameObject.SetActive(false);
        }


        private void OnHitPointChanged(int hitPoint) {
            text.text = hitPoint.ToString();
            icoReduce.fillAmount = 1 - (float)hitPoint / (float)maxHitPoint;
            StartCoroutine(ViewHP());
        }

    }
}