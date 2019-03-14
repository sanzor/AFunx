using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Weights;

namespace Example {
    class Attr : Attribute {
        public Attr(double Weight) {
            this.Weight = Weight;
        }
        public double Weight { get; set; }
    }
    class ExpTree {
        public class A {
            [Attr(33.3)]
            public int Xx { get; set; } = 45;
            [Attr(35.3)]
            public string D { get; set; } = "st";
            [Attr(22.2)]
            public double C { get; set; }
        }
        public static readonly Dictionary<string,double> propMap = (from elem in typeof(Activity)
                                                                   .GetProperties(BindingFlags.DeclaredOnly |
                                                                                  BindingFlags.Instance |
                                                                                  BindingFlags.Public)
                                                                    let attr = elem.GetCustomAttribute<Attr>()
                                                                    where attr != null
                                                                    select new { name=elem.Name,weight=attr.Weight}
                                                                   ).ToDictionary(x=>x.name,x=>x.weight);
        public static void GetProduct() {
            A a = new A();
            ComputeExpression(a);
        }
        public static double GetMedian(IEnumerable<double>v1,IEnumerable<double>v2) {
            var a=Enumerable.Zip(v1, v2, (x, y) => x * y).Sum() / v1.Count();
            return a;
        }
        public static Func<A,double> ComputeExpression(A a) {
            Expression cst= Expression.Constant(a);
            Expression param = Expression.Parameter(typeof(A));
            Expression[] properties = (from p in propMap
                                       select Expression.Property(param, p.Key)).ToArray();

            Expression variable = Expression.Variable(typeof(int));
            Expression count = Expression.Constant(properties.Length);
           
           // Expression blk=Expression.Block()
            
         
            
            //Expression isEqual=Expression.LessThan()
            // Expression count = Expression.Constant(propMap.Count);

            return null;
        }
    }
}
