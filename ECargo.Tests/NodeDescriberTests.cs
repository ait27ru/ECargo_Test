using System;
using ECargo.Describer;
using ECargo.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECargo.Tests
{
    [TestClass]
    public class NodeDescriberTests
    {
        private INodeDescriber _nodeDescriber;

        [TestInitialize]
        public void Initialize()
        {
            _nodeDescriber = new NodeDescriber();
        }

        [TestMethod]
        public void NoChildrenNode_Describe()
        {
            //Arrange
            var testData = new NoChildrenNode("root");
            var expected = @"new NoChildrenNode(""root"")";

            //Act
            var actual = _nodeDescriber.Describe(testData);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleChildNode_Describe()
        {
            //Arrange
            var testData = new SingleChildNode("root",
                new NoChildrenNode("child"));

            var expected = @"new SingleChildNode(""root""," + Environment.NewLine +
                           @"    new NoChildrenNode(""child""))";

            //Act
            var actual = _nodeDescriber.Describe(testData);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoChildrenNode_Describe()
        {
            //Arrange
            var testData = new TwoChildrenNode("root",
                new NoChildrenNode("child1"),
                new NoChildrenNode("child2"));

            var expected = @"new TwoChildrenNode(""root""," + Environment.NewLine +
                           @"    new NoChildrenNode(""child1"")," + Environment.NewLine +
                           @"    new NoChildrenNode(""child2""))";

            //Act
            var actual = _nodeDescriber.Describe(testData);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ManyChildrenNode_Describe()
        {
            //Arrange
            var testData = new ManyChildrenNode("root",
                new NoChildrenNode("child1"),
                new NoChildrenNode("child2"),
                new NoChildrenNode("child3"));

            var expected = @"new ManyChildrenNode(""root""," + Environment.NewLine +
                           @"    new NoChildrenNode(""child1"")," + Environment.NewLine +
                           @"    new NoChildrenNode(""child2"")," + Environment.NewLine +
                           @"    new NoChildrenNode(""child3""))";

            //Act
            var actual = _nodeDescriber.Describe(testData);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tree_Describe()
        {
            //Arrange
            var testData = new SingleChildNode("root",
                new TwoChildrenNode("child1",
                    new NoChildrenNode("leaf1"),
                    new SingleChildNode("child2",
                        new NoChildrenNode("leaf2"))));

            var expected = @"new SingleChildNode(""root""," + Environment.NewLine +
                           @"    new TwoChildrenNode(""child1""," + Environment.NewLine +
                           @"        new NoChildrenNode(""leaf1"")," + Environment.NewLine +
                           @"        new SingleChildNode(""child2""," + Environment.NewLine +
                           @"            new NoChildrenNode(""leaf2""))))";

            //Act
            var actual = _nodeDescriber.Describe(testData);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}