using Cinemachine;
using UnityEngine;

namespace _Scripts
{
	public class CameraRotation : MonoBehaviour
	{
		[SerializeField] private CinemachineVirtualCamera cinemachineCamera;
		[SerializeField] private new Light light;
		[SerializeField] private Transform target;
		[SerializeField] private Vector3 offset;
		[SerializeField] private float sensitivity = 3; 
		[SerializeField] private float limit = 80; 
		[SerializeField] private float zoom = 0.25f; 
		[SerializeField] private float zoomMax = 10; 
		[SerializeField] private float zoomMin = 3; 
	
		private bool _isActive; 
		private float X, Y;

	
		private void Start ()
		{
			_isActive = true;
		
			limit = Mathf.Abs(limit);
			if(limit > 90) limit = 90;
			offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax)/3);
			transform.position = target.position + offset;
		}

		private void Update ()
		{
			if(!_isActive)
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
			_isActive = false;
		}
	
		public void CameraOn()
		{
			cinemachineCamera.Priority = 11;
			light.enabled = true;
			_isActive = true;
		}
	
		public void CameraOn(float offsetZ)
		{
			offset = new Vector3(offset.x, offset.y, -offsetZ);
			cinemachineCamera.Priority = 11;
			light.enabled = true;
			_isActive = true;
		}
	}
}