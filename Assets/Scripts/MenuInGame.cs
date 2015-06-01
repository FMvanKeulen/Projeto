//--------------------------------------------//
//Controle de atualizaçao					  //
//--------------------------------------------//
//26/05/2015 - Versao 1.0.0                   //
//Fillipe Martins van Keulen			      //
//											  //
//--------------------------------------------//

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMapMouse))]
public class MenuInGame : MonoBehaviour {

	TileMapMouse _tmMouse;
	bool vPause = false;
	public long money = 10000;

	//variavel para controle de acao
	int acao = 0;

	void Start(){
		_tmMouse = GetComponent<TileMapMouse> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			vPause = TogglePause();
		}
	}

	//Cria a interface grafica de Usuario, qualquer GUI so funciona dentro desse metodo
	void OnGUI(){
		GUI.Box(new Rect(Screen.width - 100, 0, 100, 20), "Moedas: " + money.ToString());

		if (GUI.Button (new Rect (10, Screen.height - 50, 50, 20), "Doca")) {
			//Debug.Log ("Clicou para inserir uma doca!");
			acao = 1;
			SendAcao(acao);
		}

		if (vPause){
			GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 200), "Menu");
			if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 + 25, 50, 20), "Sair")){
				Application.Quit();
			}
		}
	}

	void SendAcao(int acao){
		_tmMouse.GetAcao (acao);
	}

	bool TogglePause(){
		if (vPause == false)
			vPause = true;
		else
			vPause = false;
		return vPause;
	}
}
