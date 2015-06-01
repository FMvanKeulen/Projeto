//--------------------------------------------//
//Controle de atualizaçao					  //
//--------------------------------------------//
//27/05/2015 - Versao 1.0.0                   //
//Fillipe Martins van Keulen			      //
//											  //
//--------------------------------------------//

using UnityEngine;
using System.Collections;

public class SeletorCollider : MonoBehaviour {

	Renderer rend;
	Color buildSelector;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		buildSelector = new Vector4 (21, 191, 50);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Confere se o seletor esta colidindo com outros objetos
	void OnTriggerEnter(Collider collision){
		if (collision.gameObject.name == "DocaBuild") {
			rend.material.color = Color.red;
		}

	}

	void OnTriggerExit(){
	}
}
