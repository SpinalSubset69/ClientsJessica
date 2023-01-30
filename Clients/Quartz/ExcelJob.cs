using Clients.Services;
using Quartz;

namespace Clients.Quartz
{
    public class ExcelJob : IJob
    {
        private readonly BillsService _billsService;

        public ExcelJob(BillsService billsService)
        {
            _billsService = billsService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _billsService.SendNotification();            
        }
    }
}
