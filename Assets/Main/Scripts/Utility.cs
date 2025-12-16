using System;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector2 GetVectorClampToOne(Vector2 vec)
    {
        vec.x = GetFloatClampToOne(vec.x);
        vec.y = GetFloatClampToOne(vec.y);
        return vec;
    }
    public static float GetFloatClampToOne(float value)
    {
        if (value == 0)
            return 0;
        if (value < 0)
            return -1;

        return 1;
    }
    public static int CountVectorValues(Vector2 vec, float value)
    {
        if (vec.x == value && vec.y == value)
            return 2;
        if (vec.x == value || vec.y == value)
            return 1;
        return 0;
    }
    public static Vector3 ScaleByWorlGridCellSize(Vector3 vec)
    {
        vec.Scale(WorldData.Instance.WorldGrid.cellSize);
        return vec;
    }


}
