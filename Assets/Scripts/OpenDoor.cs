using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private const string NameAnimation = "DoorClose";

    [SerializeField] private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetBool(NameAnimation, false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool(NameAnimation, true);
    }
}
