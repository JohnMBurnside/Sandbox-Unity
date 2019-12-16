using UnityEngine;
[System.Serializable]
public class Save : MonoBehaviour
{
    #region VARIABLES
    public int emptyIntData;
    public float[] position;
    #endregion
    //SAVE FUNCTIONS
    #region SAVE FUNCTION
    public Save (Player player)
    {
        emptyIntData = player.emptyInt;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
    #endregion
}
