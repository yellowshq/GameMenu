using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowArea : MonoBehaviour {

    private UILabel desLabel;
    private UIButton useBtn;
    private GameObject mCell;
    [HideInInspector]
    public GameObject go;
    private BagManager bagManager;

    public List<GameObject> showEatList=new List<GameObject>();
    public List<GameObject> showEquipmentList = new List<GameObject>();
	void Start () {
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();
        useBtn = transform.Find("UseButton").GetComponent<UIButton>();     
        mCell = transform.Find("Cell").gameObject;
        UIEventListener.Get(useBtn.gameObject).onClick = OnUseBtnClick;
        //et = bagManager.EatList;
	}
	
	void Update () {
	
	}

    public void ShowInfo(string _des){
        desLabel.text = _des;
    }

    private void OnUseBtnClick(GameObject _go)
    {
        if (mCell.transform.childCount > 0)
        {
            Destroy(mCell.transform.GetChild(0).gameObject);
            desLabel.text = "";
            GoodInfo goinfo=go.GetComponent<GoodInfo>();

            if (goinfo.good.count > 1)
            {
                goinfo.good.count--;
                int count = goinfo.good.count;
                goinfo.SetNum(count);
            }
            else
            {
                if (goinfo.good.type == 0)
                {
                    showEatList.Remove(go);
                }
                else
                {
                    showEquipmentList.Remove(go);
                }
                Destroy(go);
            }
        }
    }
}
