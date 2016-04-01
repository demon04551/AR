using UnityEngine;
using Vuforia;

public class MVuforiaButton : MonoBehaviour , IVirtualButtonEventHandler {
	public Color[] m_color;
	public Material m_material;

	public GameObject[] target;
	private GameObject currentDisplayBuilding;

	int colorNum = 0, createObjNum = 0;

	void Start () {
		VirtualButtonBehaviour[] vbb = GetComponentsInChildren<VirtualButtonBehaviour>();
		foreach (var item in vbb)
			item.RegisterEventHandler(this);
		//初始化显示的模型
		currentDisplayBuilding = Instantiate (target[createObjNum],Vector3.zero,Quaternion.identity) as GameObject;
		currentDisplayBuilding.transform.parent = this.transform;
		currentDisplayBuilding.transform.localScale = Vector3.one;
		currentDisplayBuilding.transform.localPosition = Vector3.zero;
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{
		if (vb.name == "changeColorButton") {
			if (m_color.Length != 0) {
				m_material.color = m_color[colorNum];	
				colorNum ++;
				if (colorNum >= m_color.Length) {
					colorNum = 0;
				}
			}
		}

		if (vb.name == "changeModelButton") {
			if(target.Length != 0){
				createObjNum ++;
				if(createObjNum >= target.Length)
					createObjNum = 0;
				Destroy (currentDisplayBuilding);
				currentDisplayBuilding = Instantiate(target[createObjNum], Vector3.zero, Quaternion.identity) as GameObject;
				currentDisplayBuilding.transform.parent = this.transform;
				currentDisplayBuilding.transform.localScale = Vector3.one;
				currentDisplayBuilding.transform.localPosition = Vector3.zero;
			}
		}
	}
	
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{

	}

}
