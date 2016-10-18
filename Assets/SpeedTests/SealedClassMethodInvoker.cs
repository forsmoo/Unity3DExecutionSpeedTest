using UnityEngine;
using System.Collections;

namespace SpeedTest
{
    public class SealedClassMethodInvoker : MonoBehaviour
    {
        public Speedconfig config;
        AbstractTestClass impl;
        int index = 0;
        InputStruct input = new InputStruct();
        OutputStruct output;
        InputClass inClass = new InputClass();
        OutputClass outClass = new OutputClass();
        void Awake()
        {
            config = GetComponent<Speedconfig>();
            impl = new SealedClass();
        }

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

    internal sealed class SealedClass : AbstractTestClass
    {
        public override int Method(int i)
        {
            i++;
            return i;
        }

        public override bool MethodClass(InputClass input, OutputClass output)
        {
            output.currentIndex = input.currentIndex+1;
            return true;
        }

        public override OutputStruct MethodStruct(InputStruct input)
        {
            OutputStruct output = default(OutputStruct);
            output.currentIndex = input.currentIndex + 1;
            return output;
        }
    }
}