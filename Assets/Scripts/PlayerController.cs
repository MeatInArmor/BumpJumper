using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    
    private Rigidbody _rigidbody;
    private Animator _animator;
    private bool _isJumping;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForce;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && _animator.GetBool("isJumping") == false)
        {
            _animator.SetBool("isJumping", true);
            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }

        Vector3 directionVector = new Vector3(-vertical, 0, horizontal);
        if(directionVector.magnitude > Mathf.Abs(0.05f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * _rotationSpeed);
         
        _animator.SetFloat("MoveSpeed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        _rigidbody.velocity = Vector3.ClampMagnitude(directionVector, 1) * _moveSpeed;


    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Floor floor))
        {
            _animator.SetBool("isJumping", false);
        }
    }
}
