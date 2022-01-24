using Moq;
using Parsers.Library.Global;
using SaaSCLI.Commands.Commands.Import;
using SaaSCLI.Infrastructure.Entities;
using SaaSCLI.Infrastructure.MySQL;
using SaaSCLI.Infrastructure.Repository;
using System;

namespace SaaSCLI.Commands.UnitTests.Commands.Import
{
	internal partial class ImportCommandTests
	{
		public TestContext Context = new();
		public class TestContext
		{
			public ImportCommand BuildSut()
			{
				var dummyContextMock = ConfigureContext();

				var parserMock = ConfigureParser();

				return new ImportCommand(parserMock.Object, dummyContextMock.Object);

				Mock<IDummyContext> ConfigureContext()
				{
					var dummyContext = new Mock<IDummyContext>();
					var feedProductRepo = new Mock<IRepository<FeedProduct>>();
					feedProductRepo.Setup(x => x.Add(It.IsAny<FeedProduct>()));
					dummyContext.Setup(x => x.FeedProductRepo).Returns(feedProductRepo.Object);

					return dummyContext;
				}

				Mock<IGlobalParser> ConfigureParser()
				{
					var parserMock = new Mock<IGlobalParser>();
					object result;
					parserMock.Setup(x => x.TryParse(It.IsAny<string>(), It.IsAny<Type>(), out result, It.IsAny<Func<string, string>>()))
						.Returns(true).Callback((string a, Type p, out object c, Func<string, string> func) =>
						{
							c = new FeedProduct()
							{
								Categories = new []{"Test"}
							};
						});
					return parserMock;
				}
			}
		}
	}
}
