using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
	void Start()
	{
		Debug.Log($"the object Start is called");
	}

	void OnEnable()
	{
		// this would be where the pickup searches the player or applies its random color
		Debug.Log($"the object OnEnable is called");
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
