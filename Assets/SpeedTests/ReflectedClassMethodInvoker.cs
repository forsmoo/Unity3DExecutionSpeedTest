using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Reflection;

namespace SpeedTest
{

    public class ReflectedClassMethodInvoker : MonoBehaviour
    {
        public Speedconfig config;
        SimpleClass impl;
        
        void Awake()
        {
            config = GetComponent<Speedconfig>();
            var type = Assembly.GetCallingAssembly().GetType("SpeedTest.SimpleClass");
            impl = Activator.CreateInstance(type) as SimpleClass;
        }

        InputStruct input = new InputStruct();
        OutputStruct output;
        InputClass inClass = new InputClass();
        OutputClass outClass = new OutputClass();
        
        int index = 0;
        void Update()
        {
            if (config.TestMethod)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    index = impl.Method(i);
                }
            }

            if (config.TestClass)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    impl.MethodClass(inClass, outClass);
                }
            }

            if (config.TestStruct)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    output = impl.MethodStruct(input);
                }
            }

        }
    }

}