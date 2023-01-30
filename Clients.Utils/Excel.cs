using Clients.Core.Entities;
using Clients.Core.Interfaces;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Clients.Utils
{
    public class Excel :IExcel
    {        
        public string CreateExcel(List<Bill> lst)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("Datos");
            IRow row = sheet1.CreateRow(0);

            row.CreateCell(0).SetCellValue("Razón");
            row.CreateCell(1).SetCellValue("RFC");
            row.CreateCell(2).SetCellValue("CURP");
            row.CreateCell(3).SetCellValue("Régimen Físcal");
            row.CreateCell(4).SetCellValue("CFDI");
            row.CreateCell(5).SetCellValue("Método de Pago");
            row.CreateCell(6).SetCellValue("Fecha de Pago");
            row.CreateCell(7).SetCellValue("Monto");
            row.CreateCell(8).SetCellValue("Nombre");
            row.CreateCell(9).SetCellValue("Apellido Paterno");
            row.CreateCell(10).SetCellValue("Apellido Materno");
            row.CreateCell(11).SetCellValue("Teléfono");
            row.CreateCell(12).SetCellValue("Correo");
            row.CreateCell(13).SetCellValue("Calle");
            row.CreateCell(14).SetCellValue("Número");
            row.CreateCell(15).SetCellValue("Colonia");
            row.CreateCell(16).SetCellValue("Estado");
            row.CreateCell(17).SetCellValue("C.P");
            row.CreateCell(18).SetCellValue("Fecha");

            int cont = 1;
            foreach(var client in lst)
            {
                row = sheet1.CreateRow(cont);
                row.CreateCell(0).SetCellValue(client.Reason);
                row.CreateCell(1).SetCellValue(client.RFC);
                row.CreateCell(2).SetCellValue(client.CURP);
                row.CreateCell(3).SetCellValue(client.TaxRegime);
                row.CreateCell(4).SetCellValue(client.CFDI);
                row.CreateCell(5).SetCellValue(client.PaymentMethod);
                row.CreateCell(6).SetCellValue(client.PaymentDate);
                row.CreateCell(7).SetCellValue(client.Amount.ToString());
                row.CreateCell(8).SetCellValue(client.Name);
                row.CreateCell(9).SetCellValue(client.FirstLastName);
                row.CreateCell(10).SetCellValue(client.SecondLastName);
                row.CreateCell(11).SetCellValue(client.Phone);
                row.CreateCell(12).SetCellValue(client.Email);
                row.CreateCell(13).SetCellValue(client.Street);
                row.CreateCell(14).SetCellValue(client.Number);
                row.CreateCell(15).SetCellValue(client.Sector);
                row.CreateCell(16).SetCellValue(client.State);
                row.CreateCell(17).SetCellValue(client.CP);
                row.CreateCell(18).SetCellValue(client.Created.ToString("yyyy-MM-dd"));
                cont++;
            }
            var fileName = $"Datos {DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")} factura.xlsx";
            FileStream sw = File.Create(fileName);
            workbook.Write(sw, false);
            sw.Close();
            return fileName;
        }       
    }
}
