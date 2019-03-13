using System;
using System.Reflection;
using System.Linq;
using Weights;
using Extensions;

namespace Example {
    class Program {
        [AttributeUsage(AttributeTargets.Property)]
        class Attr : Attribute {
            public Attr(int Value) {
                this.Val = new Test() { val = 33 };
            }
            public Test Val;
            public const int S = 33;
        }
        public class Test {
            public int val { get; set; }
        }

        class AttrUser {
            [Attr(33)]
            public double Value { get; set; }
        }
        static void Main(string[] args) {
            Athlete ath = new Athlete() { Activity = new Run { Distance = 33.3 } };
            var data=ath.Activity.Extract();
           
                       
                       

        }
    }
}
