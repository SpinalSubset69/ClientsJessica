using AutoMapper;
using Clients.Core.Entities;
using Clients.Core.Interfaces.Repositories;
using Clients.Dtos.BillsDtos;

namespace Clients.Services
{
    public class BillsService
    {
        private readonly IBillRepository _billsRepo;
        private readonly IMapper _mapper;

        public BillsService(IBillRepository billsRepo, IMapper mapper)
        {
            _billsRepo = billsRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BillsDto>> GetAllBillsAsync()
        {
            var bills = await _billsRepo.GetAllAsync();
            return _mapper.Map<List<Bill>, List<BillsDto>>(bills.ToList());
        }
        
        public async Task AddBill(CreateBillsDto bill)
        {
            _billsRepo.AddElement(_mapper.Map<CreateBillsDto, Bill>(bill));
            await _billsRepo.SaveChangesAsync();
        }        
    }
}
