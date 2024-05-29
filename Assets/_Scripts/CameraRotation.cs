using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	public Light light;
	public bool isActive;
	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3; 
	public float limit = 80; 
	public float zoom = 0.25f; 
	public float zoomMax = 10; 
	public float zoomMin = 3; 
	private float X, Y;

	public CinemachineVirtualCamera cinemachineCamera;

	private void Start ()
	{
		isActive = true;
		
		limit = Mathf.Abs(limit);
		if(limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax)/3);
		transform.position = target.position + offset;
	}

	private void Update ()
	{
		if(!isActive)
			return;
		
		if(Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
		else if(Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
		offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
		
		if(Input.GetMouseButton(0))
			Rotate();
		
		transform.localEulerAngles = new Vector3(-Y, X, 0);
		transform.position = transform.localRotation * offset + target.position;
	}

	private void Rotate()
	{
		X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
		Y += Input.GetAxis("Mouse Y") * sensitivity;
		Y = Mathf.Clamp (Y, -limit, limit);
	}

	public void CameraOff()
	{
		cinemachineCamera.Priority = 9;
		light.enabled = false;
		isActive = false;
	}
	
	public void CameraOn()
	{
		cinemachineCamera.Priority = 11;
		light.enabled = true;
		isActive = true;
	}
	
	public void CameraOn(float offsetZ)
	{
		offset = new Vector3(offset.x, offset.y, -offsetZ);
		cinemachineCamera.Priority = 11;
		light.enabled = true;
		isActive = true;
	}
}