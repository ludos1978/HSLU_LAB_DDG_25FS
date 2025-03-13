using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class NPCManager : MonoBehaviour
{
	static NPCManager _instance = null;
	public static NPCManager Instance {
		get {
			if (_instance != null) {
					return _instance;
			}
			if (_instance == null) {
				_instance = Resources.FindObjectsOfTypeAll<NPCManager>().FirstOrDefault();
				if (_instance == null) {
					_instance = new GameObject("NPCManager", typeof(NPCManager)).GetComponent<NPCManager>();
				}
			}
			return _instance;
		}
	}

	public GameObject playerObject;

}
