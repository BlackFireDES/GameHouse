using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.Events;

public class DoorActivation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetBool(AnimatorDoor.isOpen, collision.GetComponent<ThiefMovement>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool(AnimatorDoor.isOpen, collision.GetComponent<ThiefMovement>() == false);
    }
    
}
