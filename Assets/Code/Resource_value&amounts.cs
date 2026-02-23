using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Resources/ResourceData")]
public class ResourceData : ScriptableObject
{
    [SerializeField]
    private int Wood_amount = 4;
    [SerializeField]
    private int Wood_value = 0;
    
    public int GetWood_amount()
    { return Wood_amount; }

    public int GetWood_value()
    { return Wood_value; }


}
//https://www.youtube.com/watch?v=0IrWYG4JdHo