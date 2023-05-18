using UnityEngine;

namespace Domenico1 {

	public class GameManager : MonoBehaviour {

		private CharacterController characterController;
		private UiManager uiManager;
		private int points;

		private void Awake() {
			characterController = FindObjectOfType<CharacterController>();
			uiManager = FindObjectOfType<UiManager>();
			characterController.OnPlayerDeath += ActiveDeath;
			characterController.OnPlayerWin += UpdatePoints;

		}


		void UpdatePoints() {
			points += 100;
			uiManager.UpdateText(points);
		}

		void ActiveDeath() {
			uiManager.ActiveLose();
		}
	}

}