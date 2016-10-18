using UnityEngine;
using System.Collections;

namespace SpeedTest
{

    public class InterfaceMethodInvoker : MonoBehaviour
    {
        public Speedconfig config;
        ITestClass impl;
        void Awake()
        {
            config = GetComponent<Speedconfig>();
            impl = new Impl();
        }
        int index = 0;
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


    public interface ITestClass
    {
        int Method(int i);
        bool MethodClass(InputClass input, OutputClass output);
        OutputStruct MethodStruct(InputStruct input);
    }

    public class Impl : ITestClass
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