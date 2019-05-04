using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingInstantiate : MonoBehaviour
{
    public GameObject HealItem;
    GameObject HealingClone;

    // Start is called before the first frame update
    void Start()
    {
        HealingClone = Instantiate(HealItem, transform.position, Quaternion.identity) as GameObject;
    }
}
