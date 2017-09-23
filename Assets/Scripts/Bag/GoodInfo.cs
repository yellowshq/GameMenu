using UnityEngine;
using System.Collections;

public class GoodInfo : MonoBehaviour {

    [HideInInspector]
    public GoodsData good;
    private UILabel numLable;
    public GameObject boxGoMid;
    public GameObject boxGoMax;
    private GameObject infoCell;

    private UIButton goodButton;

    void Awake()
    {
        goodButton = this.GetComponent<UIButton>();
        numLable = transform.Find("Number").GetComponent<UILabel>();
    }
	void Start () {
        //boxGoMid = transform.Find("Board1").gameObject;
        //boxGoMax = transform.Find("Board2").gameObject;
        //boxGoMid.SetActive(true);
        //Debug.Log(boxGoMid);
        //Debug.Log(boxGoMax);
        
        infoCell=GameObject.FindWithTag("InfoCell");
        UIEventListener.Get(goodButton.gameObject).onClick = OnGoodBtnClick;
	}

	void Update () {
	
	}

    public void AddNum(int num=1)
    {

        good.count += num;
        numLable.text = good.count + "";
    }
    public void SetNum(int count)
    {
        numLable.text = count + "";
    }
    public void SetSprite()
    {
        this.transform.GetComponent<UISprite>().spriteName = good.sprite.name;
        goodButton.normalSprite = good.sprite.name;
    }
    public void SetLevel()
    {
        switch (good.level)
        {
            case 1:
                //good.level = 1;
                boxGoMid.SetActive(true);
                break;
            case 2:
               // goodlevel = 2;
                boxGoMax.SetActive(true);
                break;
            case 0:
                // = 0;
                break;
        }
    }

    private void OnGoodBtnClick(GameObject _go)
    {
        if (infoCell.transform.childCount > 0)
        {
            Destroy(infoCell.transform.GetChild(0).gameObject);
        }        
        GameObject go = (GameObject)Instantiate(this.gameObject);
        GoodInfo goinfo = go.GetComponent<GoodInfo>();
        goinfo.good = this.good;
        //goinfo.good.count = 1;
        goinfo.SetNum(1);
        go.transform.parent = infoCell.transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
        ShowArea showAera = infoCell.transform.parent.GetComponent<ShowArea>();
        showAera.ShowInfo(good.Describe);
        showAera.go = this.gameObject;
    }
}
