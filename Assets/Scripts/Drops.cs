using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    [SerializeField] private DropsType type;
    
    public static Action<Drops> Defeated;

    private static bool pause = false;

    private void FixedUpdate()
    {
        if(!pause)
            transform.Translate(Vector2.down * 1 * Time.deltaTime);
    }

    public void Pause(bool state)
    {
        pause = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Base>().type == type)
        {
            Score.Value += 1;
            Destroy(gameObject);
        }
        else
        {
            Defeated?.Invoke(this);
        }
    }
}
