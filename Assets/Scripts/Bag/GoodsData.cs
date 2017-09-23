using UnityEngine;
using System.Collections;


[System.Serializable]
public class GoodsData{

    public int id;
    public int level;
    public string name;
    public Sprite sprite;
    public int type;
    public int count=1;
    public string iconName;
    private string describe;

    //public GoodsData(int _id, int _level, string _name, int _type, string _iconName, string _describe)
    //{
    //    this.id = _id;
    //    this.level = _level;
    //    this.name = _name;
    //    this.type = _type;
    //    this.iconName = _iconName;
    //    this.describe = _describe;
    //}
    //public int Id
    //{
    //    get { return id; }
    //    set { id = value; }
    //}
    //public int Level
    //{
    //    get { return level; }
    //    set { level = value; }
    //}
    //public string Name
    //{
    //    get { return name; }
    //    set { name = value; }
    //}
    //public int Type
    //{
    //    get { return type; }
    //    set { type = value; }
    //}
    //public string IconName1
    //{
    //    get { return iconName; }
    //    set { iconName = value; }
    //}
    //public string IconName
    //{
    //    get { return iconName; }
    //    set { iconName = value; }
    //}
    public string Describe
    {
        get
        {
            DescribeMessage();         
            return describe;
        }
        set {
            if (type == 1)
            { describe = "这是一个装备！"; }
            if(type==0){
                describe="这是一个消耗品！";
              }
        }
    }

    void DescribeMessage()
    {
        int _level = level + 1;
        if (type == 1)
        { describe = "这是一个装备！" + "\n" + "等级:" + _level; }
        if (type == 0)
        { describe = "这是一个消耗品！" + "\n" + "等级:" + _level; }
    }
}
