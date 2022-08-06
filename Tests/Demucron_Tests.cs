using NUnit.Framework;
using Otus.GraphsSortings.Demucron.Logic;

namespace Tests
{
    public class Demucron_Tests
    {
        [Test]
        public void Can_Get_Result()
        {
            var adjacencyMatrix = new int[,]
            {
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            var result = new DemucronAlgorithm().Run(adjacencyMatrix);
            
            Assert.That(result[0], Is.EqualTo(new []{ 4, 7 }));
            Assert.That(result[1], Is.EqualTo(new []{ 1, 8, 9 }));
            Assert.That(result[2], Is.EqualTo(new []{ 0, 6, 13 }));
            Assert.That(result[3], Is.EqualTo(new []{ 5 }));
            Assert.That(result[4], Is.EqualTo(new []{ 3, 10, 11, 12 }));
            Assert.That(result[5], Is.EqualTo(new []{ 2 }));
        }
    }
}