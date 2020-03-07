using Ingredients;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : DragObject
{
    private Vector3 delta;
    private Vector3 position;

    public override void PickUp()
    {
        CalculateDelta();
    }

    public override void Move()
    {
        position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        transform.position = position + delta;
    }

    public override void Release()
    {
        if (target == null)
            return;

        var ingredient = target.GetComponent<Ingredient>();

        if (ingredient == null)
            return;

        Cut(ingredient);
    }
    private void CalculateDelta()
    {
        var clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0;
        delta = transform.position - clickPosition;
    }

    private void Cut(Ingredient ingredient)
    {
        ingredient.Process();
    }
}
