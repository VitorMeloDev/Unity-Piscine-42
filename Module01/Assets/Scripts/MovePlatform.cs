using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] private float speed;
    [SerializeField] private Vector3 moveTo;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Mathf.PingPong oscila o valor entre 0 e 1 baseado no tempo e velocidade
        float fator = Mathf.PingPong(Time.time * speed, 1f);

        // Interpola a posição dinamicamente entre o ponto inicial e a soma com o moveTo
        transform.position = Vector3.Lerp(initialPosition, initialPosition + moveTo, fator);
    }
}
