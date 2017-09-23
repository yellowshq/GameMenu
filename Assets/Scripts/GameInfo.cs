using UnityEngine;
using System.Collections;

public class GameInfo{
    //private static GameInfo _instance;
    //public static GameInfo Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = new GameInfo();
    //        }
    //        return _instance;
    //    }
    //}
    public static float volume = 1;
    public  static bool isOpenVolume = true;

    public static void RestInfo()
    {
        volume = 1;
        isOpenVolume = true;
    }
}
