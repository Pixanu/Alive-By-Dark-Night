using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterDrop : MonoBehaviour
{
    public int number_of_traps = 3;
    public int trap_max = 3;

    public GameObject Trap;

    //will return true if a trap has been added, false if at max
    public bool add_trap() {
        if (number_of_traps > trap_max) {
            return false;
        }
        number_of_traps++;
        return true;
    }

    public void Update() {
        if (Input.GetKeyUp("e") && number_of_traps > 0) {
            Instantiate(Trap, transform.position + new Vector3 (0, -1.0f,0), Quaternion.identity);
            number_of_traps--;
        }
    }
}
