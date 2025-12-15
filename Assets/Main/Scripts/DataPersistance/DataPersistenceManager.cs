using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage")]
    [SerializeField] string fileName;
    [SerializeField] bool DebugLogWhereDoesItSave;

    private GameData gameData;
    private List<IDataPersitiens> dataPersistenceObjcets;

    public FileDataHandler DataHandler { get; private set; }
    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        gameData = null;
    }
    private void Start()
    {
        this.DataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjcets = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGameData()
    {
        gameData = new GameData();
    }
    void LoadGameDataFromFile()
    {
        this.gameData = DataHandler.Load();

        if (gameData != null)
            return;

        NewGameData();
        Debug.Log("created savefile at: " + Application.persistentDataPath + "/" + fileName);


    }
    public void CallLoadData(IDataPersitiens persistens)
    {
        LoadGameDataFromFile();
        persistens.LoadData(gameData);
    }
    public void LoadGame()
    {
        LoadGameDataFromFile();
        foreach (IDataPersitiens dataPer in dataPersistenceObjcets)
            dataPer.LoadData(gameData);
    }
    public void SaveGame()
    {

        foreach (IDataPersitiens dataPer in dataPersistenceObjcets)
            dataPer.SaveData(ref gameData);

        DataHandler.Save(gameData);
    }
    public void WriteSaveFile()
    { DataHandler.Save(gameData); }
    public void NewLevelDataReset()
    { gameData.NewLevelDataReset(); }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<IDataPersitiens> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersitiens> dataPersistenceObjcets = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None).OfType<IDataPersitiens>();

        return new List<IDataPersitiens>(dataPersistenceObjcets);
    }

    void OnValidate()
    {
        if (DebugLogWhereDoesItSave)
        {
            DebugLogWhereDoesItSave = false;
            Debug.Log("Save file location: " + Application.persistentDataPath + "/" + fileName);
        }
    }
}
