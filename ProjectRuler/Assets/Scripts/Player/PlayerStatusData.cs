using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreatePlayerStatusAsset")]
public class PlayerStatusData : ScriptableObject
{
    // 移動加速度
    public float moveSpeed;
    // 移動最大速度
    public float moveSpeedMax;
}
