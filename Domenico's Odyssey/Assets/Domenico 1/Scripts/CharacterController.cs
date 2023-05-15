using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Action OnPlayerDeath;
    private void Start()
    {
        
        foreach (var item in FindObjectsOfType(typeof(ButtonColorManager)))
        {
            item.GetComponent<ButtonColorManager>().onColorChange += ChangeColor;
        }
    }
    private void ChangeColor(Color col)
    {
        GetComponent<SpriteRenderer>().color = col;
    }
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                OnPlayerDeath?.Invoke();
            }
        }
}
