using UnityEngine;
using System.Collections;

public class CameraBehaviourScript : MonoBehaviour {
	public enum Teams{
		Team1,
		Team2
	}
	GameObject position, target;
	public Teams team;
	
	// Use this for initialization
	void Start () {
		if(team == Teams.Team1){
			position = GameObject.Find ("level_loading_team1");
			target = GameObject.Find ("level_loading_team1.Target");
		}
		else if (team == Teams.Team2){
			position = GameObject.Find ("level_loading_team2");
			target = GameObject.Find ("level_loading_team2.Target");
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = position.transform.position;
		transform.LookAt(target.transform);
	}
}
