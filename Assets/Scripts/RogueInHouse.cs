using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class RogueInHouse : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private Coroutine volumeUp;
    private Coroutine volumeDown;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Movement>(out Movement component))
        {
            Debug.Log("Вошёл");

            if(volumeDown != null)
            {
                StopCoroutine(volumeDown);
            }

            _audioSource.volume = 0f;
            _audioSource.loop = true;
            _audioSource.Play();
            volumeUp = StartCoroutine(ChangeVolume(true));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement component))
        {
            Debug.Log("Вышел");

            if (volumeUp != null)
            {
                StopCoroutine(volumeUp);
            }

            _audioSource.volume = 1f;
            _audioSource.loop = false;
            _audioSource.Play();
            volumeDown = StartCoroutine(ChangeVolume(false));
        }
    }

    private IEnumerator ChangeVolume(bool isVolumeUp)
    {
        int direction = isVolumeUp ? 1 : -1;
        var waitForMoment = new WaitForSeconds(0.1f);
        int iterations = 100;

        for (int i = 0; i < iterations; i++)
        {
            _audioSource.volume += 1f / iterations * i * direction;
            yield return waitForMoment;
        }
    }
}
