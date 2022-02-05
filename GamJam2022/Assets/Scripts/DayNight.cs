using UnityEngine;

//following this tutorial https://www.youtube.com/watch?v=m9hj9PdO328

[System.Serializable]
[CreateAssetMenu(fileName = "Day Night Preset", menuName = "Scriptables/Lighting Preset", order = 1)]
public class DayNight : ScriptableObject
{
    public Gradient AmbientColour;
    public Gradient DirectionalColour;
    public Gradient FogColour;
}
