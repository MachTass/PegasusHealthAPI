using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace TestUtilities {
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base((Func<IFixture>) (() => new Fixture().Customize((ICustomization) new AutoMoqCustomization())))
        {
        }
    }
}