namespace BussinessLayer.request
{
    public class EmployeesRequest
    {
        public string SHoTen { get; set; } = null!;

        public string SSoDienThoai { get; set; } = null!;
        public string? SVaiTro { get; set; } = "staff";
        public string SMatKhau { get; set; } = null!;
    }
}