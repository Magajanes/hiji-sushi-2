using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingredients
{
    public class Ingredient : DragObject
    {
        [SerializeField]
        protected IngredientName Name;
        [SerializeField]
        protected GameObject piecePrefab;
        [SerializeField]
        protected new Collider2D collider;

        private Vector3 position;

        public override void PickUp()
        {
            transform.localScale = Vector3.zero;
            iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.one,
                                              "time", 0.5f,
                                              "easetype", iTween.EaseType.spring));
        }

        public override void Move()
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            transform.position = position;
        }

        public override void Release()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            var cuttingBoard = target.GetComponent<CuttingBoard>();

            if (cuttingBoard == null)
            {
                Destroy(gameObject);
                return;
            }

            if (collider.IsTouching(target))
                Debug.Log(Name + " was placed on cutting board, but not processed!");
        }

        public void Process()
        {

        }
    }
}