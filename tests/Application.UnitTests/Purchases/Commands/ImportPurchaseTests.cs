using Moq;
using PrepayPower.Application.Common.Interfaces;
using PrepayPower.Application.Purchases.Commands;
using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.UnitTests.Purchases.Commands;

public class ImportPurchaseTests
{
    [Test]
    public async Task ImportPurchaseCommand_Added2Vegetables_ContextCalled2Times()
    {
        //Arrange
        var fileReader = new Mock<IPurchaseElementsFileReader>();
        fileReader.Setup(x => x.Read(It.IsAny<string>())).Returns(new List<(string, int)>
        {
            ("Tomato", 2),
            ("Corn", 3)
        });
        var persistenceContext = new Mock<IPersistenceContext>();
        persistenceContext.Setup(x => x.Vegetables).Returns(new List<Vegetable>
        {
            new("Tomato", 1),
            new("Corn", 4),
        });
        var command = new ImportPurchaseCommand("");
        var handler = new ImportPurchaseCommandHandler(fileReader.Object, persistenceContext.Object);
        
        //Act
        await handler.Handle(command, new CancellationToken());

        //Assert
        fileReader.Verify(x => x.Read(""),Times.Once);
        persistenceContext.Verify(x => x.Vegetables,Times.Exactly(2));
    }
}