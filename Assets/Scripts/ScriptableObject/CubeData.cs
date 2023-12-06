using UnityEngine;

[CreateAssetMenu(menuName = "Data/Cube")]
public class CubeData : ScriptableObject
{
    [SerializeField] private Color[] colors;
    public Color GetColor(int index)
    {
        return colors[index];
    }
}
