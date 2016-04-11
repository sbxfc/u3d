using UnityEngine;
using System.Collections;
using UnityEditor;

//继承ScriptableWizard
public class GenerateStaticCubemap : ScriptableWizard {
	

	public Transform renderPosition;
	public Cubemap cubemap;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//它在向导第一次弹出或者当GUI被用户改变时（如拖进去某些对象，输入某些字符等）时被调用。
	void OnWizardUpdate () {
		helpString = "select transform to renderer from and cubemap to render into";

		if(renderPosition != null && cubemap != null){
			isValid = true;
		}else{
			isValid = false;
		}
	}
	
	//如果isValid为true 调用该方法
	void OnWizardCreate () 
	{
		GameObject go = new GameObject("CubeCam",typeof(Camera));

		go.transform.position = renderPosition.position;  
		go.transform.rotation = Quaternion.identity;  
		
		//渲染立方体纹理
		go.camera.RenderToCubemap(cubemap);  

		//销毁临时相机
		DestroyImmediate(go);  
	}
	
	//在Unity的菜单栏打开这个想到
	[MenuItem("Cube Map/Render Cubemap")]
	static void RenderCubemap() {
		ScriptableWizard.DisplayWizard("Render CubeMap", typeof(GenerateStaticCubemap), "Render!");
	}


}
