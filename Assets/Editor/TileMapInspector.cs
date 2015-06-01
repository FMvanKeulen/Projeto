using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(TileMap))]
public class TileMapInspector : Editor {

	public override void OnInspectorGUI(){
		//base.OnInspectorGUI ();
		DrawDefaultInspector ();

		EditorGUILayout.BeginVertical ();
		EditorGUILayout.Slider (.5f, 0f, 2.0f);
		EditorGUILayout.EndVertical ();

		//Cria um botao no Inspector da Unity para gerar o terreno ao mudar o tamanho de 1 bloco
		if (GUILayout.Button ("Regenerate")) {
			TileMap tileMap = (TileMap)target;
			tileMap.BuildMesh();
		}
	}

}
