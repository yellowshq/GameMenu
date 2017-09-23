using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatBag : MonoBehaviour {

    public GameObject cellPrefab;

    public GameObject parent;

    public List<GameObject> cells;
    //public List<GameObject> mGoods;
    private BagManager bagManager;
    private string rname;
    private string[] EatSprites = new string[]{ "yao01","yao02","yao03" };
    private string[] EquipmentSprites = new string[] { "sha01","sha02","sha03","sha04","sha05" };
    private int[] level=new int[3]{0,1,2};

    public List<GameObject> EatList = new List<GameObject>();
    public List<GameObject> EquipmentList = new List<GameObject>();


    void Awake()
    {

    }
	void Start () {
        bagManager = transform.Find("PackgePanel").GetComponent<BagManager>();
        cells = CreatCells(parent);
        bagManager.cells = cells;
	}
	
	
	void Update () {
  
	}

    List<GameObject> CreatCells(GameObject varparent)
    {
       List<GameObject> Tempcells = new List<GameObject>();
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject go = NGUITools.AddChild(varparent, cellPrefab);
                Tempcells.Add(go);
            }
        }
        varparent.GetComponent<UIGrid>().Reposition();
        return Tempcells;
    }

}
