using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

     public class LoseCollider : MonoBehaviour {
     void Start()
     {
         KeepData.keepLevelName = SceneManager.GetActiveScene().name;
     }
 }
