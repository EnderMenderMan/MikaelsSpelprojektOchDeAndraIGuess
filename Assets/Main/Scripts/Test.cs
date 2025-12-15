using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            LoadScene(0);
    }

    public void TestLog(string input = "TEST")
    {
        Debug.Log(input);
    }
    public void TestLayerMask(int layerCheck)
    {
        if (((1 << layerCheck) & layerMask) > 0)
            Debug.Log("YES");
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
