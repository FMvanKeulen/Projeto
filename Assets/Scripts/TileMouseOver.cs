using UnityEngine;
using System.Collections;

public class TileMouseOver : MonoBehaviour {

	public Color highLightColor;

	Renderer rend;
	Color normalColor;
	Collider col;

	void Start(){
		col = GetComponent<Collider> ();
		rend = GetComponent<Renderer> ();
		normalColor = rend.material.color;
	}

	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;

		if (col.Raycast (ray, out hitInfo, Mathf.Infinity)) {
			rend.material.color = highLightColor;
		}
		else {
			rend.material.color = normalColor;
		}
	}
}
