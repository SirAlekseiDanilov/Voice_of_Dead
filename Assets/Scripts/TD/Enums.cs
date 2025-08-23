using System;
using UnityEngine;

namespace VoD {

    /// <summary>
    /// Игрока КЛАСС:
    /// </summary>
    public enum PlayerClass {
        Knight,
        Wizard,
        Mechanic,
        Druid,
        Necromancer,
        Assasin,
        Paladin,
        Artist
    }
    /// <summary>
    /// Моба КЛАСС:
    /// </summary>
    public enum MobClass {
        Near,
        Shooter,
        Support,
        Thrower,
        Boss
    }
    /// <summary>
    /// Урона КЛАСС:
    /// </summary>
    [Flags]
    public enum DamageClass {
        //Nothing      = 0b_0000_0000,  // 0   (можно не писать - само добавится)
        /// <summary>
        /// 1 = Урон Физический
        /// </summary>
        Physical = 0b_0000_0001,    // 1  
        /// <summary>
        /// 2 = Урон Магический
        /// </summary>
        Magical = 0b_0000_0010,     // 2
        /// <summary>
        /// 8 = УронаМодификатор Элементальный
        /// </summary>
        Elemental = 0b_0000_1000,  // 8
        /// <summary>
        /// 18 Урон Физический с Элементальным модификатором
        /// </summary>
        EPhysical = Physical | Elemental,
        /// <summary>
        /// 28 Урон Магический с Элементальным модификатором
        /// </summary>
        EMagical = Magical | Elemental
        //Everything   = ВСЕ (само добавится)
    }
    //DamageClass damages = DamageClass.Physical | DamageClass.Magical;
    //var a = (DamageClass)10; //  Output: Выравнивание, Вращение
    //Enum.GetNames(typeof(DamageClass)).Length // Величина массива (вместе со стыковочными составными)
    //https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/builtin-types/enum


    public class Enums : MonoBehaviour {
    }
}