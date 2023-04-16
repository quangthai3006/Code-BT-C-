using BTBuoi4.Entitics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTBuoi4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private static List<SinhVien> listSinhVien = new List<SinhVien>();


        [HttpPost]
        public IActionResult ThemSinhVien(SinhVien sinhVien)
        {
            sinhVien.Id = listSinhVien.Count + 1;
            listSinhVien.Add(sinhVien);
            return Ok("Thêm sinh viên thành công!");
        }


        [HttpPut("{id}")]
        public IActionResult CapNhatSinhVien(int id, SinhVien sinhVien)
        {
            SinhVien sv = listSinhVien.FirstOrDefault(s => s.Id == id);
            if (sv == null)
            {
                return NotFound();
            }
            sv.TenSinhVien = sinhVien.TenSinhVien;
            sv.MaSinhVien = sinhVien.MaSinhVien;
            sv.NgaySinh = sinhVien.NgaySinh;
            return Ok("Cập nhật thông tin sinh viên thành công!");
        }


        [HttpGet("{id}")]
        public IActionResult LayThongTinSinhVien(int id)
        {
            SinhVien sv = listSinhVien.FirstOrDefault(s => s.Id == id);
            if (sv == null)
            {
                return NotFound();
            }
            return Ok(sv);
        }


        [HttpDelete("{id}")]
        public IActionResult XoaSinhVien(int id)
        {
            SinhVien sv = listSinhVien.FirstOrDefault(s => s.Id == id);
            if (sv == null)
            {
                return NotFound();
            }
            listSinhVien.Remove(sv);
            return Ok("Xóa sinh viên thành công!");
        }

        // Lấy danh sách sinh viên
        [HttpGet]
        public IActionResult LayDanhSachSinhVien()
        {
            return Ok(listSinhVien);
        }
    }

}
