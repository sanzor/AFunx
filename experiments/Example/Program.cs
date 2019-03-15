using System;
using System.Reflection;
using System.Linq;
using Weights;
using Extensions;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Diagnostics;

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
        public class T {
            public int A { get; set; }
        }
        public static long ExtractNormal(T o) {
            long var = 0;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var = o.A;
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        public static long ExtractReflexion(T o) {
            long v = 0;
            Stopwatch watch = new Stopwatch();
            Type type = o.GetType();
            watch.Start();
           // v=(long)(type.GetProperty("A").GetValue(o);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        public static double ExtractExp(PropertyInfo o,double weight,object ob) {
            
            var rez = (double)o.GetValue(ob) * weight;
            return rez;
        }
        public static Func<PropertyInfo,double,object,double> Extr() {
            var propinfo = Expression.Parameter(typeof(PropertyInfo), "prop");
            var weight = Expression.Parameter(typeof(double), "weight");
            var targetObj = Expression.Parameter(typeof(object), "targetObj");
            var method = typeof(PropertyInfo).GetMethod("GetValue", new[] { typeof(object) });

            BlockExpression block = Expression.Block(new[] { propinfo, weight, targetObj },
                Expression.Multiply(
                    Expression.Convert(
                        Expression.Call(propinfo, method),
                        typeof(double)),
                    weight));
            var m = Expression.Lambda<Func<PropertyInfo,double,object,double>>(block, new[] { propinfo, weight, targetObj }).Compile();
            return m;
        }

        static void Main(string[] args) {
            var c = Extr();
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
