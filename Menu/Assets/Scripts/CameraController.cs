using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    // Follow player camera
    [SerializeField] private Transform Human;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;

    //Limits camera
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float bottomLimit;
    [SerializeField] float upperLimit;
	private float lookAhead;
    private void Update()
    {
        // Room camera
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

        transform.position = new Vector3
            (
            Mathf.Clamp(Human.position.x + lookAhead, leftLimit, rightLimit),
            Mathf.Clamp(Human.position.y + 2, bottomLimit, upperLimit),
            transform.position.z
            );
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * Human.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
