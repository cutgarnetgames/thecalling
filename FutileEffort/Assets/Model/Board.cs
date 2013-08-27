using UnityEngine;
using System.Collections;

public class Board {

	public Creature[,] map;
	public Tile[,] tilemap;
	
	public void initBoard(Tile[,] _map){
		map = new Creature[_map.GetLength(0),_map.GetLength(1)];
		tilemap = new Tile[_map.GetLength(0),_map.GetLength(1)];
	}
	
	public bool blocksMovement(int x, int y){
		if(tilemap[x,y] != null){
			return tilemap[x,y].blocksMovement;
		}
		else{
			return false;	
		}
	}
	
	public Creature getCreature(float x, float y){
		return map[(int)(x/MainDemoScript.tw),(int)(y/MainDemoScript.th)];
	}
	
	public void addCreature(Creature c){
		map[(int)c.x/MainDemoScript.tw,(int)c.y/MainDemoScript.th] = c;
	}
	
	/*public bool isClear(int x, int y){
		if(x < 0 || y < 0 || x >= map.GetLength(0) || y >= map.GetLength(1))
			return false;
		return map[x,y] == null;	
	}*/
	
	public bool isCreature(float x, float y){
		if(x < 0 || y < 0 || x/MainDemoScript.tw >= map.GetLength(0) || y/MainDemoScript.th >= map.GetLength(1))
			return false;
		return map[(int)(x/MainDemoScript.tw),(int)(y/MainDemoScript.th)] != null;	
	}
	
	public bool isClear(float x, float y){
		if(x < 0 || y < 0 || x/MainDemoScript.tw >= map.GetLength(0) || y/MainDemoScript.th >= map.GetLength(1))
			return false;
		return !blocksMovement((int)(x/MainDemoScript.tw),(int)(y/MainDemoScript.th)) && map[(int)(x/MainDemoScript.tw),(int)(y/MainDemoScript.th)] == null;	
	}
	
	public void update(Creature c){
		map[(int)c.x/MainDemoScript.tw,(int)c.y/MainDemoScript.th] = c;
	}
	
	public void wipe(Creature c){
		map[(int)c.x/MainDemoScript.tw,(int)c.y/MainDemoScript.th] = null;
	}
	
}
