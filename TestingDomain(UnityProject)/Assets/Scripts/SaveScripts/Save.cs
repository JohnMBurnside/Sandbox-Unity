using UnityEngine;
[System.Serializable]
public class Save : MonoBehaviour
{
    #region SAVE VARIABLES
    public int emptyIntData;
    public float[] position;
    #endregion
    public Save (Movement player)
    {
        emptyIntData = player.emptyInt;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}
