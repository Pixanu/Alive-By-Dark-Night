using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawning : MonoBehaviour {
    public bool is_dead = false;
    // Update is called once per frame

    public bool is_player_hunter;

    public Transform TopLeftCorner, TopRightCorner, BottomLeftCorner, BottomRightCorner, Middle;

    public GameObject you_died_text;

    GameObject Hunter, Monster;

    public bool testing;

    private void Start() {
        Hunter = GameObject.FindGameObjectWithTag("Hunter");
        Monster = GameObject.FindGameObjectWithTag("Monster");

        if (testing) {
            StartCoroutine(ReSpawn());
        }
    }

    public void Died() {
        StartCoroutine(ReSpawn());
    }

    IEnumerator ReSpawn() {
        //make the player invurnerable 
        you_died_text.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        you_died_text.SetActive(false);
        Vector3 newPos;
        //find a random place in the opposite quadrant of the opposite player
        if (is_player_hunter) {
            if (Monster.transform.position.x < Middle.position.x) { //its in the left two qudrants
                if (Monster.transform.position.z < Middle.position.z) { //its in the bottom quadrants 
                    //choose the opposite therefore
                    //choose a random number between top right and middle
                    newPos = new Vector3(Random.Range(TopRightCorner.position.x, Middle.position.x), 10, Random.Range(TopRightCorner.position.z, Middle.position.z));
                }
                else {
                    //choose the opposite therefore
                    //choose a random number between bottom right and middle
                    newPos = new Vector3(Random.Range(BottomRightCorner.position.x, Middle.position.x), 10, Random.Range(BottomRightCorner.position.z, Middle.position.z));
                }
            }
            else {//its in the right two qudrants
                if (Monster.transform.position.z < Middle.position.z) { //its in the bottom quadrants 
                    //choose the opposite therefore
                    //choose a random number between top left and middle
                    newPos = new Vector3(Random.Range(TopLeftCorner.position.x, Middle.position.x), 10, Random.Range(TopLeftCorner.position.z, Middle.position.z));
                }
                else {
                    //choose the opposite therefore
                    //choose a random number between bottom left and middle
                    newPos = new Vector3(Random.Range(BottomLeftCorner.position.x, Middle.position.x), 10, Random.Range(BottomLeftCorner.position.z, Middle.position.z));
                }
            }
        }
        else {
            if (Hunter.transform.position.x < Middle.position.x) { //its in the left two qudrants
                if (Hunter.transform.position.z < Middle.position.z) { //its in the bottom quadrants 
                    //choose the opposite therefore
                    //choose a random number between top right and middle
                    newPos = new Vector3(Random.Range(TopRightCorner.position.x, Middle.position.x), 10, Random.Range(TopRightCorner.position.z, Middle.position.z));
                }
                else {
                    //choose the opposite therefore
                    //choose a random number between bottom right and middle
                    newPos = new Vector3(Random.Range(BottomRightCorner.position.x, Middle.position.x), 10, Random.Range(BottomRightCorner.position.z, Middle.position.z));
                    
                }
            }
            else {//its in the right two qudrants
                if (Hunter.transform.position.z < Middle.position.z) { //its in the bottom quadrants 
                    //choose the opposite therefore
                    //choose a random number between top left and middle
                    newPos = new Vector3(Random.Range(TopLeftCorner.position.x, Middle.position.x), 10, Random.Range(TopLeftCorner.position.z, Middle.position.z));
                }
                else {
                    //choose the opposite therefore
                    //choose a random number between bottom left and middle
                    newPos = new Vector3(Random.Range(BottomLeftCorner.position.x, Middle.position.x), 10, Random.Range(BottomLeftCorner.position.z, Middle.position.z));
                }
            }
        }
        Debug.Log(newPos);
        transform.position = newPos;
        if (!is_player_hunter) {
            GetComponent<Monster>().can_take_damage = true;
        }
    }
}