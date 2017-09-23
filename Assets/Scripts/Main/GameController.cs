using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static GameController _instance = null;
    public static GameController Instance
    {
        get {
            return _instance;
        } 
    }

    void Awake(){
        if (_instance != null)
        {
           Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public int TempData = 0;
    public int GameData = 0;

    public void RestData()
    {
        TempData = 0;
        GameData = 0;
    }
}
