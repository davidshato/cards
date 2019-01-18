using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    NetworkPanel networkPanel;
    Button host;
    Button startClient;
    DbRoom dbRoom;
    Room room;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Awake()
    {
        
        
        dbRoom = new DbRoom();
        room = dbRoom.getRoomInfo();

        if (room == null)
        {
            host.interactable = true;
            host.enabled = true;
            startClient.interactable = false;
        }
        else
        {
            host.interactable = false;
            startClient.interactable = true;
            startClient.enabled = true;
        }
    }


}
