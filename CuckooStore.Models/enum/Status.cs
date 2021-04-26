using System.ComponentModel;

public enum Status
{
    [Description("Chờ xác nhận")]
    ChoXacNhan,
    [Description("Đang giao")]
    DangGiao,
    [Description("Đã nhận")]
    DaNhan,
    [Description("Đã hủy")]
    DaHuy,
}
