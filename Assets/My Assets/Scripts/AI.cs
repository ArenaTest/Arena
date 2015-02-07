using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
		public NavMeshAgent agent;
		public Transform player;
	// Use this for initialization
	void Start () {
	if (!agent) 
		{
			agent = gameObject.GetComponent<NavMeshAgent>();
		}
		if (!player)
		{
			 player = GameObject.FindWithTag("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindWithTag("Player"))
		{
			player = GameObject.FindWithTag("Player").transform;
			agent.SetDestination (player.transform.position);
			if(Vector3.Distance(player.position, transform.position)< agent.stoppingDistance)
			{
				//gameObject.animation
				//player.SendMessageUpwards("ApplyDamage", 100);
			}
		}

	}
}
