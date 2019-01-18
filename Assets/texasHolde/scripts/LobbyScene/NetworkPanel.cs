using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using UnityEngine.UI;

//this class controls the button host and start game
public class NetworkPanel : MonoBehaviour {

    public Room room;
    public DbRoom dbRoom;
    public Button host;
    public Button startClient;
    // Use this for initialization

    void Start() { }

    void Awake() {
        setButtons();
    }
    

        
    // Update is called once per frame
    void Update() {
    }


    public void StartUpHost()
    {
        room = new Room();
        room.minBet = 1000;
        room.maxBet = 5000;
        room.amountOfPlayers++;
        dbRoom.CreateRoom(room);
        NetworkManager.singleton.StartHost();
    }

    public void StartUpClient()
    {
        Debug.Log(NetworkServer.active);
        room.amountOfPlayers++;
        dbRoom.UpdateRoom(room);
        NetworkManager.singleton.StartClient();
    }

    public void setButtons()
    {
        GameObject.Find("StartHost").GetComponent<Button>().onClick.AddListener(StartUpHost);
        GameObject.Find("StartClient").GetComponent<Button>().onClick.AddListener(StartUpClient);

        dbRoom = new DbRoom();
        room = dbRoom.getRoomInfo();

        if (room == null)
        {

            GameObject.Find("StartHost").GetComponent<Button>().interactable = true;
            GameObject.Find("StartClient").GetComponent<Button>().interactable = false;
        }
        else 
        {
            GameObject.Find("StartHost").GetComponent<Button>().interactable = false;
            GameObject.Find("StartClient").GetComponent<Button>().interactable = true;
        }
    }
            
        
        
    

}
