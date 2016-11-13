using System.IO;
using System.Threading.Tasks;
using ECargo.Describer;
using ECargo.Interfaces;
using ECargo.Writer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace ECargo.Tests
{
    [TestClass]
    public class NodeWriterTests
    {
        private Container _container;
        private INodeDescriber _describer;
        private INodeWriter _writer;

        [TestInitialize]
        public void Initialize()
        {
            _container = new Container(cf =>
            {
                cf.For<INodeDescriber>().Use<NodeDescriber>();
                cf.For<INodeWriter>().Use<NodeWriter>();
            });

            _describer = _container.GetInstance<INodeDescriber>();
            _writer = _container.GetInstance<INodeWriter>();
        }

        [TestMethod]
        public async Task Tree_Write()
        {
            //Arrange
            var testData = new SingleChildNode("root",
                new TwoChildrenNode("child1",
                    new NoChildrenNode("leaf1"),
                    new SingleChildNode("child2",
                        new NoChildrenNode("leaf2"))));

            var expected = _describer.Describe(testData);
            //Act
            var fileName = Path.GetTempFileName();

            await _writer.WriteToFileAsync(testData, fileName);

            string actual;

            using (var sr = new StreamReader(fileName))
            {
                actual = sr.ReadToEnd();
            }

            File.Delete(fileName);

            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}