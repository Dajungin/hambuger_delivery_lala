using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    int platformIndex = 0;

    public void SetPlatformIndex(int _index)
    {
        platformIndex = _index;
    }
    public int GetPlatformIndex { get { return platformIndex; } }
}
