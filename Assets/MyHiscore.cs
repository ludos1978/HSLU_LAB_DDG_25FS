using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class MyHiscore : MonoBehaviour
{
	static MyHiscore _instance = null;
	public static MyHiscore Instance {
		get {
			if (_instance != null) {
					return _instance;
			}
			if (_instance == null) {
				_instance = Resources.FindObjectsOfTypeAll<MyHiscore>().FirstOrDefault();
				if (_instance == null) {
					_instance = new GameObject("MyHiscore", typeof(MyHiscore)).GetComponent<MyHiscore>();
				}
			}
			return _instance;
		}
	}

	public int number = 0;

	public string debugOutput = "";

	public void Update()
	{
		tmproObject.text = $"{debugOutput}";
	} 

	public TextMeshProUGUI tmproObject;


}
