using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Domenico1 {

	public class ObstacleController : MonoBehaviour {

		public float timerDestroy;
		public Color currentColor;
		private Camera mainCamera;
		private ColorManagment colorManagment;
		[SerializeField] private TriggerColor triggerColor;
		
		private void Awake() {
			StartCoroutine(WaitBeforeDestroy());
			mainCamera = Camera.main;
			colorManagment = FindObjectOfType<ColorManagment>();
			triggerColor.OnPlayerInside += TrySetColor;
		}

		private void TrySetColor() => colorManagment.SetColor();

		public void SetColorAndSprite(Color color,Sprite s) {
			GetComponentInChildren<SpriteRenderer>().color = color;
			GetComponentInChildren<SpriteRenderer>().sprite = s;
			currentColor = color;
			
		}


		public void StartAnim() { }


		IEnumerator WaitBeforeDestroy() {
            
			yield return new WaitForSeconds(timerDestroy);
			StopAllCoroutines();
			Destroy(gameObject);
		}

	}

}