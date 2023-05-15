using System;
using System.Collections;
using System.Collections.Generic;
using Domenico1;
using Unity.VisualScripting;
using UnityEngine;

namespace Domenico1 {

    
    public class CharacterController : MonoBehaviour {
        public Action OnPlayerDeath;
        public GameObject characterModel;
        public float velocityRotation;
        public SpriteRenderer model;


        private void Start() {

            foreach (var item in FindObjectsOfType(typeof(ButtonData))) {
                item.GetComponent<ButtonData>().onColorChange += ChangeColor;
            }
        }

        private void Update() {
            characterModel.transform.Rotate(Vector3.forward * velocityRotation * Time.deltaTime);
        }

        private void ChangeColor(Color col) {
            model.color = col;
        }

        private void OnTriggerEnter2D(Collider2D other) {

            var obstacle = other.gameObject.GetComponent<ObstacleController>();

            if (obstacle) {
                if (obstacle.currentColor != model.color) {
                    OnPlayerDeath?.Invoke();
                }


            }
        }
    }

}