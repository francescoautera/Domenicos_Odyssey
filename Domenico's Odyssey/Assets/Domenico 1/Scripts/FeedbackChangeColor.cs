using System.Collections;
using UnityEngine;

public class FeedbackChangeColor : MonoBehaviour {
	public float waitTimer;

	private void OnEnable() {
		StartCoroutine(WaitBeforeTurnOff());
	}

	IEnumerator WaitBeforeTurnOff() {
		yield return new WaitForSeconds(waitTimer);
		gameObject.SetActive(false);
	}
}