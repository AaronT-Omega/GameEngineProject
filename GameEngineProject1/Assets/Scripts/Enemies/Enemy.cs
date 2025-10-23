using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Transform playerTarget; // Assign the player's Transform in the Inspector
    public float speed = 3f; // Speed value for enemy

    public abstract void Attack();
    //  Attack function to be used edited later
}
