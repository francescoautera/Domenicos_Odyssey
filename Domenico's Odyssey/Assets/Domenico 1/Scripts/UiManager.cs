using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Domenico1 {
	
	public class UiManager : MonoBehaviour {

		public TextMeshProUGUI  loseText;
		public Button restartButton;
		[SerializeField] ColorDB colorDB;

		private void Awake() {
			loseText.enabled = false;
			restartButton.onClick.AddListener(Restart);
			restartButton.gameObject.SetActive(false);
		}

		public void ActiveLose() {
			loseText.enabled = true;
			var st ="#"+ ColorUtility.ToHtmlStringRGBA(colorDB.colors[0].color);
			loseText.text = "cambia colore in" + $"<color={st}> blu </color>" ;
			restartButton.gameObject.SetActive(true);
		}

		private void Restart() {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}



	}

}