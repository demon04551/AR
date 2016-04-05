using UnityEngine;
using System.Collections;

public class IImageTarget : MonoBehaviour{
	public int id;
	//target上面包含的building
	private GameObject _targetBuilding;
	public GameObject targetBuilding {
		get { 
			_targetBuilding = GameObject.FindGameObjectWithTag (Tags.Building);
			if (_targetBuilding) {
				return _targetBuilding;
			} else {
				return null;
			}
		}
		set{ _targetBuilding = value; }
	}
}
