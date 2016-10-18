using UnityEngine;
using System.Collections;

namespace SpeedTest
{
    public class UnsealedClassMethodInvoker : MonoBehaviour
    {
        public Speedconfig config;
        SimpleClass impl;
        InputStruct input = new InputStruct();
        OutputStruct output;
        InputClass inClass = new InputClass();
        OutputClass outClass = new OutputClass();
        void Awake()
        {
            config = GetComponent<Speedconfig>();
            impl = new SimpleClass();
        }
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
    
    public class SimpleClass
    {
        public int Method(int i)
        {
            i++;
            return i;
        }

        public bool MethodClass(InputClass input, OutputClass output)
        {
            output.currentIndex = input.currentIndex+1;
            return true;
        }

        public OutputStruct MethodStruct(InputStruct input)
        {
            OutputStruct output = default(OutputStruct);
            output.currentIndex = input.currentIndex + 1;
            return output;
        }
    }
}