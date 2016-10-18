using UnityEngine;
using System.Collections;

namespace SpeedTest
{
    public delegate int MethodHandler(int i);
    public delegate bool MethodHandlerClass(InputClass input,OutputClass output);
    public delegate OutputStruct MethodHandlerStruct(InputStruct input);

    public class DelegateMethodInvoker : MonoBehaviour
    {
        public Speedconfig config;
        MethodHandler delegateHandler;
        MethodHandlerClass delegateHandlerClass;
        MethodHandlerStruct delegateHandlerStruct;

        void Awake()
        {
            config = GetComponent<Speedconfig>();
            delegateHandler = new MethodHandler(DelegateImpl.Method);
            delegateHandlerClass = new MethodHandlerClass(DelegateImpl.MethodClass);
            delegateHandlerStruct = new MethodHandlerStruct(DelegateImpl.MethodStruct);
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
                    index = delegateHandler(i);
                }
            }

            if (config.TestClass)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    delegateHandlerClass(inClass,outClass);
                }
            }

            if (config.TestStruct)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    output = delegateHandlerStruct(input);
                }
            }
        }    
    }

    public static class DelegateImpl
    {
        static int i = 0;
        internal static int Method(int i)
        {
            i++;
            return i;
        }

        internal static bool MethodClass(InputClass input,OutputClass output)
        {
            output.currentIndex = input.currentIndex+1;
            return true;
        }

        internal static OutputStruct MethodStruct(InputStruct input)
        {
            OutputStruct output=default(OutputStruct);
            output.currentIndex = input.currentIndex + 1;
            return output;
        }
    }
}
