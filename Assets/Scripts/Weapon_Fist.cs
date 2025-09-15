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
            print("Удар кулаком !!!");
        }
    }
}