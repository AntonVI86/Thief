using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _signalSound;

    private float _minVolumeValue = 0;
    private float _maxVolumeValue = 1;
    private float _stepValue = 0.05f;
    private float _step = 0;

    public void EnterToHouse() 
    {
        _step = 0;
        _audioSource.Stop();
        _audioSource.PlayOneShot(_signalSound);
        StopAllCoroutines();
        StartCoroutine(TurnOnSignal());
    }

    public void LeaveHouse() 
    {
        _step = 0;
        StopAllCoroutines();
        StartCoroutine(TurnOffSignal());
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
