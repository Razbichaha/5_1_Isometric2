using UnityEngine;

public class PlayerControlrr : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    private int _revers = -1;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * _revers, 0, 0);
            print("A");
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, _speed * Time.deltaTime, 0);
            print("W");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            print("D");
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, _speed * Time.deltaTime * _revers, 0);
            print("S");
        }
    }
}
