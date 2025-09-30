using UnityEngine;
using VoD;


/// <summary>
/// Организатор игры (главный скрипт).
/// </summary>
    public class GameManager : MonoBehaviour {

    #region Properties

    [Tooltip("Название игры.")]
    [SerializeField] private string names;
    /// <summary>
    /// Название игры.
    /// </summary>
    public string GameName { get => names; set => names = value; }

    #endregion

    #region Public API

    [ContextMenu("New Game!")]
        public void NewGame() {
            print("Новая игра: " + names);
        }

        #endregion

        #region Private

        void Start() {
            NewGame();
        }

        /// <summary>
        /// Экземпляр единственный.
        /// </summary>
        private static GameManager instance;
        public static GameManager Instance {
            get {
                if (instance == null)
                    instance = GameObject.FindObjectOfType<GameManager>();
                return instance;
            }
        }

        #endregion

    }
