using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DragObject : MonoBehaviour, Draggable
{
    protected Collider2D target;

    public abstract void PickUp();
    public abstract void Move();
    public abstract void Release();

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (target == null)
            target = collider;
    }

    protected void OnTriggerExit2D(Collider2D collider)
    {
        if (target == collider)
            target = null;
    }
}
