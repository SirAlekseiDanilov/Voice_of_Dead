using UnityEngine;

namespace VoD {

    /// <summary>
    /// Оружие.
    /// </summary>
    public abstract class Weapon : MonoBehaviour {

        /// <summary>
        /// Свойства оружия.
        /// </summary>
        #region Properties

        // Область общих характеристик (для любого оружия)
        [Header("BASED >>>")]

        [Tooltip("Наименование оружия.")]
        [SerializeField] private string names;
        /// <summary>
        /// Наименование оружия.
        /// </summary>
        public string WeaponName { get => names; set => names = value; }

        [Tooltip("Описание оружия и его свойств.")]
        [TextArea][SerializeField] private string description;
        /// <summary>
        /// Описание оружия и его свойств.
        /// </summary>
        public string Description { get => description; set => description = value; }

        //[Space(15)]

        [Header("Weapon:")] [Space(5)]

        [Tooltip("Урон оружия.")]
        [SerializeField] private int damage;
        /// <summary>
        /// Урон оружия.
        /// </summary>
        public int WeaponDamage { get => damage; set => damage = value; }


        [Tooltip("Частота использования оружия сек. (между выстрелами).")]
        [SerializeField] private float periodicity;
        /// <summary>
        /// Частота использования оружия сек. (между выстрелами).
        /// </summary>
        public float WeaponPeriodicity { get => periodicity; set => periodicity = value; }


        [Tooltip("Дальность действия оружия.")]
        [SerializeField] private float distance;
        /// <summary>
        /// Дальность действия оружия.
        /// </summary>
        public float WeaponDistance { get => distance; set => distance = value; }


        // Блок настроек картинки:
        [Header("Images:")] [Space(5)]

        /*
        [Tooltip("Координаты оружия в карте (вправо, вниз).")]
        /// <summary>
        /// Координаты оружия в карте (вправо, вниз).
        /// </summary>
        [SerializeField] private Vector2Int imgCoordinate;
        */


        [Tooltip("Картинка оружия в меню.")]
        /// <summary>
        /// Картинка оружия в меню.
        /// </summary>
        [SerializeField] private Sprite imageUI;
        public Sprite ImageUI { get => imageUI; set => imageUI = value; }


        [Tooltip("Картинка оружия на сцене.")]
        /// <summary>
        /// Картинка оружия на сцене.
        /// </summary>
        [SerializeField] private Sprite imageScene;
        public Sprite ImageScene { get => imageScene; set => imageScene = value; }

        [Tooltip("Поворот картинки оружия на сцене, градусов.")]
        /// <summary>
        /// Поворот картинки оружия на сцене, градусов.
        /// </summary>
        [Range(-180, 180)][SerializeField] private int imageSceneRotate = 0;
        public int ImageSceneRotate { get => imageSceneRotate; set => imageSceneRotate = value; }


        [Tooltip("Поворачивать ли персонажем картинку оружия на сцене.")]
        /// <summary>
        /// Поворачивать ли персонажем картинку оружия на сцене.
        /// </summary>
        [SerializeField] private bool imageIsRotate = true;
        public bool ImageIsRotate { get => imageIsRotate; set => imageIsRotate = value; }

        [Space(5)]

        [Tooltip("Картинка атаки (на сцене).")]
        /// <summary>
        /// Картинка атаки (на сцене).
        /// </summary>
        [SerializeField] private Sprite imageAttack;
        public Sprite ImageAttack { get => imageAttack; set => imageAttack = value; }


        [Tooltip("Картинка попадания удара (на сцене).")]
        /// <summary>
        /// Картинка попадания удара (на сцене).
        /// </summary>
        [SerializeField] private Sprite imageHit;
        public Sprite ImageHit { get => imageHit; set => imageHit = value; }



        // Блок настроек:
        [Header("Settings:")] [Space(5)]

        [Tooltip("Картинка отображения (на сцене).")]
        [SerializeField] private SpriteRenderer imageRenderer;

        /*
        [Header("Weapon2:")]

        [SerializeField] private int w_Damage2;
        /// <summary>
        /// Урон оружия.
        /// </summary>
        public int WeaponDamage2 { get => w_Damage2; set => w_Damage2 = value; }
        */

        #endregion

        // Методы оружия:
        #region Public API

        /// <summary>
        /// Атака оружием!
        /// </summary>
        public abstract void Attack();

        /// <summary>
        /// Присвоить характеристики оружию!
        /// </summary>
        public void Assign() {
            print("Присвоение выбранного оружия !");
            imageRenderer.sprite = imageScene;
            imageRenderer.transform.eulerAngles = new Vector3(0f, 0f, imageSceneRotate);

            Player player = transform.root.GetComponent<Player>();
            player.Weapon = transform.GetComponent<Weapon>();
            player.WeaponImageIsRotate = ImageIsRotate;

        }

        #endregion
    }
}

/*
 [Range(float min, float max)]

 */
