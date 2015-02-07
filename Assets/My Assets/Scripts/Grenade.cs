using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour
{	
		public float LifeTime = 3;
		private Component Explosive;
		// Use this for initialization
		void Start ()
		{
			//Explosive = this.GetComponent("Particle System");
			//yield return new WaitForSeconds(3);
			OnExplode ();
		}
	
		
		void OnExplode ()
		{
			this.particleSystem.enableEmission = true;
			//yield return new WaitForSeconds(1);
			this.particleSystem.enableEmission = false;
			Destroy (this);
		}

}

