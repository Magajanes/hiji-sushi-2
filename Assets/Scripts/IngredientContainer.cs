using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingredients
{
    public class IngredientContainer : MonoBehaviour
    {
        private Ingredient ingredient;

        [SerializeField]
        private GameObject ingredientPrefab;

        public void TakeIngredient()
        {
            if (ingredient == null)
            {
                ingredient = Instantiate(ingredientPrefab, transform.position, Quaternion.identity).
                             GetComponent<Ingredient>();

                ingredient.PickUp();
            }
        }

        public void DragIngredient()
        {
            ingredient.Move();
        }

        public void PlaceIngredient()
        {
            ingredient.Release();
            ingredient = null;
        }
    }
}