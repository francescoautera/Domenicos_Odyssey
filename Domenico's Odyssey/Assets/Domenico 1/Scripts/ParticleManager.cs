using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterController = Domenico1.CharacterController;

public class ParticleManager : MonoBehaviour {
    public List<ParticleLogic> particleLogics;
    private CharacterController characterController;

    private void Awake() {
        characterController = FindObjectOfType<CharacterController>();
        characterController.OnPlayerWin += ActiveAllParticle;
    }


    private void ActiveAllParticle() {

        foreach (var particleLogic in particleLogics) {
            particleLogic.gameObject.SetActive(true);
            particleLogic.particle.Play();
        }
    }
}
