using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BagManager : MonoBehaviour {

    public GoodsData[] Eatgoods;
    public GoodsData[] Equipmentgoods;
    public GoodsData[] BaoShigoods;
    public GoodsData[] ZuoQigoods;
    public GameObject goods;

    private UIButton mEatButton;
    private UIButton mEquipmentButton;
    private UIButton mAllButton;
    private UIButton mBSButton;
    private UIButton mZQButton;
    public CreatBag gameData;

    //private string[] EatSprites = new string[] { "yao01", "yao02", "yao03" };
    //private string[] EquipmentSprites = new string[] { "sha01", "sha02", "sha03", "sha04", "sha05" };

    private GoodsData TempGood;
    private int[] level = new int[3] { 0, 1, 2 };
    private string rname;

    [HideInInspector]
    public List<GameObject> cells;

    private List<GameObject> ShowList = new List<GameObject>();
    public List<GameObject> AllGoods = new List<GameObject>();
    public List<GameObject> EatList = new List<GameObject>();
    public List<GameObject> EquipmentList = new List<GameObject>();
    public List<GameObject> BsList = new List<GameObject>();
    public List<GameObject> ZqList = new List<GameObject>();

    private ShowArea showArea;
    bool isall = true;
    bool isEat=true;
	void Start () {
        mAllButton = transform.Find("Bg/AllGoods").GetComponent<UIButton>();
        mEatButton = transform.Find("Bg/Eat").GetComponent<UIButton>();
        mEquipmentButton = transform.Find("Bg/Equipment").GetComponent<UIButton>();
        mBSButton = transform.Find("Bg/BSGoods").GetComponent<UIButton>();
        mZQButton = transform.Find("Bg/ZQGoods").GetComponent<UIButton>();
        showArea = transform.Find("Bg/ShowArea").GetComponent<ShowArea>();
        showArea.showEatList = EatList;
        showArea.showEquipmentList = EquipmentList;

        UIEventListener.Get(mAllButton.gameObject).onClick = OnAllBtnCllcik;
        UIEventListener.Get(mEatButton.gameObject).onClick = OnEatButtonClick;
        UIEventListener.Get(mEquipmentButton.gameObject).onClick = OnEquipmentButtonClick;
        UIEventListener.Get(mBSButton.gameObject).onClick = OnBsButtonClick;
        UIEventListener.Get(mZQButton.gameObject).onClick = OnZqButtonClick;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            int rtype =Random.Range(0, 4);
            //Debug.Log(rtype);
            switch (rtype)
            {
                case 0:
                    TempGood = GetRandomGoods(Eatgoods);
                    //Debug.Log(TempGood);
                    PickGooodUp(goods, EatList);
                    break;

                case 1:
                    TempGood = GetRandomGoods(Equipmentgoods);
                    PickGooodUp(goods, EquipmentList);
                    break;

                case 2:
                    TempGood = GetRandomGoods(BaoShigoods);
                    PickGooodUp(goods, BsList);
                    break;
                case 3:
                    TempGood = GetRandomGoods(ZuoQigoods);
                    PickGooodUp(goods, ZqList);
                    break;

            }
            //if (rtype == 0)
            //{
            //    TempGood = GetRandomGoods(Eatgoods);
            //    //Debug.Log(TempGood);
            //    PickGooodUp(goods, EatList);
            //    //if (!isEat)
            //    //{
            //    //    EatList[EatList.Count - 1].SetActive(false);
            //    //}
            //}
            //else
            //{
            //    TempGood = GetRandomGoods(Equipmentgoods);
            //    PickGooodUp(goods, EquipmentList);
            //    //if (isEat)
            //    //{
            //    //    EquipmentList[EquipmentList.Count - 1].SetActive(false);
            //    //}
            //}

        }
	}


    void PickUp(GameObject goods, List<GameObject> list)
    {
        //GoodInfo tempGoodInfo=goods.GetComponent<GoodInfo>();

        for (int k = 0; k < list.Count; k++)
        {
            if (TempGood.id == list[k].GetComponent<GoodInfo>().good.id)
            {
                list[k].GetComponent<GoodInfo>().AddNum(1);
                return;
            }
        }

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].transform.childCount > 0)
                {
                    bool cancreate = true;
                    GoodInfo[] good = new GoodInfo[cells[i].transform.childCount];
                    //Debug.Log("count"+cells[i].transform.childCount);
                    for (int k = 0; k < good.Length; k++)
                    {
                        good[k] = cells[i].transform.GetChild(k).GetComponent<GoodInfo>();
                        //Debug.Log(good[k].good.id);
                    }
                    //cells[i].transform.GetComponentsInChildren<GoodInfo>();                
                    //if (good==null)
                    //{
                    //    continue;
                    //}
                    foreach (var go in good)
                    {
                        if (go.good.type == TempGood.type)
                        {
                            cancreate = false;

                            if (go.good.id == TempGood.id)
                            {

                                go.AddNum(1);
                                return;
                            }
                        }

                    }
                    if (cancreate)
                    {
                        GameObject tempGo = CreateGood(i);
                        list.Add(tempGo);

                        return;
                    }

                }
                else
                {
                    if (cells[i].transform.childCount == 0)
                    {

                        //Debug.Log(i + "childCount=0");
                        GameObject tempGo = CreateGood(i);
                        list.Add(tempGo);
                        break;
                    }
                }
            }
        //for (int i = 0; i < cells.Count; i++)
        //{
        //    if (cells[i].transform.childCount == 0)
        //    {
                
        //        Debug.Log(i+"childCount=0");
        //        GameObject tempGo = CreateGood(i);
        //        list.Add(tempGo);
        //        break;
        //    }
        //}
        
    }


    /// <summary>捡起道具 </summary>
    /// <param name="goods"></param>
    /// <param name="list"></param>
    void PickGooodUp(GameObject goods, List<GameObject> list)
    {
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].transform.childCount > 0)
            {
                GoodInfo goodInfo = cells[i].transform.GetChild(0).GetComponent<GoodInfo>();
                if (goodInfo.good.id == TempGood.id)
                {
                    goodInfo.AddNum(1);
                    return;
                }
            }
            else
            {
                GameObject go = CreateGood(i);
                AllGoods.Add(go);
                list.Add(go);
                break;
            }
        }
    }

    /// <summary> 创建道具
    /// </summary>
    GameObject CreateGood(int x)
    {
        GameObject go = NGUITools.AddChild(cells[x], goods);
        //list.Add(go);
        GoodInfo goodInfo = go.GetComponent<GoodInfo>();
        goodInfo.good = TempGood;
        goodInfo.SetSprite();
        goodInfo.SetLevel();
        // go.GetComponent<GoodInfo>().type = rtype;
        go.transform.localPosition = Vector3.zero;

        return go;
    } 

    GoodsData GetRandomGoods(GoodsData[] ArgGoods)
    {
        GoodsData goodData = ArgGoods[Random.Range(0, ArgGoods.Length)];
        return goodData;
    }


    #region 点击按钮切换背包
    public void OnAllBtnCllcik(GameObject _go)
    {
        AddGoods(AllGoods);
        ShowGoods();
    }
    public void OnEatButtonClick(GameObject _go)
    {
        AddGoods(EatList);
        ShowGoods();
    }

    public void OnEquipmentButtonClick(GameObject _go)
    {
        AddGoods(EquipmentList);
        ShowGoods();
    }

    public void OnBsButtonClick(GameObject _go)
    {
        AddGoods(BsList);
        ShowGoods();
    }

    public void OnZqButtonClick(GameObject _go)
    {
        AddGoods(ZqList);
        ShowGoods();
    }
    #endregion

    void AddGoods(List<GameObject> _goList)
    {
        if (ShowList != null)
        {
            foreach (var sl in ShowList)
            {
                sl.gameObject.SetActive(false);
            }
            ShowList.Clear();       
        }
 
        for (int i = 0; i < _goList.Count; i++)
        {
            _goList[i].SetActive(true);
            ShowList.Add(_goList[i]);
        }
    }

    void ShowGoods()
    {
        
        for (int i = 0; i < ShowList.Count; i++)
        {
            ShowList[i].transform.parent = cells[i].transform;
            ShowList[i].transform.localPosition = Vector3.zero;
        }
    }
}