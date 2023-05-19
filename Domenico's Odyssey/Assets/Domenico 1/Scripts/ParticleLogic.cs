using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLogic : MonoBehaviour {
   
   public ParticleSystem particle;

   private void Update() {
      if (!particle.isPlaying) {
         gameObject.SetActive(false);
      }
   }
}
