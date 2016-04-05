using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildManage {
	private static BuildManage _instance ;
	private List<BuildingType> buildingList;

	public static BuildManage Instance {
		get { 
			if (_instance == null) {
				_instance = new BuildManage ();
			}
			return _instance;
		}
	}
	public void init(){
		
	}
}
