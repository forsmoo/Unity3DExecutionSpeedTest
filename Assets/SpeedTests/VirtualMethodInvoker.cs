using UnityEngine;
using System.Collections;

namespace SpeedTest
{
    public class VirtualMethodInvoker : MonoBehaviour
    {
        public Speedconfig config;
        AbstractTestClass inst;
        InputStruct input = new InputStruct();
        OutputStruct output;
        InputClass inClass = new InputClass();
        OutputClass outClass = new OutputClass();
        void Awake()
        {
            config = GetComponent<Speedconfig>();
            inst = new AbstractImpl();
        }
        int index;
        void Update()
        {
            if (config.TestMethod)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    index = inst.Method(i);
                }
            }

            if (config.TestClass)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    inst.MethodClass(inClass, outClass);
                }
            }

            if (config.TestStruct)
            {
                for (int i = 0; i < config.NumCalls; i++)
                {
                    output = inst.MethodStruct(input);
                }
            }
        }
    }

    public abstract class AbstractTestClass
    {
        public virtual int Method(int i) { return 0; }
        public virtual bool MethodClass(InputClass input, OutputClass output) { return false; }
        public virtual OutputStruct MethodStruct(InputStruct input) { return default(OutputStruct); }
    }

    public class AbstractImpl : AbstractTestClass
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
