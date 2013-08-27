using UnityEngine;
using System.Collections;

public class Tile : FSprite {
	
	public bool blocksVision = true;
	public bool blocksMovement = true;
	
	public Tile(string icon, float x, float y) : base(icon){
		this.anchorX = 0;
		this.anchorY = 0;
		this.x = x;
		this.y = y;
	}
	
	public Tile(string icon, float x, float y, bool _blocksMovement) : base(icon){
		this.anchorX = 0;
		this.anchorY = 0;
		this.x = x;
		this.y = y;
		this.blocksMovement = _blocksMovement;
	}
	
}
