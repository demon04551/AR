using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingletonObj<T> : MonoBehaviour where T : Component {
	
	private static T _instance;

	public static T Instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType (typeof(T)) as T;
			}
			if ( _instance == null ) {
				_instance = new GameObject("Singleton").AddComponent(typeof(T)) as T;
			}
			return _instance;
		}
	}
		
}
