namespace ElectronicStore.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int khachHangID { get; set; }

        [StringLength(50)]
        [Display(Name ="Họ Tên")]
        public string hoTen { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string eMail { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string diaChi { get; set; }

        [StringLength(11)]
        [Display(Name = "Số Điện Thoại")]
        [Phone]
        public string soDienThoai { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật Khẩu")]
        public string passWord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
