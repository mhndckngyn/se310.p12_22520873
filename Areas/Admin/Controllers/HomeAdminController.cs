using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using se310_th.Context;
using se310_th.Models;

namespace se310_th.Areas.Admin.Controllers;

[Area("admin")]
[Route("admin")]
public class HomeAdminController : Controller
{
    private QlBanHangContext db = new QlBanHangContext();
    
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("loaisanpham")]
    public IActionResult DanhMucLoaiSanPham()
    {
        var categories = db.LoaiSanPhams.ToList();
        return View(categories);
    }

    [Route("taoloaisanpham")]
    [HttpGet]
    public IActionResult TaoLoaiSanPham()
    {
        return View();
    }
    
    [Route("taoloaisanpham")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TaoLoaiSanPham(LoaiSanPham loai)
    {
        if (ModelState.IsValid)
        {
            db.Add(loai);
            db.SaveChanges();
            TempData["message"] = "Thêm loại sản phẩm thành công";
            return RedirectToAction("DanhMucLoaiSanPham");
        }

        TempData["message"] = "Thêm loại sản phẩm không thành công";
        return RedirectToAction("DanhMucLoaiSanPham");
    }
    
    [Route("sualoaisanpham")]
    [HttpGet]
    public IActionResult SuaLoaiSanPham(string maLoaiSanPham)
    {
        var loaiSanPham = db.LoaiSanPhams.Find(int.Parse(maLoaiSanPham));
        return View(loaiSanPham);
    }
    
    [Route("sualoaisanpham")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SuaLoaiSanPham(LoaiSanPham loai)
    {
        if (ModelState.IsValid)
        {
            db.Update(loai);
            db.SaveChanges();
            TempData["message"] = "Sửa loại sản phẩm thành công";
            return RedirectToAction("DanhMucLoaiSanPham");
        }

        TempData["message"] = "Sửa loại sản phẩm không thành công";
        return RedirectToAction("DanhMucLoaiSanPham");
    }

    [Route("xoaloaisanpham")]
    public IActionResult XoaLoaiSanPham(string maLoaiSanPham)
    {
        var hasSanPham = db.SanPhams.Any(sp => sp.MaSanPham == int.Parse(maLoaiSanPham));
        if (hasSanPham)
        {
            TempData["message"] = "Xoá không thành công do tồn tại sản phẩm loại này";
            return RedirectToAction("DanhMucLoaiSanPham");
        }

        db.Remove(db.LoaiSanPhams.Find(int.Parse(maLoaiSanPham)));
        db.SaveChanges();
        TempData["message"] = "Xoá thành công";
        return RedirectToAction("DanhMucLoaiSanPham");
    }
    
    [Route("sanpham")]
    public IActionResult DanhMucSanPham()
    {
        var products = db.SanPhams.ToList();
        return View(products);
    }

    [Route("taosanpham")]
    [HttpGet]
    public IActionResult TaoSanPham()
    {
        ViewBag.LoaiSp = new SelectList(db.LoaiSanPhams.ToList(), "MaLoai", "TenLoai");
        return View();
    }
    
    [Route("taosanpham")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TaoSanPham(SanPham sanPham)
    {
        if (ModelState.IsValid)
        {
            db.Add(sanPham);
            db.SaveChanges();
            TempData["message"] = "Thêm sản phẩm thành công";
            return RedirectToAction("DanhMucSanPham");
        }
        TempData["message"] = "Thêm sản phẩm không thành công";
        return RedirectToAction("DanhMucSanPham");
    }
    
    [Route("suasanpham")]
    [HttpGet]
    public IActionResult SuaSanPham(string maSanPham)
    {
        var sanPham = db.SanPhams.Find(int.Parse(maSanPham));
        return View(sanPham);
    }
    
    [Route("suasanpham")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SuaSanPham(SanPham sanPham)
    {
        if (ModelState.IsValid)
        {
            db.Update(sanPham);
            db.SaveChanges();
            TempData["message"] = "Sửa sản phẩm thành công";
            return RedirectToAction("DanhMucSanPham");
        }

        TempData["message"] = "Sửa sản phẩm không thành công";
        return RedirectToAction("DanhMucSanPham");
    }

    [Route("xoasanpham")]
    public IActionResult XoaSanPham(string maSanPham)
    {
        db.Remove(db.SanPhams.Find(int.Parse(maSanPham)));
        db.SaveChanges();
        TempData["message"] = "Xoá sản phẩm thành công";
        return RedirectToAction("DanhMucSanPham");
    }
}