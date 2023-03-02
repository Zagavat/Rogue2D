using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorWalk { }
public static class States
{ 
    public const string Right = nameof(Right);
    public const string Left = nameof(Left);
    public const string Up = nameof(Up);
    public const string Down = nameof(Down);
}

[RequireComponent(typeof(Animator))]
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
            _animator.SetTrigger(States.Right);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetTrigger(States.Left);
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetTrigger(States.Up);
            transform.Translate(0, _speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetTrigger(States.Down);
            transform.Translate(0, _speed * Time.deltaTime * -1, 0);
        }
    }
}
