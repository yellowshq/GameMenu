using UnityEngine;
using System.Collections;

public class MainOption : MonoBehaviour {

    public UIButton ContinueButton;
    public UIButton RestButton;
    public UIButton SaveButton;
    public UIButton QuitButton;

    private bool Saved = false;
	void Start () {
        UIEventListener.Get(ContinueButton.gameObject).onClick = OnContinueButtonClick;
        UIEventListener.Get(RestButton.gameObject).onClick = OnRestButtonClick;
        UIEventListener.Get(SaveButton.gameObject).onClick = OnSaveButtonClick;
        UIEventListener.Get(QuitButton.gameObject).onClick = OnQuitButtonClick;
	}
	
	void Update () {

	}

    public void OnContinueButtonClick(GameObject go)
    {
        this.gameObject.SetActive(false);
        Debug.Log("继续游戏！");
    }
    public void OnRestButtonClick(GameObject go)
    {
        GameController.Instance.RestData();
        //GameInfo.RestInfo();
        Debug.Log("数据已清空！");
        this.gameObject.SetActive(false);
    }
    public void OnSaveButtonClick(GameObject go)
    {
        Saved = true;
        
        Debug.Log("保存成功");
    }
    public void OnQuitButtonClick(GameObject go)
    {
        if (Saved == false)
        {
            GameController.Instance.RestData();
        }
        Saved = false;
        Application.LoadLevel(0);
    }
}
