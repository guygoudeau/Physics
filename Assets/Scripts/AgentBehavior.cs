using UnityEngine;
using System.Collections;

public class AgentBehavior : MonoBehaviour
{
    public int mass;
    public Transform target;

    Vector3 currentVelocity;
    Vector3 displacementVector;
    Vector3 steeringVector;

    void Start()
    {
        currentVelocity = transform.position.normalized; // starting velocity is a random position normalized
    }

    void FixedUpdate() // velocity calculated in fixed update
    {
        displacementVector = (target.position - transform.position).normalized; // this gives desired velocity
        steeringVector = Vector3.ClampMagnitude(displacementVector - currentVelocity, 1).normalized / mass; // desired velocity minus current velocity gives direction to target, dividing by mass impacts how fast it moves
        currentVelocity += steeringVector; // adding steering vector to agent's current velocity makes it go towards target

        Debug.DrawLine(transform.position, (transform.position + steeringVector) * 2.5f); // draws line visualizing steering vector
        Debug.DrawLine(transform.position, (transform.position + displacementVector) * 2.5f);
    }
	
	void LateUpdate() // position calculated in late update
    {
        transform.position += currentVelocity; // Euler integration
	}
}