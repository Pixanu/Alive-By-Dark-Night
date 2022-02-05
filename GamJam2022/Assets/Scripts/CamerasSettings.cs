using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasSettings : MonoBehaviour
{
    // Start is called before the first frame update
    Camera MonsterCam;
    Camera HunterCam;

    public bool inversted_split_screen = false;
    public bool opposite_screens = false;

    void Start()
    {
        MonsterCam = GameObject.FindGameObjectWithTag("Monster").GetComponentInChildren<Camera>();
        HunterCam = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();

        if (inversted_split_screen) {
            split_vertically();
        }
        else {
            split_horizontally();
        }
    }

    public void split_vertically() {
        if (opposite_screens) {
            MonsterCam.rect = new Rect(0.5f, 0.0f, 1.0f, 1.0f);
            HunterCam.rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
        }
        else {
            MonsterCam.rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
            HunterCam.rect = new Rect(0.5f, 0.0f, 1.0f, 1.0f);
        }
    }

    public void split_horizontally() {
        if (opposite_screens) {
            MonsterCam.rect = new Rect(0.0f, 0.5f, 1.0f, 1.0f);
            HunterCam.rect = new Rect(0.0f, 0.0f, 1.0f, 0.5f);
        }
        else {
            MonsterCam.rect = new Rect(0.0f, 0.0f, 1.0f, 0.5f);
            HunterCam.rect =  new Rect(0.0f, 0.5f, 1.0f, 1.0f);
        }
    }
}
