using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;

public class CastleClicker_GameObject : MonoBehaviour {
    public string savePath;
    // Use this for initialization
    void Start () {
        savePath = Application.persistentDataPath + "/save.gd";
        Save save = new Save();
        OpenSave(save);
        GoToScene(save);
	}

    private void GoToScene(Save save)
    {
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OpenSave(Save save)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if (!File.Exists(savePath))
        {
            file = File.Create(savePath);
            save.gold = 2000;
            save.diamonds = 0;
            save.farmers = 0;
            save.castle = 1;
            bf.Serialize(file, save);
            file.Close();
        }
        else
        {
            file = File.Open(savePath, FileMode.Open);
            save = (Save) bf.Deserialize(file);
            file.Close();
        }
    }
    private void SaveGame(Save save)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(savePath, FileMode.Create);
        bf.Serialize(file, save);
        file.Close();
    }
}
