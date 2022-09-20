using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string _nameAnimation = "DoorClose";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetBool(_nameAnimation, false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool(_nameAnimation, true);
    }
}
