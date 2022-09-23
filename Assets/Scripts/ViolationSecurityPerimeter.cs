using System.Collections;
using UnityEngine;

public class ViolationSecurityPerimeter : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    GameObject[] _lampAlarm;

    float _durationSoundMagnification = 0.1f;
    float _durationSoundAttenuation = 0.15f;
    float _numberSoundAdjustmentSteps = 10;

    private void Start()
    {
       _lampAlarm= GameObject.FindGameObjectsWithTag("Alarm");

        EnableAlarm(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnableAlarm(true);
        StartCoroutine(SoundVolumeAttenuation());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnableAlarm(false);
        StartCoroutine(SoundVolumeMagnification());
    }

    private void EnableAlarm(bool activateEmergencyLamp)
    {
        for (int i = 0; i < _lampAlarm.Length; i++)
        {
            _lampAlarm[i].SetActive(activateEmergencyLamp);
        }
    }

    IEnumerator SoundVolumeAttenuation()
    {
        _audioSource.Play();
        _audioSource.loop = true;

        for (int i = 1; i <= _numberSoundAdjustmentSteps; i++)
        {
            _audioSource.volume = i / _numberSoundAdjustmentSteps;
            yield return new WaitForSeconds(_durationSoundAttenuation);
        }
    }

    IEnumerator SoundVolumeMagnification()
    {
        for (int i = 1; i <= _numberSoundAdjustmentSteps; i++)
        {
            _audioSource.volume = (_numberSoundAdjustmentSteps - i) / _numberSoundAdjustmentSteps;
            yield return new WaitForSeconds(_durationSoundMagnification);
        }
        _audioSource.Stop();
        _audioSource.loop = false;
    }
}
