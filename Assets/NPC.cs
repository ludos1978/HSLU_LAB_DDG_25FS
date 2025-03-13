using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public enum CHARACTER_STATE {
	PATROLLING,
	FOLLOW
}


public class NPC : MonoBehaviour
{
	public CHARACTER_STATE myCharacterState = CHARACTER_STATE.PATROLLING;

	public float upForce = 1.0f;

	public List<GameObject> targetPositions = new List<GameObject>();
	public int targetPositionIndex = 0;

	public GameObject enemyGameObject;

	public NavMeshAgent navMeshAgent;

	public GameObject hiscoreObject;

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("This is the Start Function");

		navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

		// hiscoreObject = GameObject.Find("Hiscore");
		// hiscoreObject = GameObject.FindWithTag("Hiscore");
	}

	

	// Update is called once per frame
	void Update()
	{
		// LayerMask layerMask = LayerMask.GetMask("Wall", "Character");
		RaycastHit hit;

		// the target where the raycast should check must be an offset
		Vector3 targetPosition = NPCManager.Instance.playerObject.transform.position - transform.position;
		// we can calculate the xyz offset (x = left/right, z=front/back)
		Vector3 offset = transform.InverseTransformDirection(targetPosition);
		// we can calculate the angle offset from the enemies center view 
		// -180° .. -1° is on my left side
		//  -90° is left of me
		//    0° is in front of me
		//  +90° is right of me
		// +1° .. +180° is on my right side
		// values > 90° and values < -90° are in my back
		// values between -90° and 90° are in my front
		float angle = Mathf.Atan2(offset.x, offset.z) * Mathf.Rad2Deg;

		// Does the ray intersect any objects excluding the player layer
		if (Physics.Raycast(transform.position, targetPosition, out hit, Mathf.Infinity))
		{ 
			Debug.DrawRay(transform.position, targetPosition, Color.yellow); 
			Debug.Log("Did Hit"); 
			
			MyHiscore.Instance.debugOutput = $"{angle} {hit.collider.gameObject.name}";
		}
		else
		{ 
			Debug.DrawRay(transform.position, targetPosition, Color.white); 
			Debug.Log("Did not Hit"); 
			MyHiscore.Instance.debugOutput = "None";
		}

		switch (myCharacterState) {
			case CHARACTER_STATE.PATROLLING:
				Vector3 targetPos = targetPositions[targetPositionIndex].transform.position;
				navMeshAgent.SetDestination(targetPos);

				// Check if we've reached the destination
				if (!navMeshAgent.pathPending) {
					if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
						if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f) {
							Debug.Log("we have arrived!");
							targetPositionIndex = targetPositionIndex + 1;
							targetPositionIndex = targetPositionIndex % targetPositions.Count;
						}
					}
				}

				if ( Vector3.Distance(enemyGameObject.transform.position, gameObject.transform.position) < 5f) {
					myCharacterState = CHARACTER_STATE.FOLLOW;
					navMeshAgent.ResetPath();
				}

				break;
			case CHARACTER_STATE.FOLLOW:

				Vector3 enemyPos = enemyGameObject.transform.position;
				navMeshAgent.SetDestination(enemyPos);

				if ( Vector3.Distance(enemyGameObject.transform.position, gameObject.transform.position) > 5f) {
					myCharacterState = CHARACTER_STATE.PATROLLING;

					MyHiscore.Instance.number += 1;
				}

				if ( Vector3.Distance(NPCManager.Instance.playerObject.transform.position , gameObject.transform.position) > 1f) {
					Debug.Log("Hi player");
				}

				

				break;
		}
	}
}
