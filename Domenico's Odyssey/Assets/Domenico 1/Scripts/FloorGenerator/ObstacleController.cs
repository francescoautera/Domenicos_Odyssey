using System.Collections;
using UnityEngine;

namespace Domenico1 {

	public class ObstacleController : MonoBehaviour {

		public float timerDestroy;
		public Color currentColor;

		private void Awake() {
			StartCoroutine(WaitBeforeDestroy());
		}

        

		IEnumerator WaitBeforeDestroy() {
            
			yield return new WaitForSeconds(timerDestroy);
			Destroy(gameObject);
		}

	}

}