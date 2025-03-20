using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	public List<Transform> pickupPositions = new List<Transform>();

	public List<GameObject> pickupPrefabs = new List<GameObject>();

	// Start is called before the first frame update
	void Start() {
		// this is with predefined positions (from gameObjects)
		for (int i = 0; i < pickupPositions.Count; i++) {
			// i get the transform (pos & rot) from the pickup we currently work with
			Transform thisTransform = pickupPositions[i].transform;

			// we select a random prefab from the pickupPrefabs
			int thisPickupId = Random.Range(0, pickupPrefabs.Count);
			GameObject thisPickup = pickupPrefabs[thisPickupId];

			GameObject thisInstance = Instantiate(thisPickup, thisTransform.position, thisTransform.rotation, transform);
			
			Debug.Log($"instantiate object at {i} and SetActive now");
			thisInstance.SetActive(true);
		}

		// this is with completely randomized positions
		// for (int i = 0; i < 3; i++) {
		// 	// create a random position
		// 	Vector3 pickupPosition = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
		// 	// select a pickup from the list to instantiate
		// 	int thisPickupId = Random.Range(0, pickupPrefabs.Count);
		// 	GameObject thisPickup = pickupPrefabs[thisPickupId];
		// 	// instantiate the object 
		// 	GameObject thisInstance = Instantiate(thisPickup, pickupPosition, Quaternion.identity, transform);

		// 	// do some output
		// 	Debug.Log($"instantiate object at {i} and SetActive now");
		// 	thisInstance.SetActive(true);
		// }
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}
