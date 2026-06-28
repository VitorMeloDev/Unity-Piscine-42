using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPlayer : MonoBehaviour
{
    private bool isCompleted = false;
    private bool isHere = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mark;
    [SerializeField] private float tolerance = 0.2f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isHere)
            return;
        CheckDistance();
    }

    void CheckDistance()
    {
        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (distance < tolerance)
        {
            isCompleted = true;
            mark.SetActive(true);
            player.GetComponent<PlayerController>().SetInPosition(isCompleted);
        }
        else
        {
            isCompleted = false;
            mark.SetActive(false);
            player.GetComponent<PlayerController>().SetInPosition(isCompleted);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isHere = false;
        }
    }
}
