using System.Collections;
using UnityEngine;

public class VolumeSound : MonoBehaviour
{
    private AudioSource _audio;

    private int _iteration = 10;
    private float _pause = 0.1f;

    public void PlaySound()
    {
        StartCoroutine(SoundVolumeAttenuation());
    }

    public void StopSound()
    {
        StartCoroutine(SoundVolumeMagnification());
    }
    
    private void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }

    IEnumerator SoundVolumeAttenuation()
    {
        var Pause = new WaitForSeconds(_pause);

        _audio.loop = true;
        _audio.Play();

        for (int i = 1; i <= _iteration; i++)
        {
            _audio.volume = (float)i / _iteration;
            yield return Pause;
        }
    }

    IEnumerator SoundVolumeMagnification()
    {
        var Pause = new WaitForSeconds(_pause);

        for (int i = _iteration; i >= 0; i--)
        {
            _audio.volume = (float)i / _iteration;
            yield return Pause;
        }
        _audio.Stop();
        _audio.loop = false;
    }
}
