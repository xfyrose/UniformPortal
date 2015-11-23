using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeStudy.UI.ProMvc5.Models
{
    public class Order
    {
        [HiddenInput]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        //[Display(ResourceType = typeof(Resource1), Name = "UserName")]
        [Remote("CheckUserName", "Order")]
        public string UserName { get; set; }
        //[Required]
        //[StringLength(160, MinimumLength = 3)]
        //[Display(Name = "LastName 1")]
        public string FirstName { get; set; }
        [Display(Name = "后面的名字")]
        [Required]
        //[StringLength(160)]
        [MaxWords(3, ErrorMessageResourceType = typeof (Resource1), ErrorMessageResourceName = "Order_LastName_There_are_too_many_words_in__0_")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        //[Required]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        //[Range(typeof(decimal), "0.00", "49.99")]
        public decimal Total { get; set; }

        //public List<OrderDetail> OrderDetails { get; set; }
    }
}