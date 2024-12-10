using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public Task DeleteDiscountCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            throw new NotImplementedException();
        }
    }
}
