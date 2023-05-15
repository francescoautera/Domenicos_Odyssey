using UnityEngine;

namespace Domenico1 {

	public class GameManager : MonoBehaviour {

		private CharacterController characterController;
		private UiManager uiManager;

		private void Awake() {
			characterController = FindObjectOfType<CharacterController>();
			uiManager = FindObjectOfType<UiManager>();
			characterController.OnPlayerDeath += ActiveDeath;

		}


		void ActiveDeath() {
			uiManager.ActiveLose();
		}


      
	}

}