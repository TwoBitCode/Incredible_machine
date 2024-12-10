using UnityEngine;

public class ThrowMechanism : MonoBehaviour
{
    [SerializeField] private Rigidbody2D arm; // Rigidbody of the throwing arm
    [SerializeField] private float torqueForce = 500f; // Amount of rotational force
}
