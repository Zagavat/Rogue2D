using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine fadeVolume;
    private float minVolume = 0f;
    private float maxVolume = 1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SeeRogueOff()
    {
        if (fadeVolume != null)
        {
            StopCoroutine(fadeVolume);
        }

        _audioSource.volume = 1f;
        _audioSource.loop = false;
        _audioSource.Play();
        fadeVolume = StartCoroutine(FadeVolume(minVolume));
    }

    public void MeetTheRogue()
    {
        if (fadeVolume != null)
        {
            StopCoroutine(fadeVolume);
        }

        _audioSource.volume = 0f;
        _audioSource.loop = true;
        _audioSource.Play();
        fadeVolume = StartCoroutine(FadeVolume(maxVolume));
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        var waitForMoment = new WaitForSeconds(0.1f);

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, 0.1f);
            yield return waitForMoment;
        }
    }
}
