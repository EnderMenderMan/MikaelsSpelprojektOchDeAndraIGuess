using UnityEngine;

public class StartPositionAlineWithWorldDataGrid : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (WorldData.Instance == null)
            return;
        transform.position = WorldData.Instance.WorldGrid.WorldToCell(transform.position) + WorldData.Instance.WorldGrid.cellSize / 2;
        Destroy(this);
    }
}
