using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class RogueInHouse : MonoBehaviour
{
    [SerializeField] private UnityEvent GetIn;
    [SerializeField] private UnityEvent GetOut;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Movement>(out Movement component))
        {
            //Debug.Log("Вошёл");
            GetIn?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement component))
        {
            //Debug.Log("Вышел");
            GetOut?.Invoke();
        }
    }
}
