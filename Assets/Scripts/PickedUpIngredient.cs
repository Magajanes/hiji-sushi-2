using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingredients
{
    public class PickedUpIngredient : Ingredient
    {
        [SerializeField]
        private Vector3 bowlPosition;

        public void Process()
        {
            if (piecePrefab == null)
                return;

            var piece = Instantiate(piecePrefab, bowlPosition, Quaternion.identity);
        }
    }
}