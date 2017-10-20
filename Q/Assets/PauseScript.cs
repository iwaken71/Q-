using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {
	public GameObject Pause;

	public void Restart() {
		
	}

	public void Home() {
		
	}

	public void Resume() {
		Time.timeScale = 1;
		DrawLine.Instance.Draw = true;
		Pause.SetActive(false);
	}
}
