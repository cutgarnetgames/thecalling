using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameScene : FScene {
	/************************************/
	FLayer mainLayer;
	
	public GameScene(){
		mainLayer = new GameLayer(this);
		this.AddChild(mainLayer);
	}
	/************************************/
	
	public class GameLayer : FLayer{
		
		FCamObject fco;
		
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
		
		FSprite uibar;
		FSprite chatbar;
		
		public GameLayer(FScene _parent) : base(_parent){
				
		}
		
		override public void OnEnter(){
			Tile[,] map_plan = MapMaker.generateMap();
			board = new Board();
			board.initBoard(map_plan);
			
			player = new Creature("You", "char-456");
			player.x = 10 * tw;
			player.y = 4 * th;
			Futile.stage.AddChild(player);
			board.addCreature(player);
			//player.color = UnityEngine.Color.yellow;
			
			fco = new FCamObject();
			fco.follow(player);
			fco.setWorldBounds(new Rect(-120, -80, 480, 30*MainDemoScript.th));//map_plan.GetLength(0)*MainDemoScript.th));
			fco.setBounds(new Rect(-240, -160,
				240, 160));
			AddChild(fco);
			
			
			Monster m = new Monster("Blood Mage", "char-460");
			m.str = 1;
			m.x = 15 * tw; m.y = 12 * th;
			Futile.stage.AddChild(m);
			board.addCreature(m);
			creatures.Add(m);
			
			NPC knight = new NPC("Holy Knight", "char-466", "The heart of this cast\nle has become corrupted.");
			knight.x = 16*tw; knight.y = 5*th;
			knight.color = UnityEngine.Color.yellow;
			Futile.stage.AddChild(knight);
			board.addCreature(knight);
			creatures.Add (knight);
			
			knight = new NPC("Holy Knight", "char-466", "You should not enter.\nYou cannot save it.");
			knight.x = 13*tw; knight.y = 5*th;
			knight.color = UnityEngine.Color.yellow;
			Futile.stage.AddChild(knight);
			board.addCreature(knight);
			creatures.Add (knight);
			
			for(int i=0; i<map_plan.GetLength(0); i++){
				for(int j=0; j<map_plan.GetLength(1); j++){
					board.tilemap[i,j] = map_plan[i,j];
					if(map_plan[i,j] != null){
						AddChild(map_plan[i,j]);
					}
				}
			}
			
			uibar = new FSprite("uibar");
			uibar.anchorX = 0;
			uibar.anchorY = 1.0f;
			uibar.x = 0;
			uibar.y = Futile.screen.height;
			uibar.scaleY = 0.8f;
			fco.AddChild (uibar);
			
			chatbar = new FSprite("uibar");
			chatbar.anchorX = 0;
			chatbar.anchorY = 0;
			chatbar.x = 0;
			chatbar.y = 0;
			chatbar.scaleY = 1.4f;
			chatbar.alpha = 0f;
			fco.AddChild (chatbar);
			
			turnCounterLabel = new FLabel("mainfont", "Turn "+turnNumber);
			turnCounterLabel.anchorX = 0;
			turnCounterLabel.anchorY = 1.0f;
			//turnCounterLabel.scale = 0.8f;
			//turnCounterLabel.scale = 0.5f;
			turnCounterLabel.x = 4;
			turnCounterLabel.y = Futile.screen.height-2;
			turnCounterLabel.color = UnityEngine.Color.white;
			fco.AddChild(turnCounterLabel);
			
			timerLabel = new FLabel("mainfont", "Tick");
			timerLabel.anchorX = 1.0f;
			timerLabel.anchorY = 1.0f;
			//timerLabel.scale = 0.8f;
			timerLabel.x = Futile.screen.width-4;
			timerLabel.y = Futile.screen.height-2;
			timerLabel.color = UnityEngine.Color.red;
			fco.AddChild(timerLabel);
			
			messageLabel = new FLabel("mainfont", "");
			messageLabel.anchorX = 0f;
			messageLabel.anchorY = 0f;
			messageLabel.x = 2f;
			messageLabel.y = 4f;
			messageLabel.color = UnityEngine.Color.white;
			fco.AddChild(messageLabel);
			
			gameOverLabel = new FLabel("mainfont", "The Castle Falls Silent");
			gameOverLabel.anchorX = 0.5f;
			gameOverLabel.anchorY = 0.5f;
			gameOverLabel.x = Futile.screen.width/2;
			gameOverLabel.y = Futile.screen.height/2;
			gameOverLabel.color = UnityEngine.Color.white;
			
			fco.MoveToFront();
			//Futile.stage.AddChild(gameOverLabel);
		}
		
		override public void OnUpdate(){
			if(gameOverFlag){
				return;	
			}
			
			if(Input.GetKey("c")){
				Debug.Log (fco.x+","+fco.y);
				Debug.Log (player.x +":"+ player.y);
			}
			
			timer -= Time.deltaTime;
			
			if(Input.GetKeyDown("q")){
				FSoundManager.PlaySound("beat", 1.0f);	
			}
			
			if(timer >= 0){
				if(playBeat){
					timerLabel.text = "("+timer.ToString ("F0")+") Tick";	
					timerLabel.color = new UnityEngine.Color(0.768f, 0.768f, 0.768f);//UnityEngine.Color.red;
				}
				else{
					timerLabel.text = "("+timer.ToString ("F0")+") Tock";//timer.ToString("F0");	
					timerLabel.color = UnityEngine.Color.grey;
				}
			}
			else{
				if(true || playBeat){
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
			
			if(true || playBeat){
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
							player.x += tw;	
						}
						turnEnded = true;
						
					}
				}
			}
			
			if(playBeat && turnEnded){
				if(MessageString.Length > 0){
					messageLabel.text = MessageString;
					chatbar.alpha = 1;
				}
				else{
					messageLabel.text = "";
					chatbar.alpha = 0;
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
				turnCounterLabel.text = "Turn "+turnNumber;
			}
		}
		
	}
	
	
}
