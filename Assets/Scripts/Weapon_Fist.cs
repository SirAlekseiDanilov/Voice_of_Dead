using System;
using UnityEngine;

namespace VoD {

    /// <summary>
    /// Оружие Кулак.
    /// </summary>
    public class Weapon_Fist : Weapon {

        /// <summary>
        /// Атака кулаком:
        /// </summary>
        [ContextMenu("Attack!")]
        public override void Attack() {
            //Console.WriteLine("Удар кулаком !!!");
            if(potential == true) {
                print("Удар кулаком !!!");
            }

        }

        [SerializeField] private Destructible destruct;
        [SerializeField] private bool potential = false;

        private void OnTriggerEnter(Collider other) {
            //destruct = none;
            destruct = other.gameObject.GetComponent<Destructible>();
            potential = true;
        }
        private void OnTriggerExit(Collider other) {
            potential = false;
        }


        /*
         * https://hatchjs.com/how-to-check-if-a-collider-is-colliding-unity/
        private void OnTriggerStay(Collider other) {
            if (other.gameObject.tag == "FireZone") {
                Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                GetComponent<MeshRenderer>().material.color = color;
            }
        }

        // Проверка столкновений между коллайдером и лучом raycast
        if (collider.Raycast(ray, out hit)) {
        // Луч raycast попал в коллайдер
        }

        */
        //OverlapBox 
        //if (collider1.IsColliding(collider2)) {
    }
}