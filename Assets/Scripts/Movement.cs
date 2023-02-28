using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetTrigger("Right");
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetTrigger("Left");
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetTrigger("Up");
            transform.Translate(0, _speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetTrigger("Down");
            transform.Translate(0, _speed * Time.deltaTime * -1, 0);
        }
    }
}
