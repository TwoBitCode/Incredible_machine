using UnityEngine;

public class SlidingGateController : MonoBehaviour
{
    public SliderJoint2D gateJoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball")) // Ensure the ball is tagged correctly
        {
            Debug.Log("Switch Activated!");
            // הפעלת המנוע של השער
            JointMotor2D motor = new JointMotor2D
            {
                motorSpeed = -5f,   // מהירות התנועה (שלילית כי רוצים שיזוז שמאלה)
                maxMotorTorque = 1000f
            };
            gateJoint.motor = motor;
            gateJoint.useMotor = true;
        }
    }
}
