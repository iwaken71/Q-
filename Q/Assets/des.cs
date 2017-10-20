using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class des : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("destroy", 3f);
		
	}
	
	// Update is called once per frame
	void destroy () {
		Destroy (this.gameObject);
	}
}
