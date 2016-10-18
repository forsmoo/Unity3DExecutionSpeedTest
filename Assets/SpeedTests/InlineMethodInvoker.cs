using UnityEngine;
using System.Collections;

namespace SpeedTest
{
    public class InlineMethodInvoker : MonoBehaviour
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
                    index = i + 1;
                }
            }

            if (config.TestClass)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    outClass.currentIndex = inClass.currentIndex +1;
                }
            }

            if (config.TestStruct)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    output.currentIndex = input.currentIndex + 1;
                }
            }
        }
    }
}