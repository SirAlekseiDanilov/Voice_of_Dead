using UnityEngine;

namespace VoD {

    public class actionsPlayer : MonoBehaviour {
        private Player player;

        void Start() {
            player = GetComponent<Player>();
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                //print(1);
                player.Weapon.Attack();
            }
        }
    }
}