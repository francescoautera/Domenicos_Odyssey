using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Domenico1 {

    public class ObstacleGenerator : MonoBehaviour {

        public GameObject obstacle;
        public Vector2 randomTimerSpawn;
        public Vector2 randomOffsetSpawn;
        private GameObject lastObject;
        private float currentTimer;
        private float timerToInstance;
        private void Awake() {
            timerToInstance = Random.Range(randomTimerSpawn.x, randomTimerSpawn.y);
        }

        private void Update() {
            currentTimer += Time.deltaTime;
            if (currentTimer > timerToInstance) {
                currentTimer = 0;
                Spawn(lastObject !=null ? lastObject.transform : transform);
                timerToInstance = Random.Range(randomTimerSpawn.x, randomTimerSpawn.y);
            }
        }


        private void Spawn(Transform pos) {
            var xOffset = Random.Range(-randomOffsetSpawn.x, randomOffsetSpawn.x);
            var yOffset = Random.Range(-randomOffsetSpawn.y, -randomOffsetSpawn.y * 2);
            Vector3 posToInstance = new Vector3(pos.position.x + xOffset,pos.position.y+yOffset);
            lastObject =  Instantiate(obstacle, posToInstance, Quaternion.identity);
        }
    }

}