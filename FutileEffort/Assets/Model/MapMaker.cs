using UnityEngine;
using System.Collections;

public class MapMaker  {

	public static Tile[,] generateMap(){
		Tile[,] tmap = new Tile[30,30];
		int[,] map = generateCastleMap();
		
		int top_row = MainDemoScript.th * (tmap.GetLength (1) - 1);
		for(int i=0; i<map.GetLength (0); i++){
			for(int j=0; j<map.GetLength (1); j++){
				//if(i == 0 || j == 0 || i == map.GetLength(0)-1 || j == map.GetLength (1)-1){
					if(map[j,i] == 1){
						tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-237", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
					}
					else if(map[j,i] == 4){ //tree1
						tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-403", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
					}
					else if(map[j,i] == 3){ //tree2
						tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-404", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
					}
					else if(map[j,i] == 2){ //gravestone
						int rand = UnityEngine.Random.Range (0, 3);
						if(rand == 0)
							tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-342", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
						else if(rand == 1)
							tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-340", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
						else if(rand == 2)
							tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-343", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
						else if(rand == 3)
							tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-346", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
					}
					else if(map[j,i] == 5){ //rails
						tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-380", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
					}
					else if(map[j,i] == 6){ //rails
						tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-381", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
					}
					else if(map[j,i] == 7){ //candlestick
						tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-352", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
					}
					else if(map[j,i] == 8){ //grass
						int rand = UnityEngine.Random.Range (0, 2);
						if(rand == 0)
							tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-399", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
						else if(rand == 1)
							tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-400", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
						else if(rand == 2)
							tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-401", i*MainDemoScript.tw, top_row - j*MainDemoScript.th);	
					}
					else if(map[j,i] == 9){ //door
						tmap[i,top_row/MainDemoScript.th - j] = new Tile("env-306", i*MainDemoScript.tw, top_row - j*MainDemoScript.th, false);	
					}
					
			}
		}
	
		return tmap;
	}
	
	public static int[,] generateCastleMap(){
		int[,] themap = {
			{2,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			
			{1,1,1,1,1,1, 1,1,1,1,1,1, 1,0,1,1,0,1, 1,1,1,1,1,1, 1,1,1,1,1,1},
			{0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0},
			
			{0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 1,0,0,0,0,9, 0,0,0,0,0,0, 9,0,0,0,0,1, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 1,0,1,1,1,1, 0,0,0,0,0,0, 1,1,1,1,0,1, 0,0,0,0,0,0},
		
			
			{0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0},
			{0,2,0,0,2,0, 1,0,0,0,0,9, 0,0,0,0,0,0, 9,0,0,0,0,1, 0,2,4,0,2,0},
			{0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0, 1,0,0,0,0,1, 0,0,0,0,0,0},
			{5,5,5,6,5,5, 1,1,1,1,1,1, 1,1,0,0,1,1, 1,1,1,1,1,1, 5,6,5,5,5,6},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,3,0},
			{3,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0},
			{0,0,0,0,4,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,3,0},
		};
		
		return themap;
	}
	
	
}
