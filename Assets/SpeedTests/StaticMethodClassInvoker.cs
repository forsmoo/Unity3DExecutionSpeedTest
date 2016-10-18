using UnityEngine;
using System.Collections;

namespace SpeedTest
{ 
    public class StaticMethodClassInvoker : MonoBehaviour {
	
        public Speedconfig config;
        void Awake()
        {
            config = GetComponent<Speedconfig>();
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
                    index = StaticMethods.Method(i);
                }
            }

            if (config.TestClass)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    StaticMethods.MethodClass(inClass, outClass);
                }
            }

            if (config.TestStruct)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    output = StaticMethods.MethodStruct(input);
                }
            }
            
        }
    }

    public static class StaticMethods
    {
        public static int Method(int i)
        {
            i++;
            return i;
        }

        public static bool MethodClass(InputClass input, OutputClass output)
        {
            output.currentIndex = input.currentIndex+1;
            return true;
        }

        public static OutputStruct MethodStruct(InputStruct input)
        {
            OutputStruct output = default(OutputStruct);
            output.currentIndex = input.currentIndex + 1;
            return output;
        }
    }
}
