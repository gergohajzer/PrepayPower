using Moq;
using PrepayPower.Application.Common.Interfaces;
using PrepayPower.Application.Vegetables.Commands;

namespace PrepayPower.Application.UnitTests.Vegetables.Commands;

public class ImportVegetablesTests
{
    [Test]
    public async Task ImportVegetableCommand_Added2Vegetables_ContextCalled2Times()
    {
        //Arrange
        var fileReader = new Mock<IVegetablesFileReader>();
        fileReader.Setup(x => x.Read(It.IsAny<string>())).Returns(new List<(string, double)>
        {
            ("Tomato", 2),
            ("Corn", 3)
        });
        var persistenceContext = new Mock<IPersistenceContext>();
        var command = new ImportVegetablesCommand("");
        var handler = new ImportVegetablesCommandHandler(fileReader.Object, persistenceContext.Object);
        
        //Act
        await handler.Handle(command, new CancellationToken());

        //Assert
        fileReader.Verify(x => x.Read(""),Times.Once);
        persistenceContext.Verify(x => x.Vegetables,Times.Exactly(2));
    }
}