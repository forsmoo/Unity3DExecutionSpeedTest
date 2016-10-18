using System;
using UnityEngine;
using System.Collections;
using System.Reflection;

namespace SpeedTest
{
    public class ReflectedMethodInvoker : MonoBehaviour
    {
        public Speedconfig config;
        SimpleClass impl;
        MethodInfo method;
        MethodInfo methodClass;
        MethodInfo methodStruct;

        void Awake()
        {
            config = GetComponent<Speedconfig>();

            impl = new SimpleClass();
            method = impl.GetType().GetMethod("Method");
            methodClass = impl.GetType().GetMethod("MethodClass");
            methodStruct = impl.GetType().GetMethod("MethodStruct");
            paramsMethod = new object[1];
            paramsClass = new object[2];
            paramsStruct = new object[1];
        }
        object[] paramsMethod;
        object[] paramsClass;
        object[] paramsStruct;
        InputStruct input = new InputStruct();
        OutputStruct output;
        InputClass inClass = new InputClass();
        OutputClass outClass = new OutputClass();
        int index;
        void Update()
        {
            if (config.TestMethod)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    paramsMethod[0] = i; 
                    index += (int)method.Invoke(impl,paramsMethod);
                }
            }

            if (config.TestClass)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    paramsClass[0] = inClass;
                    paramsClass[1] = outClass;
                    methodClass.Invoke(impl, paramsClass);
                }
            }

            if (config.TestStruct)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    paramsStruct[0] = input;
                    output = (OutputStruct)methodStruct.Invoke(impl, paramsStruct);
                }
            }
        }
    }

}