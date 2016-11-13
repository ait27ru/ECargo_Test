using ECargo.Interfaces;
using ECargo.Transformer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECargo.Tests
{
    [TestClass]
    public class NodeTransformerTests
    {
        private INodeTransformer _nodeTransformer;

        [TestInitialize]
        public void Initialize()
        {
            _nodeTransformer = new NodeTransformer();
        }

        [TestMethod]
        public void NoChildrenNode_Transform()
        {
            //Arrange
            var testData = new ManyChildrenNode("root");
            var expected = new NoChildrenNode("root");

            //Act
            var actual = _nodeTransformer.Transform(testData);

            //Assert
            Assert.IsInstanceOfType(actual, expected.GetType());
        }

        [TestMethod]
        public void SingleChildNode_Transform()
        {
            //Arrange
            var testData = new ManyChildrenNode("root",
                new ManyChildrenNode("child"));

            var expected = new SingleChildNode("root",
                new NoChildrenNode("child"));

            //Act
            var actual = _nodeTransformer.Transform(testData);

            //Assert
            Assert.IsInstanceOfType(actual, expected.GetType());
        }

        [TestMethod]
        public void TwoChildrenNode_Transform()
        {
            //Arrange
            var testData = new ManyChildrenNode("root",
                new ManyChildrenNode("child1"),
                new ManyChildrenNode("child2"));

            var expected = new TwoChildrenNode("root",
                new NoChildrenNode("child1"),
                new NoChildrenNode("child2"));

            //Act
            var actual = _nodeTransformer.Transform(testData);

            //Assert
            Assert.IsInstanceOfType(actual, expected.GetType());
        }

        [TestMethod]
        public void ManyChildrenNode_Transform()
        {
            //Arrange
            var testData = new ManyChildrenNode("root",
                new ManyChildrenNode("child1"),
                new ManyChildrenNode("child2"),
                new ManyChildrenNode("child3"));

            var expected = new ManyChildrenNode("root",
                new NoChildrenNode("child1"),
                new NoChildrenNode("child2"),
                new NoChildrenNode("child3"));

            //Act
            var actual = _nodeTransformer.Transform(testData);

            //Assert
            Assert.IsInstanceOfType(actual, expected.GetType());
        }

        [TestMethod]
        public void Tree_Transform()
        {
            //Arrange
            var testData = new ManyChildrenNode("root",
                new ManyChildrenNode("child1",
                    new ManyChildrenNode("leaf1"),
                    new ManyChildrenNode("child2",
                        new ManyChildrenNode("leaf2"))));

            var expected = new SingleChildNode("root",
                new TwoChildrenNode("child1",
                    new NoChildrenNode("leaf1"),
                    new SingleChildNode("child2",
                        new NoChildrenNode("leaf2"))));

            //Act
            var actual = _nodeTransformer.Transform(testData);

            //Assert
            Assert.IsInstanceOfType(actual, expected.GetType());
        }
    }
}