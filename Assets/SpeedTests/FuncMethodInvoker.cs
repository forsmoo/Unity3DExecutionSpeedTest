using UnityEngine;
using System.Collections;
using System;

namespace SpeedTest
{
    public class FuncMethodInvoker : MonoBehaviour
    {
        public Speedconfig config;
        Func<int,int> func;
        Func<InputClass,OutputClass, bool> funcClass;
        Func<InputStruct, OutputStruct> funcStruct;

        void Awake()
        {
            config = GetComponent<Speedconfig>();
            func = _ => { int j=0;j++;return j; };
            funcClass = (x,y) => {
                y.currentIndex = x.currentIndex + 1;
                return true;
            };
            funcStruct = (input) => {
                OutputStruct output = default(OutputStruct);
                output.currentIndex = input.currentIndex + 1;
                return output;
            };
        }

        int index;
        InputStruct input = new InputStruct();
        OutputStruct output;
        InputClass inClass = new InputClass();
        OutputClass outClass = new OutputClass();
        void Update()
        {
            if (config.TestMethod)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    index = func(i);
                }
            }

            if (config.TestClass)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    funcClass(inClass, outClass);
                }
            }

            if (config.TestStruct)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    output = funcStruct(input);
                }
            }
        }
    }
}