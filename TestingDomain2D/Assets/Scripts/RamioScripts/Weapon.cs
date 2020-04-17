using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    #region VARIABLES
    public enum Weapons {sword, bow}
    public Weapons      weaponType;
    public string       weaponName;
    public Sprite       weaponArt;
    public int          damage;
    #endregion
}
