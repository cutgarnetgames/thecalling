using UnityEngine;
using System.Collections;

public class MainMenu : FScene {
	
	FLayer mainLayer;
	
	public MainMenu() {
		mainLayer = new MainMenuLayer(this);
		this.AddChild(mainLayer);
	}
	
	public void fadeChildren(float alphaTarget){
		foreach(FNode n in _childNodes){
			n.alpha = alphaTarget;	
		}
	}
	
	
	public class MainMenuLayer : FLayer{
		
		FLabel titleLabel;
		FLabel garnetLabel;
		//FLabel instructionLabel;
		
		//float flashElapsed = 0f;
		
		bool fading = false;
		float fadeFactor = 1.0f;
		
		public MainMenuLayer(FScene _parent) : base(_parent){
				
		}
		
		override public void OnEnter(){
			titleLabel = new FLabel("mainfont", "THE CALLING");
			titleLabel.anchorX = 0.5f;
			titleLabel.anchorY = 0.5f;
			titleLabel.x = Futile.screen.halfWidth;
			titleLabel.y = Futile.screen.halfHeight;
			titleLabel.color = new UnityEngine.Color(0.768f, 0.768f, 0.768f);
			mParent.AddChild(titleLabel);
			
			garnetLabel = new FLabel("mainfont", "Cut Garnet Games");
			garnetLabel.anchorX = 0.5f;
			garnetLabel.anchorY = -0.5f;
			garnetLabel.x = Futile.screen.halfWidth;
			garnetLabel.y = Futile.screen.halfHeight/2;
			garnetLabel.color = UnityEngine.Color.red;
			mParent.AddChild(garnetLabel);
			
			/*instructionLabel = new FLabel("mainfont", "Press A Key");
			instructionLabel.anchorX = 0.5f;
			instructionLabel.anchorY = 1.0f;
			instructionLabel.x = Futile.screen.halfWidth;
			instructionLabel.y = Futile.screen.height;
			instructionLabel.color = new UnityEngine.Color(0.768f, 0.768f, 0.768f);
			mParent.AddChild(instructionLabel);*/
		}
		
		override public void OnUpdate(){
			/*if(flashElapsed > 1.0f){
				flashElapsed -= 1.0f;
				instructionLabel.alpha = 1-instructionLabel.alpha;
			}
			flashElapsed += Time.deltaTime;*/
			
			if(Input.anyKeyDown){
				fading = true;
			}
			if(fading){
				((MainMenu)mParent).fadeChildren(fadeFactor);
				fadeFactor -= Time.deltaTime/1.0f;
			}
			if(fadeFactor < -0.5f){
				fading = false;
				FSceneManager.Instance.PopScene();
				FSceneManager.Instance.PushScene(new GameScene());
			}
		}	
	}
}
