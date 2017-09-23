using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject StartButtonGO;
    public GameObject ContinueButtonGo;
    public GameObject OptionButton;
    public GameObject GameOption;

	void Start () {
        UIEventListener.Get(StartButtonGO).onClick = StarGame;
        UIEventListener.Get(OptionButton).onClick = OnOptionButtonClick;
        UIEventListener.Get(ContinueButtonGo).onClick = OnContinueButtonCilck;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StarGame(GameObject go)
    {
        if (GameController.Instance != null)
        {
            GameController.Instance.RestData();
        }
        Application.LoadLevel(1);
    }
    public void OnContinueButtonCilck(GameObject go)
    {
        Application.LoadLevel(1);
    }

    public void OnOptionButtonClick(GameObject go)
    {
        this.gameObject.SetActive(false);
        GameOption.SetActive(true);
    }
}
