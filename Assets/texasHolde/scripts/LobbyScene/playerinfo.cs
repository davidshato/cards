using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


//the info panel in the lobby scene hold the player information
public class playerinfo : MonoBehaviour {

    public Sprite[] avatars;
    public Sprite[] Status;

  
    public TextMeshProUGUI userName;
    public TextMeshProUGUI chipsAmount;
    public Image status;


    public Image playersImage;
    private DbPlayer Data;
    public PlayerData info;



	// Use this for initialization
	void Start () {

        

    }//on start of the object fill in all of the player data

    void Awake() {
        Data = new DbPlayer();
        info = Data.GetPlayerByUserName(PlayerPrefs.GetString("userName"));

        userName.text = info.UserName;
        chipsAmount.text = info.Money.ToString();

        if (info.Money > 30000)
            status.sprite = Status[4];
        else
            if (info.Money < 30000 && info.Money > 20000)
            status.sprite = Status[3];
        else
                if (info.Money < 20000 && info.Money > 15000)
            status.sprite = Status[2];
        else
                     if (info.Money < 15000 && info.Money > 5000)
            status.sprite = Status[1];
        else
            status.sprite = Status[0];

        playersImage.sprite = avatars[info.PlayerImage];
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void logOut()//log the player out of the game 
    {
        
        Data.deleteUserConnection(info.UserName);
        SceneManager.LoadScene("LoginPage");
        


    }

   
}
