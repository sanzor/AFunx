using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;
using System.Linq;
using Weights;

namespace Extensions {
    public static class Ext {

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
            var properties = type
                .GetProperties(BindingFlags.DeclaredOnly);
                //.Where(x => x.GetCustomAttribute<WeightAttribute>() != null).ToArray() ;
            var weights = properties.Select(x => x.GetCustomAttribute<WeightAttribute>().Weight).ToArray();
            return weights;
        }

    }
}
