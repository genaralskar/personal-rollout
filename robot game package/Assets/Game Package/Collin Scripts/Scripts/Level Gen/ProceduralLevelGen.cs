using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

namespace genaralskar
{
	public class ProceduralLevelGen : MonoBehaviour
	{

		public static UnityAction<Transform, float> OnPieceExit = delegate { };
		
		[SerializeField] private GameObject[] levelPieces;
		//private Queue<GameObject> spawnedPieces;
		private List<GameObject> spawnedPieces;
		
	
		private void Start()
		{
			//spawnedPieces = new Queue<GameObject>();
			spawnedPieces = new List<GameObject>();
			FirstSpawn();
			SpawnNewPiece(transform, 50);
			SpawnNewPiece(transform, 50);
			OnPieceExit += SpawnNewPiece;
			OnPieceExit += DestroyLastPiece;
		}

		private void FirstSpawn()
		{
			int randomIndex = Random.Range(0, levelPieces.Length); //get random index
			print(randomIndex);
			
			GameObject newPiece = Instantiate(levelPieces[randomIndex]); //spawn piece from that random index

			newPiece.transform.position =
				transform.position + Vector3.forward * newPiece.GetComponent<LevelPieceController>().Offset;
			spawnedPieces.Add(newPiece);
		}
		
		private void SpawnNewPiece(Transform position, float offset)
		{
			int randomIndex = Random.Range(0, levelPieces.Length); //get random index
		//	print(randomIndex);
			
			GameObject newPiece = Instantiate(levelPieces[randomIndex]); //spawn piece from that random index
		//	print(offset + " : " + newPiece.GetComponent<LevelPieceController>().Offset);

			newPiece.transform.position = spawnedPieces.Last().transform.position +
			                              (Vector3.forward * 
			                               (spawnedPieces.Last().GetComponent<LevelPieceController>().Offset +
			                                newPiece.GetComponent<LevelPieceController>().Offset));
			
			spawnedPieces.Add(newPiece);
		}
	
		private void DestroyLastPiece(Transform what, float ever)
		{
			GameObject tempObj = spawnedPieces.First();
			spawnedPieces.Remove(spawnedPieces.First());
			Destroy(tempObj);
		}
	}
}

