using Capitals.Core.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Capitals.UnitTest
{
    public class CapitalTests
    {

        [Fact]
        public void CreateCapital()
        {
            var capital = new Capital(1,"Madrid");

            capital.Name.Should().Be("Madrid");
        }

        [Fact]
        public void CreateCapitalNullName()
        {
            Assert.Throws<ArgumentNullException>(() => new Capital(1,null));
        }

        [Fact]
        public void CreateCapitalEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new Capital(1, string.Empty));
        }
    }
}
