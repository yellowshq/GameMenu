using UnityEngine;
using System.Collections;

public class ChildTest : MonoBehaviour {

    public int a = 3;
	// Use this for initialization
	void Start () {
        if (this.transform.childCount > 0)
        {
            foreach (var avb in this.transform.GetComponentsInChildren<ChildTest>())
            {
                avb.a += 2;
            }
            //Debug.Log(transform.GetChild(0).GetComponent<ChildTest>().a);
            //Debug.Log(transform.GetChild(1).GetComponent<ChildTest>().a);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
