using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        public async Task<IActionResult> Index()
        {
            var sp = _context.Sanpham.Include(s => s.Danhmucs).Include(s => s.Thuonghieus);
            return View(await sp.ToListAsync());
        }
        
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult CheckOrder()
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

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("_TaiKhoanID");
            HttpContext.Session.Remove("_TenDangNhap");
            HttpContext.Session.Remove("_MatKhau");

            return RedirectToAction("Index", "Home");
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

        //public async Task<IActionResult> CheckOrder(string? Sodienthoai)
        //{
        //    var order = _context.Dondathang.Where(d => d.Sdt == Sodienthoai);
        //    ViewBag.ctdh = _context.Dathangchitiet.Include(c => c.Sanpham);
        //    ViewBag.danhmuc = _context.Danhmuc;
        //    return View(order);
        //}

        public const string CARTKEY = "shopcart";

        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        void SaveCartSession(List<CartItem> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString("shopcart", jsoncart);
        }

        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove("shopcart");
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            ViewBag.danhmuc = _context.Danhmuc;
            var product = await _context.Sanpham
                .FirstOrDefaultAsync(m => m.SanphamID == id);
            var cart = GetCartItems();
            var item = cart.Find(p => p.Sanpham.SanphamID == id);
            if (item != null)
            {
                item.Soluong++;
            }
            else
            {
                cart.Add(new CartItem() { Sanpham = product, Soluong = 1 });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public async Task<IActionResult> UpdateItem(int id, int quantity)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.Sanpham.SanphamID == id);
            if (quantity == 0)
            {
                cart.Remove(item);
            }
            item.Soluong = quantity;
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.Sanpham.SanphamID == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public IActionResult ViewCart()
        {
            ViewBag.danhmuc = _context.Danhmuc;

            return View(GetCartItems());
        }

        public IActionResult CheckOut()
        {
            return View(GetCartItems());
        }

        public async Task<IActionResult> CreateBill(string Ten, string SoDienThoai, string DiaChi, string Email, string Ghichu)
        {
            // lưu hóa đơn
            var bill = new Dondathang();
            bill.Ngaylap = DateTime.Now;
            bill.HovaTen = Ten;
            bill.Sdt = SoDienThoai;
            bill.Diachi = DiaChi;
            bill.Email = Email;
            bill.Ghichu = Ghichu;

            _context.Add(bill);
            await _context.SaveChangesAsync();

            var cart = GetCartItems();
            int amount = 0;
            int soLuong = 0;
            //chi tiết hóa đơn
            foreach (var i in cart)
            {
                var b = new Dathangchitiet();
                b.DondathangID = bill.DondathangID;
                b.SanphamID = i.Sanpham.SanphamID;
                b.Dongia = i.Sanpham.Thanhtien;
                b.Soluong = i.Soluong;
                amount = i.Sanpham.Thanhtien * i.Soluong;
                b.Thanhtien = amount;

                var sp = _context.Sanpham.FirstOrDefault(s => s.SanphamID == b.SanphamID);
                sp.Soluong -= i.Soluong;
                bill.Tongtien += amount;
                _context.Add(b);
            }
            await _context.SaveChangesAsync();
            ClearCart();
            return RedirectToAction(nameof(SuccessOrder));
        }

        public IActionResult SuccessOrder()
        {
            ViewBag.danhmuc = _context.Danhmuc;

            return View();
        }

    }
}