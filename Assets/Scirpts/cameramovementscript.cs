using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovementscript : MonoBehaviour
{
   
        public Transform player; // Reference to the player's transform
        public float verticalBoundary; // Vertical boundary from the center of the screen

        private void LateUpdate()
        {
            Vector3 cameraPosition = transform.position;
            Vector3 playerPosition = player.position;

            // Calculate the vertical offset of the player from the center of the camera
            float verticalOffset = playerPosition.y - cameraPosition.y;

            // Check if the player has moved above the vertical boundary
            if (verticalOffset > verticalBoundary)
            {
                cameraPosition.y = playerPosition.y - verticalBoundary;
            }
            // Check if the player has fallen below the frame
            else if (verticalOffset < -verticalBoundary)
            {
                cameraPosition.y = playerPosition.y + verticalBoundary;
            }

            // Apply the new camera position
            transform.position = new Vector3(cameraPosition.x, cameraPosition.y, transform.position.z);
            
        }

}
