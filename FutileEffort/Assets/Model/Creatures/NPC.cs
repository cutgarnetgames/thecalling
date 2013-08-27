using UnityEngine;
using System.Collections;

public class NPC : Creature {
	
	public string speech;
	
	public NPC(string name, string icon, string speech) : base(name, icon){
		this.speech = speech;
	}
	
}
