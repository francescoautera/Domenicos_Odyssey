using System;
using System.Collections.Generic;
using UnityEngine;

namespace Domenico1 {

	public class FloorManager : MonoBehaviour {

		[SerializeField] private FloorGenerator firstFloor;
		[SerializeField] private float velocity;
		[SerializeField] private GameObject feedbackSpeedUp;
		public int numberOfWin;
		public List<MapVelocityWin> mapVelocityWins = new List<MapVelocityWin>();
		private CharacterController characterController;
		private bool stop;
		private int currentIndex;
		private SoundsManager _soundsManager;
		[SerializeField] private List<ParticleSystem> speedUpEffects;

		private void Awake()
		{
			_soundsManager = FindObjectOfType<SoundsManager>();
			firstFloor.ParentTransform = transform;
			firstFloor.StartFirstFloor();
			characterController = FindObjectOfType<CharacterController>();
			characterController.OnPlayerWin += UpdateVelocity;
			characterController.OnPlayerDeath += Stop;
			currentIndex = 0;
		}


		private void Stop() => stop = true;
		
		private void Update() {
			if (!stop) {
				transform.position += (Vector3.up * velocity * Time.deltaTime);
			}
			
		}


		private void UpdateVelocity()
		{
			
			numberOfWin++;
			int finalX = 0;
			foreach (var mapVelocity in mapVelocityWins) {
				if (numberOfWin < mapVelocity.numberWin) {
					finalX = mapVelocityWins.IndexOf(mapVelocity) -1;
					if (currentIndex < finalX) {
						currentIndex = finalX;
						feedbackSpeedUp.SetActive(true);
						_soundsManager.SpeedUpSound();

						foreach (var speedUpEffect in speedUpEffects)
						{
							speedUpEffect.Play();
						}
					}
					break;
				}
				
			}
			
			
			velocity = mapVelocityWins[finalX].velocity;
			
		}
	}

	[Serializable]
	public class MapVelocityWin {
		
		public int numberWin;
		public float velocity;
	}

}

