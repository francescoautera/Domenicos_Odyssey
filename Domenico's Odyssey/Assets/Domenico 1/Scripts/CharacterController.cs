using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Action<GameObject> OnPlayerDeath;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                OnPlayerDeath?.Invoke(gameObject);
            }
        }
}
