using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //references
    public Player player;
    // public weapon weapon
    public FloatingTextManager floatingTextManager;


    //logic
    public int pessos;
    public int experience;

    //floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    /// <summary>
    /// INT preference 
    /// INT pesos
    /// INT experience
    /// INT Weaponlevel
    /// </summary>

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += pessos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState",s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {   
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //change player skin
        //...
        
        pessos = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        //change the weapon level
        //...

        Debug.Log("Load State");    
    }
}
