using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;

    private float Xrotation = 0f;
    private float sensetivity = 100f;

    private void Awake()
    {
        cameraMain = Camera.main;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var cameraX = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;
        var cameraY = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;

        Xrotation -= cameraX;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 60f);
        
        cameraMain.transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
        transform.localEulerAngles += new Vector3(0f, cameraY, 0f);
        
    }
}
