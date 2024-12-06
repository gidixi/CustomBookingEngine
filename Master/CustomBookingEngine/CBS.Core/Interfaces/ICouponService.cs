using CBS.Entity.Domain;
using CSE.Interfaces.IServices;

public interface ICouponService : IGenericService<Coupon, int>
{
    Coupon SearchCoupon(string couponCode);
}