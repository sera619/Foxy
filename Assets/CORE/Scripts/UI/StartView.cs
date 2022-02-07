using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class StartView : MonoBehaviour
{

    [SerializeField] private GameObject nameGetPanel;
    [SerializeField] private GameObject nameCheckPanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject namePanel;

    [SerializeField] private TextMeshProUGUI checkNameTMP;
    
    [SerializeField] private TMP_InputField choosenName;

    private string playerName;
    



    public void StartGame(){
        SaveLoad.Save<float>(0f, "PlayerCurrentExp");
        SaveLoad.Save<float>(20f, "PlayerCurrentMaxExp");
        SaveLoad.Save<int>(1, "PlayerLevel");
        SceneManager.LoadScene(3);
    }


    public void EndGame(){
        Application.Quit();
    }


    public void GoBack(){
        menuPanel.SetActive(true);
        nameGetPanel.SetActive(false);
        nameCheckPanel.SetActive(false);
        namePanel.SetActive(false);
    }

    public void GetName(){
        namePanel.SetActive(true);
        nameGetPanel.SetActive(true);
        if(menuPanel.activeSelf){
            menuPanel.SetActive(false);
        }

    }

    public void CheckName(){
        menuPanel.SetActive(false);
        nameGetPanel.SetActive(false);
        if(choosenName.text != ""){
            playerName = choosenName.text;
        }else{
            playerName = "FoxyRox";
        }
        checkNameTMP.text ="Bis du sicher das dein Held\n\n" + playerName + "\n\nheissen soll?";
        nameCheckPanel.SetActive(true);
        SaveLoad.Save<string>(playerName, "PlayerName");
        
    }




}
