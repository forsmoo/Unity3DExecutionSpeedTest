using UnityEngine;
using System.Collections;

namespace SpeedTest
{
    public class Speedconfig : MonoBehaviour
    {
        public int NumCalls=5000;
        public bool TestMethod = true;
        public bool TestClass = true;
        public bool TestStruct = true;
    }
    
    public class InputClass
    {
        public int currentIndex;
        public int CurrentIndex { get; set; }
    }

    public class OutputClass
    {
        public int currentIndex;
        public int CurrentIndex { get; set; }
    }

    public struct InputStruct
    {
        public int currentIndex;
        public int CurrentIndex { get; set; }
    }

    public struct OutputStruct
    {
        public int currentIndex;
        public int CurrentIndex { get; set; }
    }


}
