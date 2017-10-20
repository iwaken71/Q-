using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {
	public Renderer rend;
	bool enabled;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (!enabled && rend.isVisible)
			enabled = true;
		if (enabled && !rend.isVisible)
			Destroy(gameObject);
	}

}
