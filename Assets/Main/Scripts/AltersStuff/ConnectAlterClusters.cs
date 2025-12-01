using UnityEngine;
using UnityEngine.Events;

public class ConnectAlterClusters : MonoBehaviour
{
    public UnityEvent onComplete;
    AlterCluster[] alterClusters;
    void Awake()
    {
        alterClusters = GetComponentsInChildren<AlterCluster>();
        foreach (AlterCluster cluster in alterClusters)
            cluster.onCompletion.AddListener(CheckComplete);
    }
    public void CheckComplete()
    {
        bool existNoneComplete = false;
        foreach (AlterCluster cluter in alterClusters)
        {
            if (cluter.isClusterCompleted)
                continue;
            existNoneComplete = true;
            break;
        }
        if (existNoneComplete)
            return;
        onComplete.Invoke();
    }
}
