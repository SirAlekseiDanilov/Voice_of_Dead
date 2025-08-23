using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{


    /*
#if UNITY_EDITOR
    /// <summary>
    /// Задаю цвет зоне пульсации (UnityEditor !).
    /// </summary>
    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, m_PulseRange);
    }
#endif
*/

/*

    /// <summary>
    /// Блоки станины.
    /// </summary>
    [Flags]
    public enum BedUnits    // №№ как в units
    {
        //Nothing      = 0b_0000_0000,  // 0   (можно не писать - само добавится)
        PlaneUp = 0b_0000_0001,  // 1   Плоскость верхняя
        AreaSmall = 0b_0000_0010,  // 2   Площадка внутренняя (малая)
        AreaMedium = 0b_0000_0100,  // 4   Площадка центральная (средняя)
        AreaLarge = 0b_0000_1000,  // 8   Площадка внешняя (большая)
        StockSmall = 0b_0001_0000,  // 16  Шток внутренний (малый)
        StockMedium = 0b_0010_0000,  // 32  Шток центральный (средний)
        StockLarge = 0b_0100_0000,  // 64  Шток внешний (большой)
        Products = 0b_1000_0000,  // 128 Продукции образцы
        /// <summary>
        /// 14 Площадки
        /// </summary>
        Areas = AreaSmall | AreaMedium | AreaLarge,
        /// <summary>
        /// 112 Штоки
        /// </summary>
        Stocks = StockSmall | StockMedium | StockLarge,
        /// <summary>
        /// 108 Большие блоки
        /// </summary>
        Big = AreaMedium | AreaLarge | StockMedium | StockLarge,
        /// <summary>
        /// 254 Все блоки
        /// </summary>
        All = Areas | Stocks | Products
        //Everything   = ВСЕ (само добавится)
    }
    //BedUnits bedUnits = BedUnits.AreaSmall | BedUnits.StockLarge;
    //var a = (BedUnits)10; //  Output: Выравнивание, Вращение
    //Enum.GetNames(typeof(BedUnits)).Length // Величина массива (вместе со стыковочными составными)
    //https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/builtin-types/enum

    */
}
