using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
   [SerializeField] public FirstPersonController firstPerson;
   private AudioSource audioSource;
   private bool isPlaying = false;

   private void Start()
   {
      audioSource = GetComponent<AudioSource>();
   }

   private void Update()
   {
      IsWalk();
   }

   private void IsWalk()
   {
      if (firstPerson.targetVelocity.x != 0 || firstPerson.targetVelocity.z !=0) 
      {
         if (!isPlaying)
         {
            audioSource.Play();
            isPlaying = true;
         }
      }
      else
      {
         if (isPlaying)
         {
            audioSource.Stop();
            isPlaying = false;
         }
      }
   }
   
   // [SerializeField] public FirstPersonController firstPerson;
   // private AudioSource audioSource;
   //
   //
   // private void Start()
   // {
   //    
   //    audioSource = GetComponent<AudioSource>();
   // }
   //
   // private void Update()
   // {
   //    IsWalk();
   // }
   //
   // private void IsWalk()
   // {
   //    if (firstPerson.isWalking)
   //    {
   //       audioSource.Play();
   //    }
   // }
}
