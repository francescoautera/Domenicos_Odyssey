using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Domenico1 {
	
	public class UiManager : MonoBehaviour {

		public TMP_Text loseText;
		public Button restartButton;


		private void Awake() {
			loseText.enabled = false;
			restartButton.onClick.AddListener(Restart);
			restartButton.gameObject.SetActive(false);
		}

		public void ActiveLose() {
			loseText.enabled = true;
			restartButton.gameObject.SetActive(true);
		}

		private void Restart() {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}



	}

}