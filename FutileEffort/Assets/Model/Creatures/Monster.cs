using UnityEngine;
using System.Collections;

public class Monster : Creature {
	
	public enum Behaviour{
		Humanoid,
		Hunter
	}
	
	public Behaviour ai;
	
	public Monster(string name, string icon) : base(name, icon){
		this.color = UnityEngine.Color.red;
	}
	
	public void doTurn(Board b){
		if(ai == Behaviour.Humanoid){
			//Stay still until you see something.	
		}
		else if(ai == Behaviour.Hunter){
			//Randomly walk around, beeline on anything you see
			int tx = UnityEngine.Random.Range (-1, 2);
			int ty = UnityEngine.Random.Range (-1, 2);
			while((tx == 0 && ty == 0) || !b.isClear(x+(GameScene.GameLayer.tw*tx), y+(GameScene.GameLayer.th*ty))){
				tx = UnityEngine.Random.Range (-1, 2);
				ty = UnityEngine.Random.Range (-1, 2);
			}
			b.wipe (this);
			x = x+(GameScene.GameLayer.tw*tx);
			y = y+(GameScene.GameLayer.th*ty);
			b.update(this);
		}
		else{
			int tx = UnityEngine.Random.Range (-1, 2);
			int ty = UnityEngine.Random.Range (-1, 2);
			while((tx == 0 && ty == 0) || !b.isClear(x+(GameScene.GameLayer.tw*tx), y+(GameScene.GameLayer.th*ty))){
				tx = UnityEngine.Random.Range (-1, 2);
				ty = UnityEngine.Random.Range (-1, 2);
			}
			b.wipe (this);
			x = x+(GameScene.GameLayer.tw*tx);
			y = y+(GameScene.GameLayer.th*ty);
			b.update(this);	
		}
	}
	
}
