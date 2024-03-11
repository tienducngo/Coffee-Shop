using QLCP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace cp.Models
{
    public class CartModel
    {

        private QLBHEntities db = new QLBHEntities();
        //internal int Mã_đồ_uống;
        //internal int Mã_đồ_ăn;
        //private int id;

        public int Mã_sản_phẩm { get; set; }
        [DisplayName("Mã sản phẩm")]
        public string Tên_sản_phẩm { get; set; }
        [DisplayName("Tên sản phẩm")]
        public decimal? Đơn_giá { get; set; }
        [DisplayName("Đơn giá")]
        public int Số_lượng { get; set; }
        [DisplayName("Số lượng")]
        public decimal? Thành_tiền { get { return Số_lượng * Đơn_giá; } }
        public CartModel(int id)
        {
            Sản_phẩm p = db.Sản_phẩm.FirstOrDefault(s => s.Mã_sản_phẩm == id);
            Mã_sản_phẩm = p.Mã_sản_phẩm;
            Tên_sản_phẩm = p.Tên_sản_phẩm;
            Đơn_giá = p.Giá_bán;
            Số_lượng = 1;
        }

        //public CartModel(int id)
        //{
        //    this.id = id;
        //}
    }
}