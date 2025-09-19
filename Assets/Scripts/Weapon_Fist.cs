//using System;
using UnityEngine;

namespace VoD {

    /// <summary>
    /// Оружие Кулак.
    /// </summary>
    public class Weapon_Fist : Weapon {

        [Header("Settings:")]

        [SerializeField] private Transform head;
        private Player player;

        private RaycastHit2D hit;

        private void Start() {
            player = transform.root.GetComponent<Player>();
        }

        /// <summary>
        /// Атака кулаком:
        /// </summary>
        [ContextMenu("Attack!")]
        public override void Attack() {
            print("Удар кулаком !");

            //https://unityhub.ru/scripting/Physics2D.Raycast
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
            //hit = Physics2D.Raycast(tWeapon.position, Vector2.up, Mathf.Infinity);
            hit = Physics2D.Raycast(head.position, player.HeadAngleNorm, WeaponDistance); //localPosition
            if (hit.collider != null) {
                print("Объект найден: " + hit.collider.name);
                hit.transform.GetComponent<Destructible>().ApplyDamage(WeaponDamage);
            }
            // https://unityhub.ru/scripting/Debug.DrawLine
            // Debug.DrawLine(tWeapon.position, Vector2.up, Color.green, 2.5f);
        }

    }
}

#region Test

/*
Ray ray = new Ray(transform.position, transform.forward);
RaycastHit hit;
if (Physics.Raycast(ray, out hit, maxDistance)) {
    print("Объект найден: " + hit.collider.name);

    if (hit.collider.CompareTag("Interactable")) {
        print("Вы столкнулись с интерактивным объектом!");
    }
}
*/

/*
if(potential == true) {
    print("Удар кулаком !!!");
}
*/

/*
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
*/

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

#endregion