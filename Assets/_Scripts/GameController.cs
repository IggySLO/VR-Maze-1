using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// Define a static GameController
	public static GameController control;

	// Monobehaviour Awake
	void Awake() {
		// Set control to this object
		control = this;
	}

	// Use this for initialization
	void Start () {
		// Load Level 1
		StartCoroutine(LoadLevel("Level01"));
	}
	
	
	public IEnumerator LoadLevel(string sceneName) { 	// Load a Scene, pass scene name
		
		yield return new WaitForEndOfFrame();	 // Wait until the end of the current frame
		
		SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive); 	// Load the scene Asynchronously
		
		StartCoroutine(UnloadLevels(sceneName)); 	// Unload previous scene(s)

	}

	private IEnumerator UnloadLevels(string exception) {		// Unload all levels except "Exception" and the VRMain scene
		
		yield return new WaitForEndOfFrame();		// Wait until the end of the current frame
		
		for(int i = 0; i < SceneManager.sceneCount; i++) {		// For each scene that is currently loaded
			
			// Check this scene to make sure it's NOT 'exception' NOR VRMain scene
			if(SceneManager.GetSceneAt(i).name != exception && SceneManager.GetSceneAt(i).name != "VRMain") {
				// It's not the newly loaded scene nor VRMain; Unload this scene
				SceneManager.UnloadScene(SceneManager.GetSceneAt(i).name);
			}
		}
	}

}
