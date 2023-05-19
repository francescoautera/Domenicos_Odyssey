using UnityEngine;

namespace Domenico1 {

	public class GameManager : MonoBehaviour {

		private CharacterController characterController;
		private UiManager uiManager;
		private int points;
		[SerializeField] float timerUpdateMeters;
		[SerializeField] private float currTimer;
		private bool isDeath;
		
		
		private void Awake() {
			characterController = FindObjectOfType<CharacterController>();
			uiManager = FindObjectOfType<UiManager>();
			characterController.OnPlayerDeath += ActiveDeath;
			characterController.OnPlayerWin += UpdatePoints;

		}

		
		private void Update() {
			if(isDeath)
				return;
			
			currTimer += Time.deltaTime;
			if (timerUpdateMeters < currTimer) {
				currTimer = 0;
				UpdatePoints();
			}
		}
		
		
		void UpdatePoints() {
			points += 1;
			uiManager.UpdateText(points);
		}

		void ActiveDeath() {
			uiManager.ActiveLose();
			isDeath = true;
		}
	}

}