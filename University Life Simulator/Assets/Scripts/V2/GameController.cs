using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController game;
    public float player_position_x;
    public float player_position_y;

    [Serializable]
    class SaveData
    {
        public float player_position_x;
        public float player_position_y;
    }
    //Runs before start
    //Singleton Manager
    private void Awake()
    {
        if(game == null){
            DontDestroyOnLoad(gameObject);
            game = this;
        }
        else if(game != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        //Creating a binary foramtter and savefile
        BinaryFormatter f = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveData.dat");
        //Creating object to hold save data and writing it to our binary file
        SaveData data = new SaveData();
        data.player_position_x = player_position_x;
        data.player_position_y = player_position_y;
        f.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/saveData.dat"))
        {
            BinaryFormatter f = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveData.dat", FileMode.Open);
            SaveData data = (SaveData)f.Deserialize(file);
            file.Close();
            player_position_x = data.player_position_x;
            player_position_y = data.player_position_y;

        }
    }

    public void Delete()
    {
        if(File.Exists(Application.persistentDataPath + "/saveData.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveData.dat");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
