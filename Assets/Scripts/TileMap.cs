//--------------------------------------------//
//Controle de atualizaçao					  //
//--------------------------------------------//
//24/05/2015 - Versao 1.0.0                   //
//Fillipe Martins van Keulen			      //
//											  //
//--------------------------------------------//

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour {

	//Define o tamanho da largura X e altura Z do terreno
	public int size_x = 100;
	public int size_z = 50;

	//Define o tamanho de cada quadro do terreno
	public float tileSize = 1.0f;

	// Use this for initialization
	void Start () {
		BuildMesh ();
	}

	#region NAO APAGAR ESSA CARALHA
	//Cria a textura
//	void BuildTexture(){
//		int textWidth = 1;
//		int textHeight = 1;
//		Texture2D texture = new Texture2D(textWidth, textHeight);
//
//		for (int y = 0; y < textHeight; y++) {
//			for(int x = 0; x < textWidth; x++){
//				texture.SetPixel(x, y, Color.green);
//			}
//		}
//		texture.Apply();
//		MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
//
//		mesh_renderer.sharedMaterials[0].mainTexture = texture;
//	}
	#endregion

	//Cria o terreno do jogo
	public void BuildMesh(){

		//Define o numero de quadros e o numero de triangulos
		int numTiles = size_x * size_z;
		int numTriangles = numTiles * 2;

		//Define o numero de vertices
		int vsize_x = size_x + 1;
		int vsize_z = size_z + 1;

		int numVerts = vsize_x * vsize_z;

		//Gera os dados do Mesh
		Vector3[] vertices = new Vector3[numVerts];
		Vector2[] uv = new Vector2[numVerts];
		Vector3[] normals = new Vector3[numVerts];
		int[] triangles = new int[numTriangles * 3]; 

		//Cria os vertices e as normais do terreno e, se necessario, mapeamento UV
		int z, x;
		for (z = 0; z < vsize_z; z++) {
			for (x = 0; x < vsize_x; x++){
				vertices[z * vsize_x + x] = new Vector3(x * tileSize, 0, z * tileSize);
				normals[z * vsize_x + x] = Vector3.up;
				uv[z * vsize_x + x] = new Vector2( (float)x / size_x, (float)z / size_z);
			}
		}

		//Faz a triangulacao do terreno
		for (z = 0; z < size_z; z++) {
			for (x = 0; x < size_x; x++){
				int squareIndex = z * size_x + x;
				int triOffset = squareIndex * 6;
				triangles[triOffset + 0] = z * vsize_x + x + 0;
				triangles[triOffset + 2] = z * vsize_x + x + vsize_x + 1;
				triangles[triOffset + 1] = z * vsize_x + x + vsize_x + 0;

				triangles[triOffset + 3] = z * vsize_x + x + 0;
				triangles[triOffset + 5] = z * vsize_x + x + 1;
				triangles[triOffset + 4] = z * vsize_x + x + vsize_x + 1;
			}
		}

		//Cria o mesh a partir dos dados gerados anteriormente
		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;

		//Adiciona o mesh criado ao objeto vazio do jogo
		MeshFilter mf = GetComponent<MeshFilter> ();
		MeshCollider mesh_collider = GetComponent<MeshCollider> ();

		mf.mesh = mesh;
		mesh_collider.sharedMesh = mesh;

		//BuildTexture ();
	}
}
