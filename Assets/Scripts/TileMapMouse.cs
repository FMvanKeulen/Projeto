//--------------------------------------------//
//Controle de atualizaçao					  //
//--------------------------------------------//
//24/05/2015 - Versao 1.0.0                   //
//Fillipe Martins van Keulen			      //
//											  //
//--------------------------------------------//


using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMap))]
[RequireComponent(typeof(MenuInGame))]
public class TileMapMouse : MonoBehaviour {

	TileMap _tileMap;
	MenuInGame _money;

	Vector3 currentTileCoord;
	public Transform selectionCube;

	Color normalColor;
	Collider col;
	public int acao = 0;
	Renderer selCube;
	
	void Start(){
		_tileMap = GetComponent<TileMap> ();
		_money = GetComponent<MenuInGame> ();
		col = GetComponent<Collider> ();
		selCube = selectionCube.GetChild (0).GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		
		if (col.Raycast (ray, out hitInfo, Mathf.Infinity)) {
			int x = Mathf.FloorToInt( hitInfo.point.x / _tileMap.tileSize);
			int z = Mathf.FloorToInt( hitInfo.point.z / _tileMap.tileSize);

			currentTileCoord.x = x;
			currentTileCoord.z = z;

			selectionCube.transform.position = currentTileCoord * 5f;
			if (selectionCube.transform.position.y > 0.1f){
				selectionCube.transform.position = new Vector3(selectionCube.transform.position.x,
				                                               0.13f,
				                                               selectionCube.transform.position.z);
			}
		}
		else {
			//foda-se
		}

		if (acao == 0) {
			selCube.enabled = false;
		}
		else {
			selCube.enabled = true;
		}
	}

	public void GetAcao(int vAcao){
		acao = vAcao;
		if (acao == 1) {
			StartCoroutine(InstantiateResources("Doca"));
		}
	}

	IEnumerator InstantiateResources(string go){
		while (go != "") {			
			if (go == "Doca") {
				selectionCube.transform.localScale = new Vector3 (2, 1, 2);	
				yield return Input.GetMouseButtonUp(0);
				if (Input.GetMouseButtonUp (0)) {
					if (_money.money >= 1000){
						Instantiate (Resources.Load ("Doca"), selectionCube.transform.position, Quaternion.identity);
						Debug.Log ("Doca adicionada a partir do clique no botao do menu");
						go = "";
						selectionCube.transform.localScale = new Vector3(1, 1, 1);					
						acao = 0;
						_money.money -= 1000;
					}
					else{
						go = "";
						selectionCube.transform.localScale = new Vector3(1, 1, 1);					
						acao = 0;
						Debug.Log ("You shall not pass");
					}
				}
			}
		}
		yield break;
	}
}
