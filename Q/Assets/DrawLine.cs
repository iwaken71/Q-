using UnityEngine;
using System.Collections;

public class DrawLine : SingletonMonoBehaviour<DrawLine> {
	public GameObject ParentObj;
	public GameObject linePrefab;
	public GameObject BouncePrefab;
	public GameObject EmptyObj;
	public float lineLength = 0.2f;
	public float lineWidth = 0.1f;
	private Vector3 touchPos;
	public ObjectPool pool;
	public bool pooling = false;
	public bool gravity = false;
	public int count;
	public Rigidbody Rig;
	public Color color = Color.white;
	public Renderer rend;
	public Material white;
	public Material red;
	public Material blue;
	public Material green;
	public bool Draw;

	void Start() {

	}

	void Update() {
		if (Draw) {
			drawLine();
		}
	}

	void drawLine() {

		if (Input.GetMouseButtonDown(0)) {

			touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			touchPos.z = 0;
			ParentObj = Instantiate(EmptyObj, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			Rig = ParentObj.GetComponent<Rigidbody>();
		}

		if (Input.GetMouseButton(0)) {

			Vector3 startPos = touchPos;
			Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			endPos.z = 0;

			if ((endPos - startPos).magnitude > lineLength) {
				GameObject obj = null;
				count++;
				if (pooling) {
					obj = pool.call();
				} else {
					if (color == Color.green) {
						obj = Instantiate(BouncePrefab, transform.position, transform.rotation) as GameObject;
					} else {
						obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
					}
				}
				obj.transform.position = (startPos + endPos) / 2;
				obj.transform.right = (endPos - startPos).normalized;

				obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);

				obj.transform.parent = ParentObj.transform;

				touchPos = endPos;
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			Rig.isKinematic = false;
			//if (gravity) {
			//	Rig.useGravity = true; ;
			//}
			switch (color) {
			case Color.white:
			Rig.useGravity = true;
			break;

			case Color.red:
			Rig.useGravity = true;
			Rig.freezeRotation = true;
			break;

			case Color.blue:
			Rig.isKinematic = true;
			break;

			case Color.green:
			Rig.useGravity = true;
			break;
			}
		}
	}

	public void ChangeColor(Color col) {
		color = col;
		switch (color) {
		case Color.white:
		rend.material = white;
		break;

		case Color.red:
		rend.material = red;
		break;

		case Color.blue:
		rend.material = blue;
		break;

		case Color.green:
		rend.material = green;
		break;
		}
	}
}

public enum Color {
	white,
	red,
	blue,
	green
}