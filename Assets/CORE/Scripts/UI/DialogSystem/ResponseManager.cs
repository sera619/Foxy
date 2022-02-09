using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponseManager : MonoBehaviour
{

    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemp;
    [SerializeField] private RectTransform responseContainer;


    private DialogUI dialogUI;

    List<GameObject> tempResponseButtons = new List<GameObject>();


    private void Start(){
        dialogUI = GetComponent<DialogUI>();
    }
    public void ShowResponses(Response[] responses){
        float responseBoxHeight = 0;

        foreach (Response response in responses){
            GameObject responseButton = Instantiate(responseButtonTemp.gameObject,responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponentInChildren<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener( () => OnPickedResponse(response));
            tempResponseButtons.Add(responseButton);
        
            responseBoxHeight += responseButtonTemp.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);

    }

    private void OnPickedResponse(Response response){
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons){
            Destroy(button);
        }

        tempResponseButtons.Clear();
        dialogUI.ShowDialog(response.DialogObject);
    }

}
