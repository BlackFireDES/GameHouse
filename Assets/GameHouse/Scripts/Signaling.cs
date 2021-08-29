using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ThiefMovement>())
        {
            _signaling.Play();
            StartCoroutine(PlaySignaling().GetEnumerator());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ThiefMovement>())
        {
            _signaling.Pause();
        }
    }

    private IEnumerable PlaySignaling()
    {
        int changeVolume = 1;
        _signaling.volume = 0.5f;
        while (_signaling.isPlaying)
        {
            if (_signaling.volume >= 1 || _signaling.volume <= 0.5f)
                changeVolume *= -1;
            _signaling.volume += changeVolume * Time.deltaTime;
            yield return null;
        }
    }
}
