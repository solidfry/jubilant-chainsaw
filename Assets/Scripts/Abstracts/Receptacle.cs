using Ingredients;
using UnityEngine;

public abstract class Receptacle : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ingredient>())
        {
            other.transform.parent = transform;
        }
    }

}