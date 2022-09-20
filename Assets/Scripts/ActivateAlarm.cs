using System.Collections;
using UnityEngine;

public class ActivateAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _lampAlarm1;
    [SerializeField] private GameObject _lampAlarm2;

    float _numberIterations = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _lampAlarm1.SetActive(true);
        _lampAlarm2.SetActive(true);

        StartCoroutine(SoundVolumeAttenuation());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _lampAlarm1.SetActive(false);
        _lampAlarm2.SetActive(false);

        StartCoroutine(SoundVolumeMagnification());
    }

    IEnumerator SoundVolumeAttenuation()
    {
        float durationSoundAttenuation = 0.15f;

        _audioSource.Play();
        _audioSource.loop = true;

        for (int i = 1; i <= _numberIterations; i++)
        {
            _audioSource.volume = i / _numberIterations;
            yield return new WaitForSeconds(durationSoundAttenuation);
        }
    }

    IEnumerator SoundVolumeMagnification()
    {
        float durationSoundMagnification = 0.1f;

        for (int i = 1; i <= _numberIterations; i++)
        {
            _audioSource.volume = (_numberIterations - i) / _numberIterations;
            yield return new WaitForSeconds(durationSoundMagnification);
        }
        _audioSource.Stop();
        _audioSource.loop = false;
    }
}
