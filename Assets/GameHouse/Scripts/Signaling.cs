using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signaling;

    private float maxVolume = 1f;
    private float minVolume = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ThiefMovement>())
        {
            _signaling.Play();
            StartCoroutine(PlaySignaling());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ThiefMovement>())
        {
            _signaling.Pause();
        }
    }

    private IEnumerator PlaySignaling()
    {
        int changeVolume = 1;
        _signaling.volume = minVolume;
        while (_signaling.isPlaying)
        {
            if (_signaling.volume >= maxVolume || _signaling.volume <= minVolume)
                changeVolume *= -1;
            _signaling.volume += changeVolume * Time.deltaTime;
            yield return null;
        }
    }
}
