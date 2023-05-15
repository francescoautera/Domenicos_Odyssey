using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Action<GameObject> OnPlayerDeath;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerDeath?.Invoke(gameObject);
        }
    }
}
