[System.Serializable]
public class GameData
{
    public (float x, float y) playerPosition;
    public int loadedSceneIndex;
    public int loadedLevelIndex;
    // music
    public float[] soundsVolume;

    public void NewLevelDataReset()
    {
        loadedSceneIndex = -1;
        loadedLevelIndex = -1;
    }

    public GameData()
    {
        NewLevelDataReset();
        soundsVolume = new float[0];
    }
    public GameData(float[] volumes, int loadedLevelIndex, int loadedSceneIndex)
    {
        this.loadedSceneIndex = loadedSceneIndex;
        this.loadedLevelIndex = loadedLevelIndex;
        soundsVolume = volumes;
    }
}
