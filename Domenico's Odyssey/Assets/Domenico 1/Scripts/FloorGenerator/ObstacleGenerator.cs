using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Domenico1 {

    public class ObstacleGenerator : MonoBehaviour {

        public GameObject obstacle;
        public Vector2 randomTimerSpawn;
        public Vector2 randomXSpawnViewportCoodinate;
        public Vector2 randomYSpawn;
        private float currentTimer;
        private float timerToInstance;
        [SerializeField] private FloorManager floorManager;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private ColorDB colorDB;
        private Camera mainCamera;
        
        
        private void Awake() {
            timerToInstance = Random.Range(randomTimerSpawn.x, randomTimerSpawn.y);
            mainCamera = FindObjectOfType<Camera>();
        }

        private void Update() {
            currentTimer += Time.deltaTime;
            if (currentTimer > timerToInstance) {
                currentTimer = 0;
                Spawn();
                timerToInstance = Random.Range(randomTimerSpawn.x, randomTimerSpawn.y);
            }
        }


        private void Spawn() {
            
            var yOffset = Random.Range(randomYSpawn.x, randomYSpawn.y);
            var xPosViewport = Random.Range(randomXSpawnViewportCoodinate.x, randomXSpawnViewportCoodinate.y);
            var xOffset = mainCamera.ViewportToWorldPoint(new Vector3(xPosViewport, 0, 0));
            Vector3 posToInstance = new Vector3(characterController.transform.position.x + xOffset.x,characterController.transform.position.y-yOffset);
            var lastObj = Instantiate(obstacle, posToInstance, Quaternion.identity,floorManager.transform);
            lastObj.GetComponent<ObstacleController>().SetColor( colorDB.colors[Random.Range(0, colorDB.colors.Count)]);
        }
    }

}