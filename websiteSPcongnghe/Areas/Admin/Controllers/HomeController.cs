using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using websiteSPcongnghe.Data;
using websiteSPcongnghe.Libs;
using websiteSPcongnghe.Models;

namespace websiteSPcongnghe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly websiteSPcongngheContext _context;
        private readonly INotyfService _notifyService;

        public const string SessionTKAdmin = "_IDadmin";
        public const string SessionHoten = "_HoTenAdmin";
        public const string SessionTenDN = "_TenTKAdmin";
        public const string SessionEmail = "_EmailAdmin";
        public const string SessionSDT = "_SDTAdmin";
        public const string SessionDiaChi = "_DiaChiAdmin";
        public const string SessionQuyen = "_QuyenID";

        public HomeController(ILogger<HomeController> logger, websiteSPcongngheContext context, INotyfService notyfService)
        {
            _logger = logger;
            _context = context;
            _notifyService = notyfService;
        }

        [Route("/admin/home")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Route("/admin")]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("_IDadmin") == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(TaiKhoanLogin TaiKhoan)
        {
            if (ModelState.IsValid)
            {
                string mahoamatkhau = SHA1.ComputeHash(TaiKhoan.Matkhau);
                var taiKhoan = await _context.Taikhoan.FirstOrDefaultAsync(r => r.Tendangnhap == TaiKhoan.Tendangnhap
                                                                            && r.Matkhau == mahoamatkhau
                                                                            && (r.QuyenhanID == 1 || r.QuyenhanID == 2));

                if (taiKhoan == null)
                {
                    _notifyService.Error("Đăng nhập không thành công!");
                }
                else
                {
                    // Đăng ký SESSION
                    HttpContext.Session.SetInt32(SessionTKAdmin, (int)taiKhoan.TaikhoanID);
                    HttpContext.Session.SetString(SessionTenDN, taiKhoan.Tendangnhap);
                    //HttpContext.Session.SetString(SessionHoten, taiKhoan.HoTen);
                    //HttpContext.Session.SetString(SessionEmail, taiKhoan.Email);
                    //HttpContext.Session.SetString(SessionSDT, taiKhoan.SoDienThoai);
                    //HttpContext.Session.SetString(SessionDiaChi, taiKhoan.DiaChi);
                    _notifyService.Success("Đăng nhập thành công!");
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
