using Ingredients;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour, Draggable
{
    private Vector3 delta;
    private Vector3 position;

    [SerializeField]
    private PickedUpIngredient targetIngredient;

    public void CalculateDelta()
    {
        var clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0;
        delta = transform.position - clickPosition;
    }

    public void Move()
    {
        position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        transform.position = position + delta;
    }

    public void Cut()
    {
        if (targetIngredient == null)
            return;

        targetIngredient.Process();
        targetIngredient = null;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (targetIngredient != null)
            return;

        targetIngredient = collider.GetComponent<PickedUpIngredient>();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        targetIngredient = null;
    }
}
