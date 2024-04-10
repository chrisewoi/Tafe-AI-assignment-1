using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public bool switchOn = false;
    [SerializeField] private GameObject Switch;
    [SerializeField] private GameObject Door;
    public float interactDistance = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.transform.IsChildOf(transform))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    switchOn = !switchOn;
                }
            }
        }




        Quaternion newRotation;
        if (switchOn)
        {
            newRotation = Quaternion.Euler(-60, 0, 0);
            //Vector3 startPos = new Vector3(Door.transform.position.x, 0f, Door.transform.position.z);
            Vector3 startPos = Door.transform.position;
            Vector3 endPos = new Vector3(Door.transform.position.x, -9.6f, Door.transform.position.z);
            Door.transform.position = Vector3.MoveTowards(startPos, endPos, 3 * Time.deltaTime);

        } else
        {
            newRotation = Quaternion.Euler(0, 0, 0);

            Vector3 startPos = Door.transform.position;
            Vector3 endPos = new Vector3(Door.transform.position.x, 0f, Door.transform.position.z);
            Door.transform.position = Vector3.MoveTowards(startPos, endPos, 3 * Time.deltaTime);
        }
        Switch.transform.rotation = newRotation;
    }
}
