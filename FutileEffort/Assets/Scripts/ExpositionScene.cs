using UnityEngine;
using System.Collections;

public class ExpositionScene : FScene {
	
	FLayer mainLayer;
	
	public ExpositionScene(){
		mainLayer = new ExpositionLayer(this);
		this.AddChild(mainLayer);
	}
	
	public class ExpositionLayer : FLayer{
		
		FLabel speech;
		FLabel skipTip;
		
		public string textToType = "The castle has been corrupted by a\n\ndark force. Time and hearts have\n\nstopped. Only your soul can rescue us.";
		public string textTypedSoFar = "";
		public float secondsPerCharacter = 0.1f;
		public float typeCounter = 0f;
		
		public ExpositionLayer(FScene _parent) : base(_parent){
				
		}
		
		override public void OnEnter(){
			FSprite spr = new FSprite("castle");
			spr.x = Futile.screen.halfWidth;
			spr.y = Futile.screen.height; spr.anchorY = 1.0f;
			mParent.AddChild(spr);
			
			FSprite portrait = new FSprite("portrait1lg");
			portrait.anchorX = 0;
			portrait.anchorY = 0;
			mParent.AddChild(portrait);
			
			speech = new FLabel("mainfont", "");
			speech.x += portrait.width + 20;
			speech.y += Futile.screen.height - 260;
			speech.anchorY = 1.0f;
			speech.alignment = FLabelAlignment.Left;
			speech.color = new UnityEngine.Color(0.768f, 0.768f, 0.768f);
			mParent.AddChild(speech);
			
			skipTip = new FLabel("mainfont", "Spacebar - Skip");
			skipTip.x = Futile.screen.width;
			skipTip.y = 0;
			skipTip.anchorY = 0f;
			skipTip.color = new UnityEngine.Color(0.768f, 0.768f, 0.768f);
			skipTip.alignment = FLabelAlignment.Right;
			mParent.AddChild(skipTip);
		}
		
		override public void OnUpdate(){
			if(textToType.Length > 0){
				typeCounter += Time.deltaTime;
				if(typeCounter > secondsPerCharacter){
					typeCounter -= secondsPerCharacter;
					textTypedSoFar += textToType.Substring(0,1);
					textToType = textToType.Substring(1);
					speech.text = textTypedSoFar;
				}
			}
			
			if(Input.GetKey(KeyCode.Space) && textToType.Length > 0){
				textTypedSoFar += textToType;
				textToType = "";
				speech.text = textTypedSoFar;
				skipTip.text = "Spacebar - Next";
			}
			else if(Input.GetKey(KeyCode.Space)){
					
			}
		}
		
	}
	
}
