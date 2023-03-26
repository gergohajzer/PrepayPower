using MediatR;
using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.Purchases.Commands;

/// <summary>
/// Applies all the offers/discounts on a purchase that meet the conditions.
/// </summary>
/// <param name="Offers">List of offers.</param>
/// <param name="Purchase">A purchase.</param>
public record ApplyOffersOnPurchaseCommand(IList<Offer> Offers, Purchase Purchase) : IRequest;

public class ApplyOffersOnPurchaseCommandHandler : IRequestHandler<ApplyOffersOnPurchaseCommand>
{
    public Task Handle(ApplyOffersOnPurchaseCommand request, CancellationToken cancellationToken)
    {
        foreach (var offer in request.Offers)
        {
            var discount = offer.CalculateDiscount(request.Purchase);
            if (discount > 0)
            {
                request.Purchase.AppliedOffers.Add(new PurchaseOffer(offer.PromoCode, offer.Description, discount));
            }
        }
        
        return Task.CompletedTask;
    }
}