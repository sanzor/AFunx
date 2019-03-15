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

            MethodInfo method = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) });
            var expr = MakeExpression();
            expr(5);
        }
        public static  Func<int,int> MakeExpression() {
            //input
            var i = Expression.Parameter(typeof(int), "i");
            var cnt = Expression.Variable(typeof(int), "cnt");
            var sum = Expression.Variable(typeof(int), "sum");

            var writeLine = typeof(Console).GetMethod("WriteLine", new[] { typeof(object) });

            var breakLabel = Expression.Label("break");
            var loop = Expression.Loop(
                Expression.Block(
                    Expression.IfThen(
                        Expression.GreaterThanOrEqual(cnt, i),
                        Expression.Block(
                            Expression.Call(writeLine, Expression.Convert(sum, typeof(object))),
                            Expression.Break(breakLabel))),
                    Expression.AddAssign(sum, cnt),
                    Expression.PostIncrementAssign(cnt)),breakLabel);
            var block = Expression.Block(new[] { cnt, sum },
                Expression.Assign(cnt, Expression.Constant(0)),
                Expression.Assign(sum, Expression.Constant(0)),
                loop,
                sum);
            
            var meth = Expression.Lambda<Func<int, int>>(block,new[] { i }).Compile();
            return meth;
        }
       
        public static int Print(int i) {
            int cnt = 0;
            int sum = 0;
            while (true) {
                if (cnt >= i) {
                    Console.WriteLine(sum);
                    break;
                }
                sum = sum + 1;

            }
            return sum;
        }
    }
}
