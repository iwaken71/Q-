using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
	public List<GameObject> Object = new List<GameObject> ();
	public int key = 0;

	void Awake(){
		foreach (Transform child in transform) {
			Object.Add (child.gameObject);
		}
		Debug.Log (Object.Count);
	}

	public GameObject call(){
		if (key >= Object.Count) {
			key = 0;
		}
		GameObject obj = Object[key];
		//obj = Object [key];
		key++;
		return obj;
	}
}
