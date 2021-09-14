
using AutoFixture.Xunit2;
using Xunit.Sdk;

namespace TestUtilities {
    public class InlineAutoMoqDataAttribute : InlineAutoDataAttribute
    {
        public InlineAutoMoqDataAttribute(params object[] arguments)
            : base((DataAttribute) new AutoMoqDataAttribute(), arguments)
        {
        }
    }
}