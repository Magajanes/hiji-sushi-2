using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingredients
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField]
        private IngredientName Name;

        [SerializeField]
        private GameObject piecePrefab;

        [SerializeField]
        private new Collider2D collider;

        private GameObject piece = null;
        private Collider2D pieceCollider;
        private Vector3 position;

        public void PickUp()
        {
            if (piece == null)
            {
                piece = Instantiate(piecePrefab, transform.position, Quaternion.identity);
                pieceCollider = piece.GetComponent<Collider2D>();
            }
        }

        public void Move()
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            piece.transform.position = position;
        }

        public void Release(Collider2D cuttingBoard)
        {
            if (pieceCollider.IsTouching(cuttingBoard))
            {
                Debug.Log(Name + " used on cutting board!");
            }
            else
            {
                Destroy(piece.gameObject);
            }

            piece = null;
        }
    }
}