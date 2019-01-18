using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



//this class control the input of the player in this page
public class Register : MonoBehaviour {

    private DbPlayer db;
    public InputField userName;
    public InputField firstName;
    public InputField lastName;
    public InputField password;
    public InputField confirm;
    public InputField Email;
    public Dropdown profileImage;
    public Text Errors;


    public bool check(string info, Text obj)
    {
        if (info == "")
        {
            obj.text = "empty input please fill All The Labels";
            return false;
        }
        else
        {
            obj.text = "";
            return true;
        }
    }//this function check if the input is empty
    
    public bool patternCheck(string info, Text obj)//get parameters (inputfield.text,inputMSG)
    {
        string pattrn = @"[A-Z][a-zA-Z0-9]{8,15}$";
        Match match = Regex.Match(info, pattrn);

        if (match.Success)
        {
            obj.text = "";
            return true;
        }
        else
        {

            obj.text = "worng input pattern Have To be like David121212";
            return false;
        }

    }//check that the user name and the password is in the pattern that needed

    public void RegisterClick()//make the registraion to the data base and create a profile
    {
        string patternA = @"[A-Za-z]$";//check if all are alfabet.
        db = new DbPlayer();

        Match matchFname = Regex.Match(firstName.text, patternA);
        Match matchLname = Regex.Match(firstName.text, patternA);

        Match matchEmail = Regex.Match(Email.text,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");


        if (check(firstName.text, Errors) && check(lastName.text, Errors) && check(Email.text, Errors) && check(confirm.text, Errors) && patternCheck(password.text, Errors) && patternCheck(userName.text, Errors))
        {
            if (matchEmail.Success && matchFname.Success && matchLname.Success)
            {
                if (!db.ExistUser(userName.text))
                {
                    if (password.text.Equals(confirm.text))
                    {
                        PlayerData info = new PlayerData();
                        info.SetPlayer(firstName.text, lastName.text, Email.text, userName.text, password.text, profileImage.value);
                        db.InsertPlayer(info);
                        SceneManager.LoadScene("LoginPage");

                    }
                    else
                    {
                        Errors.text = "You Must Confirm The Password";

                    }


                }
                else
                {
                    Errors.text = "User Name Is Allready Taken";

                }
            }
            else
            {
                Errors.text = "Wrong input Email/First Name/Last Name";
            }

        }
        
        

    }

    public void GoBack()//return to the Login Page
    {

        SceneManager.LoadScene("LoginPage");


    }
}
