using System.Text;
using MediatR;
using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.Purchases.Queries;

/// <summary>
/// Returns a receipt based on a purchase.
/// </summary>
/// <param name="Purchase"></param>
public record GetReceiptForPurchaseCommand(Purchase Purchase) : IRequest<string>;

public class GetReceiptForPurchaseCommandHandler : IRequestHandler<GetReceiptForPurchaseCommand, string>
{
    public Task<string> Handle(GetReceiptForPurchaseCommand request, CancellationToken cancellationToken)
    {
        var sb = new StringBuilder();

        sb.AppendFormat("Receipt {0}", request.Purchase.Date);
        sb.Append(Environment.NewLine);
        
        sb.AppendLine("Products:");
        foreach (var element in request.Purchase.Elements)
        {
            sb.AppendFormat("{0} {1} EUR{2} EUR{3}", element.Quantity, element.Vegetable.Name,
                element.Vegetable.Price, element.Quantity * element.Vegetable.Price);
            sb.Append(Environment.NewLine);
        }

        if (request.Purchase.AppliedOffers.Any())
        {
            sb.AppendLine("Sub-total:");
            sb.AppendFormat("EUR{0}", request.Purchase.SubTotalPrice);
            sb.Append(Environment.NewLine);

            sb.AppendLine("Discounts:");
            foreach (var offer in request.Purchase.AppliedOffers)
            {
                sb.AppendFormat("{0} {1} {2}", offer.PromoCode, offer.Description, -offer.Discount);
                sb.Append(Environment.NewLine);
            }
        }

        sb.AppendLine("Total:");
        sb.AppendFormat("EUR{0}", request.Purchase.TotalPrice);
        
        return Task.FromResult(sb.ToString());
    }
}