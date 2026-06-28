using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] private List<PlayerController> playerControllers = new List<PlayerController>();
    [SerializeField] private GameObject camera;
    [SerializeField] private Vector3 camPos;

    // Start is called before the first frame update
    void Start()
    {
        ActivePlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ActivePlayer(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ActivePlayer(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ActivePlayer(2);
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
            SceneManager.LoadScene(0);
    }

    void ActivePlayer(int id)
    {
        for (int i = 0; i < playerControllers.Count; i++)
        {
            playerControllers[i].SetActive(false);
            if (id == i)
            {
                playerControllers[i].SetActive(true);
                SetCameraPosition(playerControllers[i].gameObject.transform);
            }
        }
    }

    void SetCameraPosition(Transform parent)
    {
        camera.transform.SetParent(parent);
        camera.transform.SetLocalPositionAndRotation(camPos, camera.transform.rotation);
    }
}
