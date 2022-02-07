using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class StartView : MonoBehaviour
{
    [Header("Name Settings")]
    [SerializeField] private GameObject nameGetPanel;
    [SerializeField] private GameObject nameCheckPanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject namePanel;
    [SerializeField] private TextMeshProUGUI checkNameTMP;
    [SerializeField] private TMP_InputField choosenName;


    [Header("Help Settings")]
    [SerializeField] private GameObject helpPanel;

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

    public void ShowHelp(){
        helpPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void HideHelp() {
        helpPanel.SetActive(false);
        menuPanel.SetActive(true);
    }


    public void GihubLink(){
        Application.OpenURL("http://github.com/sera619/Foxy");
    }

    public void EmailLink(){
        string email = "Seraphinus619@gmail.com";
        Application.OpenURL("mailto:"+email);
    }

    public void HomepageLink(){
        Application.OpenURL("https://sera619.github.io/FOX-TALE-Alpha/");
    }


}
