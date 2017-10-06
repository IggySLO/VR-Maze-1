using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

	public void LoadLevel(string sceneToLoad){
		StartCoroutine(GameController.control.LoadLevel(sceneToLoad));
	}
}
