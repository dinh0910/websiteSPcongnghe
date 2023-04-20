using Microsoft.AspNetCore.Mvc;
using websiteSPcongnghe.Data;

namespace websiteSPcongnghe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaocaosController : Controller
    {
        private readonly websiteSPcongngheContext _context;

        public BaocaosController(websiteSPcongngheContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? month = 0)
        {
            if (month == 0)
            {
                month = DateTime.Today.Month;
            }
            var firstDayOfMonth = new DateTime(DateTime.Today.Year, (int)month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var listHoaDon = _context.Dondathang.Where(x => x.Ngaylap >= firstDayOfMonth && x.Ngaylap <= lastDayOfMonth);
            ViewData["month"] = month;
            var listdoanhthu = new List<int?>();
            for (int i = 1; i <= lastDayOfMonth.Day; i++)
            {
                var doanhthu = listHoaDon.Where(x => x.Ngaylap.Day == i && x.Tongtien != null);
                var tongtien = 0;

                if (doanhthu != null)
                {
                    foreach (var x in doanhthu)
                    {
                        tongtien += x.Tongtien;
                    }
                    listdoanhthu.Add(tongtien);
                }
                else
                {
                    listdoanhthu.Add(0);
                }
            }
            ViewData["doanhthu"] = listdoanhthu;

            var listdoanhthuthang = new List<int?>();
            var dondathang = _context.Dondathang.Where(x => x.Ngaylap.Month >= 1 && x.Ngaylap.Month <= 12);
            for (int i = 1; i <= 12; i++)
            {
                var doanhthu = dondathang.Where(x => x.Ngaylap.Month == i && x.Tongtien != null);
                var tongtien = 0;

                if (doanhthu != null)
                {
                    foreach (var x in doanhthu)
                    {
                        tongtien += x.Tongtien;
                    }
                    listdoanhthuthang.Add(tongtien);
                }
                else
                {
                    listdoanhthuthang.Add(0);
                }
            }
            ViewData["doanhthuthang"] = listdoanhthuthang;

            return View();
        }
    }
}
