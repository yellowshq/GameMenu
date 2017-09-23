using UnityEngine;
using System.Collections;

public class SetInfo : MonoBehaviour {

    public GameObject GameMenu;
    public UISlider VolumeSlider;
    public UIToggle VolumeToggle;
    public UIButton DoneButton;
    public UIButton RestButton;
    void Awake()
    {
        UpdateUI();
    }
	void Start () {
        UIEventListener.Get(DoneButton.gameObject).onClick = OnDoneButtonClick;
        UIEventListener.Get(RestButton.gameObject).onClick = OnRestButtonClick;
        //VolumeSlider.onChange.Add(new EventDelegate(this, "OnSliderChange"));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnDoneButtonClick(GameObject go)
    {
        GameInfo.volume = VolumeSlider.value;
        GameInfo.isOpenVolume = VolumeToggle.value;
        this.gameObject.SetActive(false);
        GameMenu.SetActive(true);
    }
    public void OnRestButtonClick(GameObject go)
    {
        GameInfo.RestInfo();
        UpdateUI();
    }

    public void UpdateUI()
    {
        VolumeSlider.value = GameInfo.volume;
        VolumeToggle.value = GameInfo.isOpenVolume;
    }

    public void OnSliderChange()
    {

    }
}
