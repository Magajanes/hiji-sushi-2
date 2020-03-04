﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingredients
{
    public class Ingredient : MonoBehaviour, Draggable
    {
        [SerializeField]
        protected IngredientName Name;
        [SerializeField]
        protected GameObject piecePrefab;
        [SerializeField]
        protected new Collider2D collider;

        private GameObject piece = null;
        private Collider2D pieceCollider;
        private Vector3 position;

        public void PickUp()
        {
            if (piece == null)
            {
                piece = Instantiate(piecePrefab, transform.position, Quaternion.identity);
                piece.transform.localScale = Vector3.zero;
                pieceCollider = piece.GetComponent<Collider2D>();
                iTween.ScaleTo(piece, iTween.Hash("scale", Vector3.one,
                                                  "time", 0.5f,
                                                  "easetype", iTween.EaseType.spring));
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
                Debug.Log(Name + " was placed on cutting board, but not processed!");
            }
            else
            {
                Destroy(piece.gameObject);
            }

            piece = null;
        }
    }
}