namespace VoD {

    /// <summary>
    /// Звуки.
    /// </summary>
    public enum Sound {
        Arrow = 0,
        ArrowHit = 1,
        EnemyDie = 2,
        EnemyWin = 3,
        PlayerWin = 4,
        PlayerLose = 5,
        BGM = 6,    // фоновая
        Fire = 7,
    }

    /// <summary>
    /// Метод расширения Перечисления звуков
    /// (статик класс внутри статичного метода).
    /// </summary>
    public static class SoundExtensions {
        public static void Play(this Sound sound) {
            //Sound.Fire.Play();

            SoundPlayer.Instance.Play(sound);
        }
        //public static void Stop(this Sound sound)
        //{ SoundPlayer.Instance.(sound); }
    }
}