using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CSSnakeMovement : MonoBehaviour 
{
    public List<Transform> BodyParts = new List<Transform>();

    public float mindistance = 0.25f;
    public float speed = 1;
    public float rotationSpeed = 50;

    public GameObject bodyprefab;


    private float distance;
    private Transform currentBodyPart;
    private Transform previousBodyPart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move()
    {
        float currentSpeed = speed;

        BodyParts[0].Translate(BodyParts[0].forward * currentSpeed * Time.smoothDeltaTime, Space.World);

        if (Input.GetAxis("Horizontal") != 0) 
        {
            BodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.Deltatime * Input.GetAxis("Horizontal"));
        }
        for (int i = 1; i < BodyParts.Count; i++)
        {
            currentBodyPart = BodyParts.Count[i];
            previousBodyPart = BodyParts[i-1];

            distance = Vector3.Distance(previousBodyPart.position, currentBodyPart.rotation);
            Vector3 newpos = previousBodyPart.position;

            newpos.y = BodyParts[0].position.y;

            float T = Time.deltaTime * dis /mindistance * currentSpeed;

            if (T > 0.5f)
            {
                T= 0.5f;
            }
            currentBodyPart.position = Vector3.Slerp(currentBodyPart.position, newpos, T);
             currentBodyPart.rotation = Vector3.Slerp(currentBodyPart.rotation, previousBodyPart.rotation, T);

        }
    }

    public void AddBodyPart() 
    {
        Transform newpart = (Instantiate(bodyprefab, BodyParts[BodyParts.Count - 1].position,
         BodyParts[BodyParts.Count - 1].rotation) as GameObject);

        newpart.SetParent(Transform);
        BodyParts.Add(newpart);
    }
}