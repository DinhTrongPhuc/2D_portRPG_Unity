using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    //ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //references
    public Player player;
    // public weapon weapon...........;


    //logic
    public int pessos;
    public int experience;

    /// <summary>
    /// INT preference 
    /// INT pesos
    /// INT experience
    /// INT Weaponlevel
    /// </summary>

    public void SaveState()
    {
        Debug.Log("Save State");

        string s = "";

        s += "0" + "|";
        s += pessos.ToString() + "|";
        s += experience + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState",s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {   if (PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        // "0|10|15|2" => data 

        //change player skin
        ///...
        /// 
        pessos = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        //change the weapon level
        //...

        Debug.Log("Load State");    
    }
}
