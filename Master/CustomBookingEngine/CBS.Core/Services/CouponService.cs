using CBS.Entity.Domain;
using CSE.Interfaces.IUnitOfWork;
using CSE.Service.Generics;
using CSE.Interfaces.IRepository;


public class CouponService : GenericService<Coupon, int>, ICouponService
{
    private readonly IRepository<Coupon, int> _couponRepository;

    public CouponService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _couponRepository = unitOfWork.Repository<Coupon, int>();
    }

    public Coupon SearchCoupon(string couponCode)
    {
        return _couponRepository.Get().FirstOrDefault(c => c.CouponCode == couponCode && !c.IsDeleted && DateTime.Now < c.EndDate && c.Remain > 0);
    }
}