using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float roatationThrust = 100f;
    [SerializeField] AudioClip mainAudio;
    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem rightEngineParticle;
    [SerializeField] ParticleSystem leftEngineParticle;

    Rigidbody rb;
    AudioSource audioSource;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
            RotateRight();
        else
        {
            StopRotating();
        }
    }


    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainAudio);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }    
    void StopThrusting()
    {
        mainEngineParticle.Stop();
        audioSource.Stop();
    }

    void RotateLeft()
    {
        if (!leftEngineParticle.isPlaying)
        {
            leftEngineParticle.Play();
        }
        ApplyRotation(roatationThrust);
    }
    void RotateRight()
    {
        if (!rightEngineParticle.isPlaying)
        {
            rightEngineParticle.Play();
        }
        ApplyRotation(-roatationThrust);
    }
    void StopRotating()
    {
        leftEngineParticle.Stop();
        rightEngineParticle.Stop();
    }
    void ApplyRotation(float roatationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * roatationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
    

    

    
}
