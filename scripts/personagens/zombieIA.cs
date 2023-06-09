using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieIA : MonoBehaviour 
{
	[Header("Controllers")]
	public NavMeshAgent agent;
	public GameContreller controller;
	public Animator animator;

	[Header("Petrol")]
	public Vector3 startPosition;
	public float minPatrolWaiTime = 2;
	public float maxPatrolWaitTime = 6; //seconds 
	float currentPatrolWaitTime;

	[Header("Horde Type")]
	public bool hord1;
	public bool hord2;

	private void Start()
	{
		controller = GameObject.Find ("GameController").GetComponent<GameContreller> ();
		if (controller == null)
			Debug.LogError ("Voce precisa criar o game controller");

		startPosition = transform.position;
		currentPatrolWaitTime = Random.Range(minPatrolWaiTime, maxPatrolWaitTime);
    }

	private void LateUpdate()
	{
		Behavior ();	
	}
	void Behavior()
	{
		if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0) 
		{
			ControlAnimations ("Idle");
			if (currentPatrolWaitTime > 0) 
			{
				currentPatrolWaitTime -= Time.deltaTime;
				return;
			}
			Vector3 randPos = Vector3.zero;
			if (hord1) {
				randPos = controller.RandomPositionInBounds (controller.horde1.areRadius.GetComponent<Collider> ().bounds);
			} 
			else if (hord2) 
			{
				randPos = controller.RandomPositionInBounds (controller.horde2.areRadius.GetComponent<Collider> ().bounds);
			}

			Patrol (randPos);
			currentPatrolWaitTime =  Random.Range(minPatrolWaiTime, maxPatrolWaitTime);
		}	

	}
	void Patrol(Vector3 randPos)
	{
		ControlAnimations ("Moving");

		NavMeshHit hit;
		NavMesh.SamplePosition (randPos, out hit, Random.Range (2, 8), 1);
		Vector3 finalPosition = hit.position;
		agent.destination = finalPosition;
		transform.LookAt (agent.destination);
			
	}
	void ControlAnimations(string status)
	{
		if (status == "Idle") 
		{
			animator.SetBool ("Idle", true);
			animator.SetBool ("Moving", false);
		} 
		else if (status == "Moving") 
		{
			animator.SetBool ("Idle", false);
			animator.SetBool ("Moving", true);
		}	
	}
}

