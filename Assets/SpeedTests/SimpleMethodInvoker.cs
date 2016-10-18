using UnityEngine;
using System.Collections;

namespace SpeedTest
{
    public class SimpleMethodInvoker : MonoBehaviour
    {
        public Speedconfig config;
        void Awake()
        {
            config = GetComponent<Speedconfig>();
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
                    index = Method(i);
                }
            }

            if (config.TestClass)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    MethodClass(inClass, outClass);
                }
                
            }

            if (config.TestStruct)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    output = MethodStruct(input);
                }
            }    
        }
        
        int Method(int j)
        {
            j++;
            return j;
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