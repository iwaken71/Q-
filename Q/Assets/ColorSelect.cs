using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelect : MonoBehaviour {
	public Vector3 touchStartPos;
	public Vector3 touchEndPos;
	public DrawLine Main;
	public GameObject obj;
	public bool touchflag;
	public GameObject pause;
	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (Time.timeScale > 0) {
			if (Input.GetMouseButtonDown(1)) {
				touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
				obj.SetActive(true);
				obj.transform.position = touchStartPos;
			}
			if (Input.GetMouseButtonUp(1)) {
				touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
				GetDirection();
				obj.SetActive(false);
			}

			//keybord
			//if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//	main.ModeCheck(Direction.Up);
			//}
			//if (Input.GetKeyDown(KeyCode.DownArrow)) {
			//	main.ModeCheck(Direction.Down);
			//}
			//if (Input.GetKeyDown(KeyCode.RightArrow)) {
			//	main.ModeCheck(Direction.Right);
			//}
			//if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			//	main.ModeCheck(Direction.Left);
			//}
		}
	}

	void GetDirection() {
		float directionX = touchEndPos.x - touchStartPos.x;
		float directionY = touchEndPos.y - touchStartPos.y;
		Direction direction;
		if (Mathf.Abs(directionX) > Mathf.Abs(directionY)) {
			if (directionX > 0) {
				direction = Direction.Right;
			} else {
				direction = Direction.Left;
			}
		} else if (Mathf.Abs(directionX) < Mathf.Abs(directionY)) {
			if (directionY > 0) {
				direction = Direction.Up;
			} else {
				direction = Direction.Down;
			}
		} else {
			direction = Direction.Touch;
		}

		Select(direction);
		

	}

	void Select(Direction direction) {
		switch (direction) {
		case Direction.Up:
		Main.ChangeColor(Color.white);
		break;
		case Direction.Down:
		Main.ChangeColor(Color.green);
		break;
		case Direction.Right:
		Main.ChangeColor(Color.red);
		break;
		case Direction.Left:
		Main.ChangeColor(Color.blue);
		break;
		case Direction.Touch:
		if (touchflag) {
			pause.SetActive(true);
			Time.timeScale = 0f;
			DrawLine.Instance.Draw = false;
		} else {
			touchflag = true;
			Invoke("tap", 0.3f);
		}
		break;
		}
	}

	void tap() {
		touchflag = false;
	}

public enum Direction {
		Up,
		Down,
		Right,
		Left,
		Touch

	}
}
