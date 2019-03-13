using System;
using System.Reflection;
using System.Linq;
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
            var c = nameof(Attr.S);
            AttrUser user = new AttrUser();
            var type = user.GetType();
            var values = (from prop in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                        select prop.GetCustomAttribute<Attr>().Val).ToArray();
                       
                       

        }
    }
}
