using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Domenico1 {
	
	public class UiManager : MonoBehaviour {

		public TextMeshProUGUI  loseText;
		public Button restartButton;
		public Button menuButton;
		[SerializeField] ColorDB colorDB;
		[SerializeField] private GameObject losePanel;
		[SerializeField] private Image bgImage;
		[SerializeField] private TMP_Text point;
		private CharacterController characterController;
		[SerializeField] private Image fade;
		
		
		private void Awake() {
			fade.CrossFadeAlpha(0,1,false);
			loseText.enabled = false;
			restartButton.onClick.AddListener(Restart);
			menuButton.onClick.AddListener(BackToMenu);
			restartButton.gameObject.SetActive(false);

		}


		public void UpdateText(int value) {

			point.text = value.ToString();
		}

		public void ActiveLose() {

			StartCoroutine(Wait());
		}

		IEnumerator Wait() {
			losePanel.gameObject.SetActive(true);
			bgImage.CrossFadeAlpha(0,0,false);
			yield return null;
			bgImage.CrossFadeAlpha(1,1,false);
			loseText.enabled = true;
			restartButton.gameObject.SetActive(true);
			
		}


		private void Restart() {
			
			fade.CrossFadeAlpha(1,1,false);
			StartCoroutine(WaitBeforeChangeScene("_Main"));
		}

		private void BackToMenu() {
			fade.CrossFadeAlpha(1,1,false);
			StartCoroutine(WaitBeforeChangeScene("_Menu"));
		}

		IEnumerator WaitBeforeChangeScene(string nameScene) {
			yield return new WaitForSeconds(1.1f);
			SceneManager.LoadScene(nameScene);
		}



	}

}