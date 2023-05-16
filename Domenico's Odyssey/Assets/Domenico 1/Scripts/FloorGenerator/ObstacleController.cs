using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Domenico1 {

	public class ObstacleController : MonoBehaviour {

		public float timerDestroy;
		public Color currentColor;
		private Camera mainCamera;
		private float xPos,negativexPos;
		public float timerDirection;
		public float verticalSpeed;

		private void Awake() {
			StartCoroutine(WaitBeforeDestroy());
			mainCamera = Camera.main;
		 	xPos = mainCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x;
		    negativexPos = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
			
		}

		public void SetColorAndSprite(Color color,Sprite s) {
			GetComponentInChildren<SpriteRenderer>().color = color;
			GetComponentInChildren<SpriteRenderer>().sprite = s;
			currentColor = color;
			
		}

		


		IEnumerator WaitBeforeDestroy() {
            
			yield return new WaitForSeconds(timerDestroy);
			StopAllCoroutines();
			Destroy(gameObject);
		}

	}

}