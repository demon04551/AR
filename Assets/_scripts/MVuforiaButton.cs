using UnityEngine;
using Vuforia;

public class MVuforiaButton : MonoBehaviour , IVirtualButtonEventHandler {
	public Color[] m_color;//改变后的颜色
	public Material m_currentMaterial;//当前的材质
	public GameObject[] target;//用于替换的模型

	private GameObject currentDisplayBuilding;//当前在target上面的模型
	private BuildingType m_buildingData;

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
		//改变颜色
		if (vb.name == "changeColorButton") {
			if (m_color.Length != 0) {
				m_currentMaterial.color = m_color[colorNum];	
				colorNum ++;
				if (colorNum >= m_color.Length) {
					colorNum = 0;
				}
			}
		}
		//改变模型样式
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
		//脱卡
		if (vb.name == "MoveOutButton") {
			if (currentDisplayBuilding != null) {
				currentDisplayBuilding.transform.parent = null;
				currentDisplayBuilding.transform.localPosition = this.transform.localPosition;
				currentDisplayBuilding.transform.localRotation = this.transform.localRotation;
			}
		}
	}
	
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{

	}

}
