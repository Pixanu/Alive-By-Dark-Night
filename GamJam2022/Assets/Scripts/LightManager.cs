using UnityEngine;
//based on https://www.youtube.com/watch?v=m9hj9PdO328
[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    public Light directional_light;
    public DayNight day_night_preset;
    public float time_scale = 0.1f;
    public bool is_day;

    public AudioSource ThemeNight;
    public AudioSource ThemeDay;
    public AudioSource Scream;

    string previous_state = "day";
    GameObject Hunter, Monster;

    [SerializeField, Range(0,24)] float TimeOfDay;

    public float time_start;

    private void OnValidate() {
        directional_light = RenderSettings.sun;
        TimeOfDay = time_start;
    }


    private void Start() {
        Hunter = GameObject.FindGameObjectWithTag("Hunter");
        Monster = GameObject.FindGameObjectWithTag("Monster");
    }

    public void update_light(float timePercent) {
        RenderSettings.ambientLight = day_night_preset.AmbientColour.Evaluate(timePercent);
        RenderSettings.fogColor = day_night_preset.FogColour.Evaluate(timePercent);
        directional_light.color = day_night_preset.DirectionalColour.Evaluate(timePercent);
        directional_light.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360.0f) - 90.0f, 170, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (day_night_preset == null) {
            return;
        }
        if (Application.isPlaying) {
            TimeOfDay += Time.deltaTime * time_scale;
            TimeOfDay %= 24;
            update_light(TimeOfDay / 24.0f);
        }
        else {
            update_light(TimeOfDay / 24.0f);
        }
        if (TimeOfDay > 6 && TimeOfDay < 18) {
            is_day = true;
            if (previous_state == "night") {
                //make monster smaller
                //play day theme
                previous_state = "day";
                Monster.GetComponent<Monster>().change_at_day();
                ThemeDay.Play(0);
            }
        }
        else {
            is_day = false;
            if (previous_state == "day") {
                //make monster bigger
                ThemeNight.Play(0);
                Scream.Play(0);
                previous_state = "night";
                Monster.GetComponent<Monster>().change_at_night();
            }
        }
    }
}
