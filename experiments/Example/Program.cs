using System;
using System.Reflection;
using System.Linq;
using Weights;
using Extensions;
using System.Linq.Expressions;
using System.Collections.Generic;

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
            // Athlete ath = new Athlete() { Activity = new Run { Distance = 33.3 } };

           
            Run[] act = new Run[] { new Run() { Distance=33}, new Run() { Distance=44} };
            Run a = act[0];
            List<Expression> products = new List<Expression>();
            
            ParameterExpression parameter = Expression.Parameter(typeof(Activity));
            ConstantExpression ct = Expression.Constant(a);
            Expression variable = Expression.Variable(typeof(double));
            Expression assign = Expression.Assign(variable, Expression.Constant(0));
            foreach (var item in ExpTree.propMap) {
                Expression right = Expression.Property(ct, item.Key);
                Expression left = Expression.Constant(item.Value);
                Expression mult = Expression.Multiply(left, right);
                Expression s = Expression.Add(variable, mult);
                Expression assign=Expression.Assign(variable)
            }
           
            Expression sum=Expression.Loop()

             
            //ExpTree.GetProduct();
                       
                       

        }
    }
}
