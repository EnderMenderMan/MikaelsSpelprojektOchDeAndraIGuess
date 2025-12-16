using UnityEngine;

public class Journal : MonoBehaviour
{
    public enum HintType{
        
    }

    [System.Serializable]
    public struct Hint{
        public string normal;
        public string hard;
    }
    [SerializeField] Hint[] hints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
