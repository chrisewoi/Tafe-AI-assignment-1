using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    private enum RotAxis { ver, hor }
    [SerializeField] private RotAxis rotAxis = RotAxis.hor;
    [SerializeField] private float _sensitivity = 40f;
    [SerializeField] private float _verticalClamp = 30f;
    private float _verRot;
    [SerializeField] private bool _inverted;
    [SerializeField] private GameObject Canvas;
    public float interactDistance = 2f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _verRot = transform.localEulerAngles.x;
    }

    Vector3 GetInputDirection()
    {
        Vector3 dir = new Vector3();
        dir.x = Input.GetAxis("Mouse X");
        dir.z = Input.GetAxis("Mouse Y");
        return dir;
    }

    private void Update()
    {
        Vector3 camDir = GetInputDirection();
        if (rotAxis == RotAxis.ver)
        {
            _verRot += camDir.z * _sensitivity * Time.deltaTime * (_inverted ? 1 : -1);
            _verRot = Mathf.Clamp(_verRot, -_verticalClamp, _verticalClamp);
            transform.localEulerAngles = new Vector3(_verRot, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        else
        {
            float _horRot = camDir.x * _sensitivity * Time.deltaTime * (_inverted ? -1 : 1);
            transform.Rotate(0, _horRot, 0);
        }





        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;


        Canvas.SetActive(false);


        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider != null && hit.collider.transform.root.name.Contains("Switch"))
            {
                Canvas.SetActive(true);
            }
        }
    }

    bool ObjectContainsSwitch(GameObject obj)
    {
        // Check if the object or any of its parents' names contain "Switch"
        while (obj != null && obj.transform.parent != null)
        {
            if (obj.name.Contains("Switch"))
            {
                return true;
            }
            obj = obj.transform.parent.gameObject;
        }

        return false;
    }
}