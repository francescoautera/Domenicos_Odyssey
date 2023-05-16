using System;
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
        [SerializeField] private ObstacleDbSprites obstacleDbSprites;
        private ButtonManager buttonManager;
        private Camera mainCamera;
        
        
        private void Awake() {
            timerToInstance = Random.Range(randomTimerSpawn.x, randomTimerSpawn.y);
            mainCamera = FindObjectOfType<Camera>();
            buttonManager = FindObjectOfType<ButtonManager>();
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
            var firstxPosViewport = Random.Range(randomXSpawnViewportCoodinate.x,0.4f);
            var secondxPosViewPort = Random.Range(0.5f, randomXSpawnViewportCoodinate.y);
            var xOffset = mainCamera.ViewportToWorldPoint(new Vector3(firstxPosViewport, 0, 0));
            var secondXOffset = mainCamera.ViewportToWorldPoint(new Vector3(secondxPosViewPort, 0, 0));
            Vector3 posToInstance = new Vector3(xOffset.x,characterController.transform.position.y-yOffset);
            Vector3 secondposToInstance = new Vector3( secondXOffset.x, characterController.transform.position.y - yOffset);
            var lastObj = Instantiate(obstacle, posToInstance, Quaternion.identity,floorManager.transform);
            var secondObj = Instantiate(obstacle, secondposToInstance, Quaternion.identity,floorManager.transform);
            var color = colorDB.colors[Random.Range(0, colorDB.colors.Count)];
            var secondColor = buttonManager.buttons[Random.Range(0, buttonManager.buttons.Count)].col;
            var x = Random.Range(0, 2);
            var sprite = obstacleDbSprites.GetSprite();
            var sprite2 = obstacleDbSprites.GetSprite();
            lastObj.GetComponent<ObstacleController>().SetColorAndSprite(x==0?color.color: secondColor,sprite);
            secondObj.GetComponent<ObstacleController>().SetColorAndSprite(x==1?color.color: secondColor,sprite2);
            
        }
    }

}