using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int health = 100;
    public GameObject DayNight;
    bool is_evolved = true;
    public bool can_take_damage = true;
    int number_of_deaths = 0;

    IEnumerator ChangeSize(int times, float scale) {
        if (times < 40) {
            yield return new WaitForSeconds(0.1f);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(scale, scale, scale), 6.0f * Time.deltaTime);
            StartCoroutine(ChangeSize(times + 1, scale));
        }
    }

    public void change_at_night() {
        is_evolved = true;
        StartCoroutine(ChangeSize(0, 1.0f));

    }

    public void change_at_day() {
        is_evolved = false;
        StartCoroutine(ChangeSize(0, 0.6f));
    }

    public void TakeDamage(int damage)
    {
        if (is_evolved) {
            return;
        }
        health -= damage;
        if (health < 0 && can_take_damage) {
            number_of_deaths++;
            can_take_damage = false;
            GetComponent<Respawning>().Died();
        }
    }
}
