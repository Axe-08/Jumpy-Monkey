using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformMovement : BasePlatform
{
    // Start is called before the first frame update
    public float minMoveSpeed;
    public float maxMoveSpeed;
    private float moveSpeed;
    public Vector3 defaultCentre;
    public float HorizontalMovementConstraint;
    private float direction = 1f;
    public float bounceFactor;

    void HorizontalMovement()
    {

        Vector3 targetPosition = defaultCentre + new Vector3(HorizontalMovementConstraint * direction, 0, 0);//induce erratic movement in starting maybe it will fix itself

        // Move the platform
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Change the direction
            direction *= -1f;
            // Update the start position to the current position

        }

    }

    protected override void Start()
    {
        RandmoveSpeed();
        base.Start();
    }
    // Update is called once per frame
    protected override void Update()
    {
        HorizontalMovement();
        base.Update();
    }

    //randomize move speed
    private void RandmoveSpeed()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    

}
