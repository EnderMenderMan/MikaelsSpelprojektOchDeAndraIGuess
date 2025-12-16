[System.Serializable]
public class GameData
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
    }
    public struct Journal
    {
        int[] reveledClueIndexes;
    }

    public (float x, float y) playerPosition;
    public int loadedSceneIndex;
    public int loadedLevelIndex;
    public Difficulty difficulty = Difficulty.Normal;
    public Journal journal;
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
