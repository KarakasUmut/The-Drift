using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float Traction;

    float dragAmount = 1f;

    public Transform lw, rw;
        
    [SerializeField] float steerAngle;

    Vector3 _rotVec;
    Vector3 _moveVec;
    
    void Start()
    {

    }

    
    void Update()
    {
        _moveVec += transform.forward * speed * Time.deltaTime;
        transform.position += _moveVec * Time.deltaTime;

        _rotVec += new Vector3(0, Input.GetAxis("Horizontal"), 0);

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle* Time.deltaTime * _moveVec.magnitude);

        _moveVec *= dragAmount;
        _moveVec = Vector3.ClampMagnitude(_moveVec,maxSpeed);
        _moveVec=Vector3.Lerp(_moveVec.normalized,transform.forward,Traction*Time.deltaTime)*_moveVec.magnitude;

        _rotVec = Vector3.ClampMagnitude(_rotVec, steerAngle);

        lw.localRotation = Quaternion.Euler(_rotVec);
        rw.localRotation = Quaternion.Euler(_rotVec);
    }
}
