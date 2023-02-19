using AutoMapper;
using Clients.Core.Entities;
using Clients.Core.Interfaces;
using Clients.Core.Interfaces.Repositories;
using Clients.Dtos.BillsDtos;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace Clients.Services
{
    public class BillsService
    {
        private readonly IBillRepository _billsRepo;
        private readonly IMapper _mapper;
        private readonly IEmail _email;
        private readonly IExcel _excel;
        private readonly IWebHostEnvironment _host;
        private readonly IMailRepository _mailsRepo;

        public BillsService(IBillRepository billsRepo, IMapper mapper, IEmail email, IExcel excel, IWebHostEnvironment host, IMailRepository mailsRepo)
        {
            _billsRepo = billsRepo;
            _mapper = mapper;
            _email = email;
            _excel = excel;
            _host = host;
            _mailsRepo = mailsRepo;
        }

        public async Task AddBill(CreateBillsDto bill)
        {
            _billsRepo.AddElement(_mapper.Map<CreateBillsDto, Bill>(bill));
            await _billsRepo.SaveChangesAsync();
        }
        
        public async Task SendNotification()
        {
            var yesterday = DateTime.Now.AddDays(-1);
            var lst = await _billsRepo.GetElementAsync(x => x.Created.Year == yesterday.Year && x.Created.Month == yesterday.Month && x.Created.Date == yesterday.Date);
            var fileName = _excel.CreateExcel(lst.ToList());                        
            var pplToSend = await _mailsRepo.GetAllAsync();
            var emails = pplToSend.Select(x => x.Email).ToList();
            await _email.SendEmail("alastorlml@gmail.com", emails, fileName, _host.ContentRootPath);            
        }

        public async Task<PersonalDataDTO?> GetPersonalDataByRFCAsync(string RFC)
        {
            var billData = await _billsRepo.GetByRFCAsync(RFC);
            if (billData == null) return null;
            return _mapper.Map<Bill, PersonalDataDTO>(billData);
        }

        public async Task<IEnumerable<BillsDto>> GetAllBillsAsync()
        {
            var bills = await _billsRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<Bill>, List<BillsDto>>(bills);
        }

        public bool ValidateAccess(string password, string passwordFromFront) => String.Equals(password, passwordFromFront);
    }
}
