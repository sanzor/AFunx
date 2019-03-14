using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Weights;
using System.Linq;
using Extensions;

namespace WeightTests {
    class InitializeTests {
        
        
        [TestCase(Category ="Init")]
        public void CanExtractWeightsOfObject(string Name,double Value) {
            WeightUser user = new WeightUser();
            var weights = user.Extract();
            bool isTrue = weights[0].Name == Name && weights[0].Value == Value;
            Assert.IsTrue(isTrue);
        }
        [TestCase(Category ="Init")]
        public void CanExtractFromForeignAssembly() {
            Athlete athelete = new Athlete() {Name="Jon", Activity = new Run { Distance = 44 } };
            var data=athelete.Activity.Extract();

        }

    }
}
