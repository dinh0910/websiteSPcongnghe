using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using websiteSPcongnghe.Data;
using websiteSPcongnghe.Libs;
using websiteSPcongnghe.Models;

namespace websiteSPcongnghe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly websiteSPcongngheContext _context;
        private readonly INotyfService _notifyService;

        public const string SessionTK = "_TaiKhoanID";
        public const string SessionHoten = "_HoTen";
        public const string SessionTenDN = "_TenDangNhap";
        public const string SessionMK = "_MatKhau";
        public const string SessionEmail = "_Email";
        public const string SessionSDT = "_SDT";
        public const string SessionDiaChi = "_DiaChi";

        public HomeController(ILogger<HomeController> logger, websiteSPcongngheContext context, INotyfService notifyService)
        {
            _logger = logger;
            _context = context;
            _notifyService = notifyService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
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
                                                                            && r.QuyenhanID == 3);
                if (taiKhoan == null)
                {
                    _notifyService.Error("Đăng nhập không thành công!");
                }
                else
                {
                    // Đăng ký SESSION
                    HttpContext.Session.SetInt32(SessionTK, (int)taiKhoan.TaikhoanID);
                    HttpContext.Session.SetString(SessionTenDN, taiKhoan.Tendangnhap);
                    HttpContext.Session.SetString(SessionMK, taiKhoan.Matkhau);
                    //HttpContext.Session.SetString(SessionHoten, taiKhoan.HoTen);
                    //HttpContext.Session.SetString(SessionEmail, taiKhoan.Email);
                    //HttpContext.Session.SetString(SessionSDT, taiKhoan.SoDienThoai);
                    //HttpContext.Session.SetString(SessionDiaChi, taiKhoan.DiaChi);

                    _notifyService.Success("Đăng nhập thành công!");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(TaiKhoan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("TaikhoanID,Tendangnhap,Matkhau")] Taikhoan TaiKhoan)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Taikhoan.FirstOrDefault(r => r.Tendangnhap == TaiKhoan.Tendangnhap);
                if (check == null)
                {
                    if (RegexPassword.Validation(TaiKhoan.Matkhau))
                    {
                        TaiKhoan.Matkhau = SHA1.ComputeHash(TaiKhoan.Matkhau);
                        _context.Add(TaiKhoan);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Login", "Home");
                    }
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}