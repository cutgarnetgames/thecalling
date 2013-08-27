using UnityEngine;
using System.Collections;

public class CallingMain : MonoBehaviour {
	
	public int currentState = 0;
	
	void Start () {
	
		FutileParams fparams = new FutileParams(true,true,true,true);
	     
		fparams.AddResolutionLevel(480.0f, 2.0f, 1.0f, ""); //iPhone
	    fparams.backgroundColor = new UnityEngine.Color(0.1294117647f,0.1294117647f,0.1294117647f);
		
	    fparams.origin = new Vector2(0,0);
	     
	    Futile.instance.Init (fparams);
		
		Futile.atlasManager.LoadAtlas("Atlases/Atlas1");
		Futile.atlasManager.LoadAtlas("Atlases/calling_bgs");
		
		Futile.atlasManager.LoadFont("mainfont", "test4x", "Atlases/test4x", 0, 0);
		
		FSceneManager.Instance.SetScene(new MainMenu());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}