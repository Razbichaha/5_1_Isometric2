using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetBool("DoorClose", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool("DoorClose", true);
    }
}
