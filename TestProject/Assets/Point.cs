using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

public class Point : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rig rig = null;

    [Header("Settings")]
    [SerializeField] private float pointSpeed1 = 1f;

    private int targetValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        rig.weight = Mathf.MoveTowards(rig.weight, targetValue, pointSpeed1 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            targetValue = targetValue == 0 ? 1 : 0;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetValue = targetValue == 0 ? 0 : 0;
        }

    }
}
