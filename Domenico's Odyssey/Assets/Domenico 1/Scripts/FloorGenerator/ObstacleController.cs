using System.Collections;
using UnityEngine;

namespace Domenico1 {

	public class ObstacleController : MonoBehaviour {

		public float timerDestroy;
		public Color currentColor;

		private void Awake() {
			StartCoroutine(WaitBeforeDestroy());
		}

		public void SetColorAndSprite(Color color,Sprite s) {
			GetComponentInChildren<SpriteRenderer>().color = color;
			GetComponentInChildren<SpriteRenderer>().sprite = s;
			currentColor = color;
			
		}



		IEnumerator WaitBeforeDestroy() {
            
			yield return new WaitForSeconds(timerDestroy);
			Destroy(gameObject);
		}

	}

}