using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

    private GameObject SetDataButtonGo;
    private GameObject openOptionButtonGo;
    public GameObject mainOption;

    private bool bagopened = false;
    public GameObject BagGo;
    void Awake()
    {
        openOptionButtonGo = GameObject.Find("OpenOptionButton");
        SetDataButtonGo = GameObject.Find("SetDataButton");
    }
	void Start () {
        UIEventListener.Get(openOptionButtonGo).onClick = OnclickOptionButtonClick;
        UIEventListener.Get(SetDataButtonGo).onClick = OnSetButtonCilck;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (bagopened == false)
            {
                BagGo.SetActive(true);
                bagopened = true; return;
            }
            else
            {
                BagGo.SetActive(false);
                bagopened = false;
            }

        }
	
	}

    public void OnclickOptionButtonClick(GameObject go)
    {
        mainOption.SetActive(true);
    }

    public void OnSetButtonCilck(GameObject go)
    {
        GameController.Instance.GameData += 1;
        Debug.Log(GameController.Instance.GameData);
    }
}
