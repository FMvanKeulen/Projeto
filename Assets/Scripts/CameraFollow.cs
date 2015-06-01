//--------------------------------------------//
//Controle de atualizaçao					  //
//--------------------------------------------//
//25/05/2015 - Versao 1.0.0                   //
//Fillipe Martins van Keulen			      //
//											  //
//--------------------------------------------//


using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject cursor;
	public GameObject mapa;
	Collider mapaCollider;

	void Start(){
		mapaCollider = mapa.GetComponent<Collider> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(mapaCollider.Raycast(ray, out hit, 100.0F)){
				transform.position = new Vector3 (cursor.transform.position.x,
			 	                                  cursor.transform.position.y + 30,
			    	                              cursor.transform.position.z);
			}
		}

	}
}
