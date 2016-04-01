using UnityEngine;
using UnityEditor;

public class SetMaterial : EditorWindow {
	[MenuItem ("mWinodw/Tools")]
	static void Init(){
		SetMaterial window = (SetMaterial)EditorWindow.GetWindow(typeof(SetMaterial));
		window.Show();
	}

	void OnGUI(){
		GUILayout.Label("dfdf");
	}
}
