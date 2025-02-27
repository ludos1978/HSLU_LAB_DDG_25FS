using System.Collections.Generic;
using TMPro;
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

	public TextMeshProUGUI tmproObject;

	public float upForce = 1.0f;

	public List<GameObject> targetPositions = new List<GameObject>();
	public int targetPositionIndex = 0;

	public GameObject enemyGameObject;

	public NavMeshAgent navMeshAgent;

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("This is the Start Function");

		navMeshAgent = gameObject.GetComponent<NavMeshAgent>();


	}

	// Update is called once per frame
	void Update()
	{
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

				if ( Vector3.Distance(enemyGameObject.transform.position, gameObject.transform.position) < 3f) {
					myCharacterState = CHARACTER_STATE.FOLLOW;
					navMeshAgent.ResetPath();
				}

				break;
			case CHARACTER_STATE.FOLLOW:

				Vector3 enemyPos = enemyGameObject.transform.position;
				navMeshAgent.SetDestination(enemyPos);

				if ( Vector3.Distance(enemyGameObject.transform.position, gameObject.transform.position) > 5f) {
					myCharacterState = CHARACTER_STATE.PATROLLING;
				}


				break;
		}



	}
}
