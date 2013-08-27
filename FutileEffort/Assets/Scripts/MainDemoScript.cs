using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainDemoScript : MonoBehaviour {
	
	public static int tw = 16;
	public static int th = 24;
	
	public bool turnEnded = false;
	
	public int turnNumber = 1;
	public FLabel turnCounterLabel;
	public FLabel timerLabel;
	public FLabel gameOverLabel;
	
	public static string MessageString = "";
	public FLabel messageLabel;
	
	bool playBeat = false;
	bool gameOverFlag = false;
	
	static float turnLength = 5;
	float timer = turnLength;
	
	public Board board;
	public Creature player;
	public List<Creature> creatures = new List<Creature>();
	
	// Use this for initialization
	void Start () {
		FutileParams fparams = new FutileParams(true,true,true,true);
	     
	    //fparams.AddResolutionLevel(480.0f, 1.0f, 1.0f, ""); //iPhone
		fparams.AddResolutionLevel(480.0f, 1.0f, 1.0f, ""); //iPhone
	    fparams.backgroundColor = new UnityEngine.Color(0.1294117647f,0.1294117647f,0.1294117647f);
		
	    fparams.origin = new Vector2(0,0);
	     
	    Futile.instance.Init (fparams);
		
		Futile.atlasManager.LoadAtlas("Atlases/Atlas1");
		
		board = new Board();
		//board.initBoard();
		
		player = new Creature("You", "char-456");
		player.x = 1 * tw;
		player.y = 1 * th;
		Futile.stage.AddChild(player);
		board.addCreature(player);
		player.color = UnityEngine.Color.yellow;
		
		Monster m = new Monster("Blood Mage", "char-460");
		m.str = 1;
		m.x = 5 * tw; m.y = 5 * th;
		Futile.stage.AddChild(m);
		board.addCreature(m);
		creatures.Add(m);
		
		NPC knight = new NPC("Holy Knight", "char-466", "The heart of this castle has become corrupted.");
		knight.x = 3*tw; knight.y = 3*th;
		Futile.stage.AddChild(knight);
		board.addCreature(knight);
		creatures.Add (knight);
		
		Tile[,] map_plan = MapMaker.generateMap();
		for(int i=0; i<map_plan.GetLength(0); i++){
			for(int j=0; j<map_plan.GetLength(1); j++){
				board.tilemap[i,j] = map_plan[i,j];
				if(map_plan[i,j] != null){
					Futile.stage.AddChild(map_plan[i,j]);
				}
			}
		}
		
		Futile.atlasManager.LoadFont("mainfont", "test4x", "Atlases/test4x", 0, 0);
		
		turnCounterLabel = new FLabel("mainfont", "The Calling: Turn "+turnNumber);
		turnCounterLabel.anchorX = 0;
		turnCounterLabel.anchorY = 1.0f;
		turnCounterLabel.x = 0;
		turnCounterLabel.y = Futile.screen.height;
		turnCounterLabel.color = UnityEngine.Color.white;
		Futile.stage.AddChild(turnCounterLabel);
		
		timerLabel = new FLabel("mainfont", "Your Heart Beats: ");
		timerLabel.anchorX = 1.0f;
		timerLabel.anchorY = 1.0f;
		timerLabel.x = Futile.screen.width;
		timerLabel.y = Futile.screen.height;
		timerLabel.color = UnityEngine.Color.red;
		Futile.stage.AddChild(timerLabel);
		
		messageLabel = new FLabel("mainfont", "");
		messageLabel.anchorX = 0;
		messageLabel.anchorY = 1.0f;
		messageLabel.x = 0;
		messageLabel.y = Futile.screen.height - 20;
		Futile.stage.AddChild(messageLabel);
		
		gameOverLabel = new FLabel("mainfont", "The Castle Falls Silent");
		gameOverLabel.anchorX = 0.5f;
		gameOverLabel.anchorY = 0.5f;
		gameOverLabel.x = Futile.screen.width/2;
		gameOverLabel.y = Futile.screen.height/2;
		gameOverLabel.color = UnityEngine.Color.white;
		//Futile.stage.AddChild(gameOverLabel);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(gameOverFlag){
			return;	
		}
		
		timer -= Time.deltaTime;
		
		if(Input.GetKeyDown("q")){
			FSoundManager.PlaySound("beat", 1.0f);	
		}
		
		if(timer >= 0){
			if(playBeat){
				timerLabel.text = "Your Heart Beats: "+timer.ToString("F0");	
				timerLabel.color = UnityEngine.Color.red;
			}
			else{
				timerLabel.text = "Your Heart Stops: "+timer.ToString("F0");	
				timerLabel.color = UnityEngine.Color.grey;
			}
		}
		else{
			if(playBeat){
				//End the game	
				playBeat = !playBeat; 
				//gameOverFlag = true;
				//Futile.stage.AddChild(gameOverLabel);
			}
			else{
				playBeat = !playBeat;
				FSoundManager.PlaySound("beat", 1.0f);
			}
			timer += turnLength;
		}
		
		if(playBeat){
			if(Input.GetKeyDown("w") || Input.GetKeyDown (KeyCode.UpArrow)){
				if(board.isClear(player.x, player.y + th)){
					board.wipe (player);
					player.y += th;	
					turnEnded = true;
				}
				else if(board.isCreature(player.x, player.y + th)){
					if(player.moveOnto (board, board.getCreature(player.x, player.y + th))){
						board.wipe (player);
						player.y += th;	
					}
					turnEnded = true;
				}
			}
			else if(Input.GetKeyDown ("a") || Input.GetKeyDown (KeyCode.LeftArrow)){
				if(board.isClear(player.x - tw, player.y )){
					board.wipe (player);
					player.x -= tw;
					turnEnded = true;
				}
				else if(board.isCreature(player.x - tw, player.y)){
					if(player.moveOnto (board, board.getCreature(player.x - tw, player.y))){
						board.wipe (player);
						player.y -= tw;	
					}
					turnEnded = true;
				}
			}
			else if(Input.GetKeyDown ("s") || Input.GetKeyDown (KeyCode.DownArrow)){
				if(board.isClear(player.x, player.y - th)){
					board.wipe (player);
					player.y -= th;
					turnEnded = true;
				}
				else if(board.isCreature(player.x, player.y - th)){
					if(player.moveOnto (board, board.getCreature(player.x, player.y - th))){
						board.wipe (player);
						player.y -= th;	
					}
					turnEnded = true;
				}
			}
			else if(Input.GetKeyDown ("d") || Input.GetKeyDown (KeyCode.RightArrow)){
				if(board.isClear(player.x + tw, player.y )){
					board.wipe (player);
					player.x += tw;
					turnEnded = true;
				}
				else if(board.isCreature(player.x + tw, player.y)){
					if(player.moveOnto (board, board.getCreature(player.x + tw, player.y))){
						board.wipe (player);
						player.y += tw;	
					}
					turnEnded = true;
					
				}
			}
		}
		
		if(playBeat && turnEnded){
			if(MessageString.Length > 0){
				messageLabel.text = MessageString;	
			}
			else{
				messageLabel.text = "";	
			}	
			MessageString = "";
			
			playBeat = false;
			turnEnded = false;	
			board.update(player);
			foreach(Creature c in creatures){
				if(c is Monster){
					c.doTurn(board);
				}
				else if(c is NPC){
					
				}
				board.update (c);
			}
			
			timer = turnLength;
			FSoundManager.PlaySound("beat", 1.0f);
			turnNumber++;
			turnCounterLabel.text = "The Calling: Turn "+turnNumber;
		}
	}

}
