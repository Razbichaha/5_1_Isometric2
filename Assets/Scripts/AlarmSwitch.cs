using UnityEngine;
using UnityEngine.Events;

public class AlarmSwitch : MonoBehaviour
{
    [SerializeField] private UnityEvent _enableAlarm;
    [SerializeField] private UnityEvent _turnOffAlarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enableAlarm?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _turnOffAlarm?.Invoke();
    }
}
