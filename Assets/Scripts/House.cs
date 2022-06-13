using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _signalSound;
    [SerializeField] private UnityEvent _entered;

    private float _minVolumeValue = 0;
    private float _maxVolumeValue = 1;
    private float _stepValue = 0.05f;
    private float _step = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefMoving>(out ThiefMoving thief)) 
        {
            _step = 0;
            _audioSource.Stop();
            _audioSource.PlayOneShot(_signalSound);
            StopAllCoroutines();
            StartCoroutine(TurnOnSignal());
            _door.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _entered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _step = 0;
        StopAllCoroutines();
        StartCoroutine(TurnOffSignal());
        _door.SetActive(true);
    }

    private IEnumerator TurnOnSignal()
    {
        while (_audioSource.volume < _audioSource.maxDistance)
        {
            _step += _stepValue;
            _audioSource.volume = Mathf.MoveTowards(_minVolumeValue, _maxVolumeValue, _step);
            yield return new WaitForSeconds(_stepValue);
        }
    }

    private IEnumerator TurnOffSignal()
    {
        while (_audioSource.volume > 0)
        {
            _step += _stepValue;
            _audioSource.volume = Mathf.MoveTowards(_maxVolumeValue, _minVolumeValue, _step);
            yield return new WaitForSeconds(_stepValue);
        }
    }
}
