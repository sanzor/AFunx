using System;
using System.Collections.Generic;
using System.Text;
using Weights;
using System.Reflection;
using System.Linq;

namespace WeightTests {
    static class Ext {

        public static IReadOnlyList<Weight> Extract(this object o) {
            var type = o.GetType();
            var weights = ExtractWeights(type);
            return weights;

        }
        public static IReadOnlyList<Weight> Extract<T>(this T o) {
            var type = typeof(T);
            var weights = ExtractWeights(type);
            return weights;

        }
        private static IReadOnlyList<Weight> ExtractWeights(Type type) {
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            var weights = properties.Select(x => x.GetCustomAttribute<WeightAttribute>().Weight).ToArray();
            return weights;
        }

    }
}
