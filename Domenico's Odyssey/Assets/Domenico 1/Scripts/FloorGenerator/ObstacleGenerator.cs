using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Domenico1 {

    public class ObstacleGenerator : MonoBehaviour {

        public GameObject obstacle;
        public Vector2 randomTimerSpawn;
        public Vector2 randomOffsetSpawn;
        private float currentTimer;
        private float timerToInstance;
        [SerializeField] private FloorManager floorManager;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private ColorDB colorDB;
        
        
        private void Awake() {
            timerToInstance = Random.Range(randomTimerSpawn.x, randomTimerSpawn.y);
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
            var xOffset = Random.Range(-randomOffsetSpawn.x, randomOffsetSpawn.x);
            var yOffset = Random.Range(-randomOffsetSpawn.y, -randomOffsetSpawn.y * 2);
            Vector3 posToInstance = new Vector3(characterController.transform.position.x + xOffset,characterController.transform.position.y+yOffset);
            var lastObj = Instantiate(obstacle, posToInstance, Quaternion.identity,floorManager.transform);
            lastObj.GetComponent<ObstacleController>().SetColor( colorDB.colors[Random.Range(0, colorDB.colors.Count)]);
        }
    }

}