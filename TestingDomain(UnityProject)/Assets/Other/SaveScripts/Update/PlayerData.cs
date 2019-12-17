using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public float[] position;
    public PlayerData(PlayerSave newPlayer)
    {
        level = newPlayer.level;
        health = newPlayer.health;
        position = new float[3];
        position[0] = newPlayer.transform.position.x;
        position[1] = newPlayer.transform.position.y;
        position[2] = newPlayer.transform.position.z;
    }
}
