using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingletonObj<T> : MonoBehaviour where T : MonoBehaviour {
	
	private static T _instance;

	public static T Instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<T>();
			}
			if ( _instance == null ) {
				_instance = new GameObject("Singleton").AddComponent<T>();
			}
			return _instance;
		}
	}

	public void OnApplicationQuit(){
		_instance = null;
	}
		
}
