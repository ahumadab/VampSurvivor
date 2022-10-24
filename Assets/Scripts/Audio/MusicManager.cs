using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _musicOnStart;
        [SerializeField] private float _timeToSwitch;
        private float _volume;
        private AudioClip _switchAudioClip;
        

        private void Start()
        {
            Play(_musicOnStart, true);
        }

        public void Play(AudioClip audioClip, bool interruptCurrent = false)
        {
            if (interruptCurrent)
            {
                _volume = 1f;
                _audioSource.volume = _volume;
                _audioSource.clip = audioClip;
                _audioSource.Play();
            }
            else
            {
                _switchAudioClip = audioClip;
                StartCoroutine(SmoothSwitchMusic());
            }
            
        }

        private IEnumerator SmoothSwitchMusic()
        {
            _volume = 1f;
            while (_volume > 0f)
            {
                _volume -= Time.deltaTime / _timeToSwitch;
                if (_volume < 0f)
                {
                    _volume = 0f;
                }

                _audioSource.volume = _volume;
                yield return new WaitForEndOfFrame();
            }

            Play(_switchAudioClip, true);
        }
    }
}
