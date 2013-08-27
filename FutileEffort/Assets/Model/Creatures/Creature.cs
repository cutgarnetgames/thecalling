using UnityEngine;
using System.Collections;

public class Creature : FSprite {

	public string name;
	public int hp = 5;
	public int dmg = 3;
	public int str = 3;
	
	public Creature(string name, string sprite) : base(sprite){
		this.name = name;
		this.anchorX = 0;
		this.anchorY = 0;
	}
	
	public bool fight(Creature target){
		Debug.Log (name+" attacks the "+target.name);
		target.hp -= this.dmg;
		target.hp -= UnityEngine.Random.Range(0, this.str);
		if(target.hp <= 0){
			return true;	
		}
		return false;
	}
	
	//Return true -> should move
	public bool moveOnto(Board board, Creature target){
		if(target is NPC){
			Debug.Log (((NPC)target).speech);
			GameScene.GameLayer.MessageString = "\"" + ((NPC)target).speech + "\"";
			return false;
		}
		else if(target is Monster){
			if(this.fight (target)){
				//GameScene.GameLayer.MessageString = "You strike the "+target.name+". It fades into ether.";
				Futile.stage.RemoveChild(board.getCreature(target.x, target.y));
				return true;
			}
			else{
				//GameScene.GameLayer.MessageString = "You attack the "+target.name+".";
			}
		}
		return false;
	}
	
	public void doTurn(Board b){
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
