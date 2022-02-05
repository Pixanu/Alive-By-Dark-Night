using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject Sun;
    private void Start() {
        GetComponent<Collider>().isTrigger = false;
        StartCoroutine(stopphysics());
    }

    IEnumerator stopphysics() {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        if (other.tag == "Monster") {
            if (Sun.GetComponent<LightManager>().is_day) {
                GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>().TakeDamage(3);
                //GameObject.FindGameObjectWithTag("MonsterMovement").GetComponent<Monster>().Stun();
                //make them stunned
            }
            else {
                //GameObject.FindGameObjectWithTag("MonsterMovement").GetComponent<Monster>().Slow();
                //slow
            }
            Destroy(this.gameObject);
        }
    }
}
