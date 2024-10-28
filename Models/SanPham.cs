using System;
using System.Collections.Generic;

namespace se310_th.Models;

public partial class SanPham
{
    public int MaSanPham { get; set; }

    public string TenSanPham { get; set; } = null!;

    public decimal Gia { get; set; }

    public int? SoLuong { get; set; }

    public int? MaLoai { get; set; }

    public virtual LoaiSanPham? MaLoaiNavigation { get; set; }
}
