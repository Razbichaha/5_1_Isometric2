using System.Collections;
using UnityEngine;

public class ActivateAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _lampAlarm1;
    [SerializeField] private GameObject _lampAlarm2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _lampAlarm1.SetActive(true);
        _lampAlarm2.SetActive(true);

        StartCoroutine(SoundVolume(true));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _lampAlarm1.SetActive(false);
        _lampAlarm2.SetActive(false);

        StartCoroutine(SoundVolume(false));
    }

    IEnumerator SoundVolume(bool turnApVolume)
    {
        float numberIterations = 10;
        float durationSoundAttenuation = 0.15f;
        float durationSoundMagnification = 0.1f;

        if (turnApVolume)
        {
            _audioSource.Play();
            _audioSource.loop = true;

            for (int i = 1; i <= numberIterations; i++)
            {
                _audioSource.volume = i / numberIterations;
                yield return new WaitForSeconds(durationSoundAttenuation);
            }
        }
        else
        {
            for (int i = 1; i <= numberIterations; i++)
            {
                _audioSource.volume = (numberIterations - i) / numberIterations;
                yield return new WaitForSeconds(durationSoundMagnification);
            }
            _audioSource.Stop();
            _audioSource.loop = false;
        }
    }
}
