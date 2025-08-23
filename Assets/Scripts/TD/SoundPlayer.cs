using System;
using UnityEngine;

namespace VoD {
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoSingleton<SoundPlayer> {
        /// <summary>
        /// Плейлист и УЖЕ назначенным массивом (от ошибок).
        /// </summary>
        [SerializeField] private Sounds m_Sounds;
        //[SerializeField] private AudioClip[] m_Sounds = new AudioClip[0];

        //[SerializeField] private AudioClip m_BGM;
        //[SerializeField] private float m_VolumeBGM = 0.05f;
        //[SerializeField] private float m_VolumeAll = 0.25f;

        private AudioSource m_AS;

        private new void Awake() {
            base.Awake(); // для синглтонов... плеер...
            m_AS = GetComponent<AudioSource>();
            //Instance.m_AS.clip = m_BGM;
            //Instance.m_AS.Play();

            //Instance.m_AS.volume = m_VolumeBGM;
            //Instance.m_AS.Stop();

        }
        public void Play(Sound sound) {
            //print($"играю {sound}");
            m_AS.PlayOneShot(m_Sounds[sound]); // полифония
            //if (m_AS.clip == m_BGM) { Instance.m_AS.volume = m_VolumeBGM; }
            //else { Instance.m_AS.volume = m_VolumeAll; }
        }
    }
}