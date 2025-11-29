using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private bool[] bools;

    public void TestLog(string input = "TEST")
    {
        Debug.Log(input);
    }
}
