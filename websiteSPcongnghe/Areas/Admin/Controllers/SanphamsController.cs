using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using websiteSPcongnghe.Data;
using websiteSPcongnghe.Models;

namespace websiteSPcongnghe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanphamsController : Controller
    {
        private readonly websiteSPcongngheContext _context;

        public SanphamsController(websiteSPcongngheContext context)
        {
            _context = context;
        }

        // GET: Admin/Sanphams
        public async Task<IActionResult> Index()
        {
            var websiteSPcongngheContext = _context.Sanpham.Include(s => s.Danhmucs).Include(s => s.Thuonghieus);
            return View(await websiteSPcongngheContext.ToListAsync());
        }

        // GET: Admin/Sanphams/Create
        public IActionResult Create()
        {
            ViewData["DanhmucID"] = new SelectList(_context.Danhmuc, "DanhmucID", "Tendanhmuc");
            ViewData["ThuonghieuID"] = new SelectList(_context.Thuonghieu, "ThuonghieuID", "Tenthuonghieu");
            return View();
        }

        // POST: Admin/Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("SanphamID,Tensanpham,DanhmucID,ThuonghieuID,Hinhanh,Dongia,Sale,Thanhtien")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                sanpham.Hinhanh = Upload(file);
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhmucID"] = new SelectList(_context.Danhmuc, "DanhmucID", "Tendanhmuc", sanpham.DanhmucID);
            ViewData["ThuonghieuID"] = new SelectList(_context.Thuonghieu, "ThuonghieuID", "Tenthuonghieu", sanpham.ThuonghieuID);
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["DanhmucID"] = new SelectList(_context.Danhmuc, "DanhmucID", "Tendanhmuc", sanpham.DanhmucID);
            ViewData["ThuonghieuID"] = new SelectList(_context.Thuonghieu, "ThuonghieuID", "Tenthuonghieu", sanpham.ThuonghieuID);
            return View(sanpham);
        }

        // POST: Admin/Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile file, [Bind("SanphamID,Tensanpham,DanhmucID,ThuonghieuID,Hinhanh,Dongia,Sale,Thanhtien")] Sanpham sanpham)
        {
            if (id != sanpham.SanphamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        sanpham.Hinhanh = Upload(file);
                    }
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.SanphamID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhmucID"] = new SelectList(_context.Danhmuc, "DanhmucID", "Tendanhmuc", sanpham.DanhmucID);
            ViewData["ThuonghieuID"] = new SelectList(_context.Thuonghieu, "ThuonghieuID", "Tenthuonghieu", sanpham.ThuonghieuID);
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.Danhmucs)
                .Include(s => s.Thuonghieus)
                .FirstOrDefaultAsync(m => m.SanphamID == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Admin/Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sanpham == null)
            {
                return Problem("Entity set 'websiteSPcongngheContext.Sanpham'  is null.");
            }
            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham != null)
            {
                _context.Sanpham.Remove(sanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
          return (_context.Sanpham?.Any(e => e.SanphamID == id)).GetValueOrDefault();
        }

        public string Upload(IFormFile file)
        {
            string fn = null;

            if (file != null)
            {
                // Phát sinh tên mới cho file để tránh trùng tên
                fn = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = $"wwwroot\\images\\products\\{fn}"; // đường dẫn lưu file
                // upload file lên đường dẫn chỉ định
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return fn;
        }

        public const string LISTIMPORT = "addimport";

        public async Task<IActionResult> Stored()
        {
            var websiteSPcongngheContext = _context.Sanpham;
            ViewData["SanphamID"] = new SelectList(_context.Sanpham, "SanphamID", "Tensanpham");
            ViewData["DonvitinhID"] = new SelectList(_context.Donvitinh, "DonvitinhID", "Ten");
            return View(await websiteSPcongngheContext.ToListAsync());
        }

        List<CartImport> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(LISTIMPORT);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartImport>>(jsoncart);
            }
            return new List<CartImport>();
        }

        void SaveCartSession(List<CartImport> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString("addimport", jsoncart);
        }

        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove("addimport");
        }

        public async Task<IActionResult> AddToCart([Bind("SanphamID,DonvitinhID,Soluong")] CartImport importItem)
        {
            var product = await _context.Sanpham
                .FirstOrDefaultAsync(m => m.SanphamID == importItem.SanphamID);
            var dvt = await _context.Donvitinh
                .FirstOrDefaultAsync(m => m.DonvitinhID == importItem.DonvitinhID);
            var cart = GetCartItems();
            var item = cart.Find(p => p.Sanphams.SanphamID == importItem.SanphamID);
            if (item != null)
            {
                item.Soluong += importItem.Soluong;
            }
            else
            {
                cart.Add(new CartImport() { Sanphams = product, Donvitinh = dvt, Soluong = importItem.Soluong });
            }
            SaveCartSession(cart);
            return RedirectToAction("Stored", "Sanphams");
        }

        [Route("/updateitem", Name = "updateitem")]
        public async Task<IActionResult> UpdateItem(int id, int quantity)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.Sanphams.SanphamID == id);
            if (quantity == 0)
            {
                cart.Remove(item);
            }
            item.Soluong = quantity;
            SaveCartSession(cart);
            return RedirectToAction(nameof(Import));
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.Sanphams.SanphamID == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(Import));
        }

        [Route("/admin/sanphams/import", Name = "import")]
        public IActionResult Import()
        {
            ViewData["NhacungcapID"] = new SelectList(_context.Nhacungcap, "NhacungcapID", "Ten");
            return View(GetCartItems());
        }

        public async Task<IActionResult> CreateBill(int NhaCungCapID)
        {
            // lưu hóa đơn
            var bill = new Nhapsanpham();
            bill.Ngaynhap = DateTime.Now;
            bill.NhacungcapID = NhaCungCapID;
            bill.TaikhoanID = (int)HttpContext.Session.GetInt32("_IDadmin");

            _context.Add(bill);
            await _context.SaveChangesAsync();

            var cart = GetCartItems();
            int amount = 0;
            int soLuong = 0;
            //chi tiết hóa đơn
            foreach (var i in cart)
            {
                var b = new Nhapchitiet();
                b.NhapsanphamID = bill.NhapsanphamID;
                b.SanphamID = i.Sanphams.SanphamID;
                b.DonvitinhID = i.Donvitinh.DonvitinhID;
                b.Dongia = i.Sanphams.Thanhtien;
                b.Soluong = i.Soluong;
                amount = i.Sanphams.Thanhtien * i.Soluong;
                b.Thanhtien = amount;

                var sp = _context.Sanpham.FirstOrDefault(s => s.SanphamID == b.SanphamID);
                sp.Soluong += i.Soluong;
                bill.Tongtien += amount;
                _context.Add(b);
            }
            await _context.SaveChangesAsync();
            ClearCart();
            return RedirectToAction(nameof(Stored));
        }

        public async Task<IActionResult> HistoryImport()
        {
            var h = _context.Nhapsanpham.Include(s => s.Taikhoans).Include(s => s.Nhacungcaps);
            ViewData["SanphamID"] = new SelectList(_context.Sanpham, "SanphamID", "Tensanpham");
            ViewData["DonvitinhID"] = new SelectList(_context.Donvitinh, "DonvitinhID", "Ten");
            return View(await h.ToListAsync());
        }

        public async Task<IActionResult> ImportDetails(int? id)
        {
            var websiteSPcongngheContext = _context.Nhapchitiet
                .Include(c => c.Nhapsanphams)
                .Include(c => c.Sanphams)
                .Include(c => c.Donvitinhs)
                .Where(m => m.NhapsanphamID == id);

            return View(await websiteSPcongngheContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var sp = await _context.Sanpham.FirstOrDefaultAsync(s => s.SanphamID == id);
            ViewBag.thongtin = _context.Thongtin;
            ViewBag.thongso = _context.Thongso;
            ViewBag.hinhanh = _context.Hinhanh;
            //ViewBag.khuyenmai = _context.KhuyenMai;
            return View(sp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, [Bind("ThongtinID,SanphamID,Tronghop,Baohanh,Chinhsach")] Thongtin thongTin
            , [Bind("ThongsoID,SanphamID,Tenthongso,Noidung")] Thongso thongSo,
            IFormFile file, [Bind("HinhanhID,SanphamID,Anh")] Hinhanh hinhAnh)
        {
            if (thongTin.Baohanh != null)
            {
                _context.Update(thongTin);
                await _context.SaveChangesAsync();
            }
            //else if (khuyenMai.NoiDung != null)
            //{
            //    _context.Update(khuyenMai);
            //    await _context.SaveChangesAsync();
            //}
            else if (thongSo.Tenthongso != null)
            {
                _context.Update(thongSo);
                await _context.SaveChangesAsync();
            }
            else
            {
                hinhAnh.Anh = Upload(file);
                _context.Update(hinhAnh);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }

        public async Task<IActionResult> DeleteThongTin(int? id)
        {
            var tt = await _context.Thongtin
                .FirstOrDefaultAsync(m => m.SanphamID == id);

            _context.Thongtin.Remove(tt);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }

        public async Task<IActionResult> DeleteThongSo(int? id)
        {
            var ts = await _context.Thongso
                .FirstOrDefaultAsync(m => m.SanphamID == id);

            _context.Thongso.Remove(ts);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }

        public async Task<IActionResult> DeleteHinhAnh(int? id)
        {
            var tt = await _context.Hinhanh
                .FirstOrDefaultAsync(m => m.HinhanhID == id);

            _context.Hinhanh.Remove(tt);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }
    }
}
