using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public enum CHARACTER_STATE {
	IDLE,
	PATROLLING_TO_1,
	PATROLLING_TO_2
}


public class NPC : MonoBehaviour
{
		public CHARACTER_STATE myCharacterState = CHARACTER_STATE.IDLE;

		public TextMeshProUGUI tmproObject;

		public float upForce = 1.0f;

		public List<GameObject> targetPositions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This is the Start Function");
    }

    // Update is called once per frame
    void Update()
    {
				// change the states of the character state by keyboard
				if (Keyboard.current[Key.Digit1].wasPressedThisFrame) {
						myCharacterState = CHARACTER_STATE.IDLE;
				}
				if (Keyboard.current[Key.Digit2].wasPressedThisFrame) {
						myCharacterState = CHARACTER_STATE.PATROLLING_TO_1;
				}
				if (Keyboard.current[Key.Digit3].wasPressedThisFrame) {
						myCharacterState = CHARACTER_STATE.PATROLLING_TO_2;
				}

				// debug the informations to console and screen
        Debug.Log($"This is the Update Function {myCharacterState}");
				tmproObject.text = $"you set the value to {myCharacterState}";
				
				Vector3 targetPos;

				// do the different behaviours
				switch (myCharacterState) {
					case CHARACTER_STATE.IDLE:
						break;
					case CHARACTER_STATE.PATROLLING_TO_1:
						targetPos = targetPositions[0].transform.position;
						gameObject.GetComponent<NavMeshAgent>().SetDestination(targetPos);
						break;
					case CHARACTER_STATE.PATROLLING_TO_2:
						targetPos = targetPositions[1].transform.position;
						gameObject.GetComponent<NavMeshAgent>().SetDestination(targetPos);
						break;
				}
    }
}
