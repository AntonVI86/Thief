using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _leaved;
    [SerializeField] private UnityEvent _started;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _entered?.Invoke();
        _door.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _started?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _leaved?.Invoke();
        _door.SetActive(true);
    }
}
