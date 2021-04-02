using System;
using System.Collections;
using System.Collections.Generic;
using AppsuTest;
using UnityEngine;

namespace AppsuTest
{
    public class AppsuTestApplication : MonoBehaviour
    {
        public AppsuTestModel model;
        public AppsuTestView view;
        public AppsuTestController controller;
    }
    public class ApplicationElement : MonoBehaviour
    {
        // Gives access to the application and all instances.
        protected AppsuTestApplication app;
      

        
        protected virtual void Awake()
        {
            app = FindObjectOfType<AppsuTestApplication>(); 
        }


    }
    
}
