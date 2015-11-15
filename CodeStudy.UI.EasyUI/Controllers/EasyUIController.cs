using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace CodeStudy.UI.EasyUI.Controllers
{
    public class EasyUIController : Controller
    {
        // GET: EasyUI
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index01()
        {
            return View();
        }

        public ActionResult Index02Data()
        {
            return View();
        }

        public ActionResult Index02Js()
        {
            return View();
        }

        public ActionResult Index03Data()
        {
            return View();
        }

        public ActionResult Index03Js()
        {
            return View();
        }

        public ActionResult Index04Data()
        {
            return View();
        }

        public ActionResult Index04Js()
        {
            return View();
        }

        public ActionResult Index05Data()
        {
            return View();
        }

        public ActionResult Index05Js()
        {
            return View();
        }

        public ActionResult Index06Data()
        {
            return View();
        }

        public ActionResult Index06Js()
        {
            return View();
        }

        public ActionResult Index07Data()
        {
            return View();
        }

        public ActionResult Index07Js()
        {
            return View();
        }

        public ActionResult Index08Data()
        {
            return View();
        }

        public ActionResult Index08Js()
        {
            return View();
        }

        public ActionResult Index09Data()
        {
            return View();
        }

        public ActionResult Index09Js()
        {
            return View();
        }

        public JsonResult Index09_1()
        {
            Thread.Sleep(3000);
            return Json("help 123", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index10Data()
        {
            return View();
        }

        public ActionResult Index10Js()
        {
            return View();
        }

        public ActionResult Index11Data()
        {
            return View();
        }

        public ActionResult Index11Js()
        {
            return View();
        }

        public ActionResult Index12Data()
        {
            return View();
        }

        public ActionResult Index12Js()
        {
            return View();
        }

        public ActionResult Index13Data()
        {
            return View();
        }

        public ActionResult Index13Js()
        {
            return View();
        }

        public ActionResult Index14Data()
        {
            return View();
        }

        public ActionResult Index14Js()
        {
            return View();
        }

        public ActionResult Index15Data()
        {
            return View();
        }

        public ActionResult Index15Js()
        {
            return View();
        }

        public ActionResult Index16Data()
        {
            return View();
        }

        public ActionResult Index16Js()
        {
            return View();
        }

        public ActionResult Index17Data()
        {
            return View();
        }

        public ActionResult Index17Js()
        {
            return View();
        }

        public ActionResult Index18Data()
        {
            return View();
        }

        public ActionResult Index18Js()
        {
            return View();
        }

        public ActionResult Index19Data()
        {
            return View();
        }

        public ActionResult Index19Js()
        {
            return View();
        }

        public JsonResult Index19User(int pageNumber = 1, int pageSize = 2)
        {
            List<TestUser> users = new List<TestUser>();
            users.Add(new TestUser { Id = 1, Name = "User01", Email = "user01@.com" });
            users.Add(new TestUser { Id = 2, Name = "User02", Email = "user02@.com" });
            users.Add(new TestUser { Id = 3, Name = "User03", Email = "user03@.com" });
            users.Add(new TestUser { Id = 4, Name = "User04", Email = "user04@.com" });
            users.Add(new TestUser { Id = 5, Name = "User05", Email = "user05@.com" });
            users.Add(new TestUser { Id = 6, Name = "User06", Email = "user06@.com" });
            users.Add(new TestUser { Id = 7, Name = "User07", Email = "user07@.com" });
            users.Add(new TestUser { Id = 8, Name = "User08", Email = "user08@.com" });
            users.Add(new TestUser { Id = 9, Name = "User09", Email = "user09@.com" });
            users.Add(new TestUser { Id = 10, Name = "User10", Email = "user10@.com" });
            users.Add(new TestUser { Id = 11, Name = "User11", Email = "user11@.com" });

            List<TestUser> result = users.Skip((pageNumber - 1)*pageSize).Take(pageSize).ToList();

            Thread.Sleep(2000);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public class TestUser
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }

        public ActionResult Index20Data()
        {
            return View();
        }

        public ActionResult Index20Js()
        {
            return View();
        }

        public ActionResult Index21Data()
        {
            return View();
        }

        public ActionResult Index21Js()
        {
            return View();
        }

        public ActionResult Index21Valid(string abc)
        {
            bool result = abc == "user01";

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index22Data()
        {
            return View();
        }

        public ActionResult Index22Js()
        {
            return View();
        }

        public ActionResult Index23Data()
        {
            return View();
        }

        public ActionResult Index23Js()
        {
            return View();
        }

        public ActionResult Index24Data()
        {
            return View();
        }

        public ActionResult Index24Js()
        {
            return View();
        }

        public ActionResult Index25Data()
        {
            return View();
        }

        public ActionResult Index25Js()
        {
            return View();
        }

        public ActionResult Index26Data()
        {
            return View();
        }

        public ActionResult Index26Js()
        {
            return View();
        }

        public ActionResult Index27Data()
        {
            return View();
        }

        public ActionResult Index27Js()
        {
            return View();
        }

        public ActionResult Index28Data()
        {
            return View();
        }

        public ActionResult Index28Js()
        {
            return View();
        }

        public ActionResult Index29Data()
        {
            return View();
        }

        public ActionResult Index29Js()
        {
            return View();
        }

        public ActionResult Index30Data()
        {
            return View();
        }

        public ActionResult Index30Js()
        {
            return View();
        }

        public ActionResult Index31Data()
        {
            return View();
        }

        public ActionResult Index31Js()
        {
            return View();
        }

        public ActionResult Index31Content(Info31 info)
        {
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public class Info31
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Code { get; set; }
        }

        public ActionResult Index32Data()
        {
            return View();
        }

        public ActionResult Index32Js()
        {
            return View();
        }

        public ActionResult Index32Info(int page, int rows, string sort, string order, string userName)
        {
            List<Info32> result = new List<Info32>
            {
                new Info32
                {
                    UserName = "蜡笔小新",
                    Email = "xiaoxin@163.com",
                    Create = new DateTime(2015, 10, 1)
                },
                new Info32
                {
                    UserName = "蜡笔小新02",
                    Email = "xiaoxin@163.com",
                    Create = new DateTime(2015, 10, 1)
                },
                new Info32
                {
                    UserName = "蜡笔小新03",
                    Email = "xiaoxin@163.com",
                    Create = new DateTime(2015, 10, 1)
                },
                new Info32
                {
                    UserName = "蜡笔小新04",
                    Email = "xiaoxin@163.com",
                    Create = new DateTime(2015, 10, 1)
                },
                new Info32
                {
                    UserName = "樱桃小丸子",
                    Email = "yingtao@163.com",
                    Create = new DateTime(2015, 10, 2)
                },
                new Info32
                {
                    UserName = "樱桃小丸子02",
                    Email = "yingtao@163.com",
                    Create = new DateTime(2015, 10, 2)
                },
                new Info32
                {
                    UserName = "樱桃小丸子03",
                    Email = "yingtao@163.com",
                    Create = new DateTime(2015, 10, 2)
                },
                new Info32
                {
                    UserName = "樱桃小丸子04",
                    Email = "yingtao@163.com",
                    Create = new DateTime(2015, 10, 2)
                },
                new Info32
                {
                    UserName = "黑崎一护",
                    Email = "yihu@163.com",
                    Create = new DateTime(2015, 10, 3)
                },
                new Info32
                {
                    UserName = "黑崎一护02",
                    Email = "yihu@163.com",
                    Create = new DateTime(2015, 10, 3)
                },
                new Info32
                {
                    UserName = "黑崎一护03",
                    Email = "yihu@163.com",
                    Create = new DateTime(2015, 10, 3)
                }
            };

            Thread.Sleep(1000);

            if (sort == "Create")
            {
                result.Sort((i1, i2) => i1.Create.CompareTo(i2.Create));
            }

            if (!string.IsNullOrEmpty(userName))
            {
                result = result.Where(i => i.UserName.Contains(userName)).ToList();
            }

            InfoJson<Info32> infoJson = new InfoJson<Info32>
            {
                total = result.Count,
                rows = result.Skip((page - 1)*rows).Take(rows).ToList()
            };

            return Json(infoJson, JsonRequestBehavior.AllowGet);
            //return JsonConvert.SerializeObject(result);
        }

        public class Info32
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public DateTime Create { get; set; }
        }

        public class InfoJson<T>
        {
            public int total { get; set; }
            public List<T> rows { get; set; }
        }

        public ActionResult Index32Delete(string ids)
        {
            return Json(ids.Split(',').Length, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index32Add(List<Info32> rows)
        {
            return Json(rows.Count, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index33Data()
        {
            return View();
        }

        public ActionResult Index33Js()
        {
            return View();
        }

        public ActionResult Index33Info(string q)
        {
            List<Info33> result = new List<Info33>
            {
                new Info33 { Id="a1", User="user01"},
                new Info33 { Id="a2", User="user02"},
                new Info33 { Id="a3", User="user03"},
                new Info33 { Id="a4", User="user04"},
            };

            if (!string.IsNullOrEmpty(q))
            {
                result = result.Where(i => i.Id.Contains(q)).ToList();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public class Info33
        {
            public string Id { get; set; }
            public string User { get; set; }
        }

        public ActionResult Index34Data()
        {
            return View();
        }

        public ActionResult Index34Js()
        {
            return View();
        }

        public ActionResult Index34Info()
        {
            List<Info34> result = new List<Info34>
            {
                new Info34 {Id = 1, UserName = "user01", Email = "user01@email.com", Create = "2015-10-01"},
                new Info34 {Id = 2, UserName = "user02", Email = "user02@email.com", Create = "2015-10-02"},
                new Info34 {Id = 3, UserName = "user03", Email = "user03@email.com", Create = "2015-10-03"},
                new Info34 {Id = 4, UserName = "user04", Email = "user04@email.com", Create = "2015-10-04"}
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public class Info34
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Create { get; set; }
        }

        public ActionResult Index35Data()
        {
            return View();
        }

        public ActionResult Index35Js()
        {
            return View();
        }

        public ActionResult Index35Info()
        {
            List<Info35> result = new List<Info35>
            {
                new Info35
                {
                    name = "PHP版本",
                    value = "5.4",
                    group = "系统信息",
                    editor = "text"
                },
                new Info35
                {
                    name = "CPU核心",
                    value = "双核四线程",
                    group = "系统信息",
                    editor = "text"
                },
                new Info35
                {
                    name = "超级管理员",
                    value = "Admin",
                    group = "管理信息",
                    editor = "text"
                },
                new Info35
                {
                    name = "管理密码",
                    value = "*******",
                    group = "管理信息",
                    editor = "text"
                }
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public class Info35
        {
            public string name { get; set; }
            public string value { get; set; }
            public string group { get; set; }
            public string editor { get; set; }
        }

        public ActionResult Index36Data()
        {
            return View();
        }

        public ActionResult Index36Js()
        {
            return View();
        }

        public ActionResult Index36Tree(string id)
        {
            //List<Info36> result = new List<Info36>
            //{
            //    new Info36
            //    {
            //        id = 1,
            //        text = "系统管理",
            //        //state = "closed",
            //        children = new List<Info36>
            //        {
            //            new Info36
            //            {
            //                id = 11,
            //                text = "主机信息",
            //                children = new List<Info36>
            //                {
            //                    new Info36
            //                    {
            //                        id = 111,
            //                        text = "版本信息"
            //                    },
            //                    new Info36
            //                    {
            //                        id = 112,
            //                        text = "数据库信息"
            //                    }
            //                }
            //            },
            //            new Info36
            //            {
            //                id = 12,
            //                text = "更新信息"
            //            },
            //            new Info36
            //            {
            //                id = 13,
            //                text = "程序信息"
            //            }
            //        }
            //    },
            //    new Info36
            //    {
            //        id= 2,
            //        text = "会员管理",
            //        children = new List<Info36>
            //        {
            //            new Info36
            //            {
            //                text = "新增会员"
            //            },
            //            new Info36
            //            {
            //                text = "审核会员"
            //            }
            //        }
                    
            //    },
            //};
            List<Info36> result = new List<Info36>
            {
                new Info36
                {
                    id = 1,
                    text = "系统管理",
                    state = "closed",
                    tid = 0
                },

                new Info36
                {
                    id = 4,
                    text = "主机管理",
                    state = "closed",
                    tid = 1
                },

                new Info36
                {
                    id = 7,
                    text = "版本信息",
                    state = "closed",
                    tid = 4
                },

                new Info36
                {
                    id = 8,
                    text = "数据库信息",
                    state = "closed",
                    tid = 4
                },

                new Info36
                {
                    id = 5,
                    text = "更新管理",
                    state = "closed",
                    tid = 1
                },

                new Info36
                {
                    id = 6,
                    text = "程序管理",
                    state = "closed",
                    tid = 1
                },

                new Info36
                {
                    id = 2,
                    text = "会员管理管理",
                    state = "closed",
                    tid = 0
                },

                new Info36
                {
                    id = 9,
                    text = "新增会员",
                    state = "closed",
                    tid = 2
                },

                new Info36
                {
                    id = 10,
                    text = "审核会员",
                    state = "closed",
                    tid = 2
                },
            };

            if (string.IsNullOrEmpty(id))
            {
                result = result.Where(i => i.tid == 0).ToList();
            }
            else
            {
                result = result.Where(i => i.tid == int.Parse(id)).ToList();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public class Info36
        {
            public int id { get; set; }
            public string text { get; set; }
            public string state { get; set; }
            public string @checked { get; set; }
            public string attributes { get; set; }

            public int tid { get; set; }

            public List<Info36> children { get; set; }
        }

        public ActionResult Index39()
        {
            return View();
        }

        public ActionResult Index39CheckLogin(string manager, string password)
        {
            bool result = (manager == "manager") && (password == "123456");

            Thread.Sleep(1000);

            //return result.ToString();
            return Json("false", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index39Admin()
        {
            return View();
        }

        public ActionResult Index39Logout()
        {
            return RedirectToAction("Index39");
        }

        public ActionResult Index39Menu(int? id)
        {
            List<Info39> result = new List<Info39>()
            {
                new Info39
                {
                    id = 1,
                    text = "系统模块",
                    state= "closed",
                    iconCls = "icon-ok",
                    Url = "/EasyUI/Index39Manager",
                    nid = 0
                },
                new Info39
                {
                    id = 2,
                    text = "管理员管理",
                    state = "open",
                    iconCls = "icon-cancel",
                    Url = "/EasyUI/Module2",
                    nid = 1
                },
                new Info39
                {
                    id = 3,
                    text = "会员模块",
                    state = "closed",
                    iconCls = "icon-add",
                    Url = "/EasyUI/Module3",
                    nid = 0
                },
                new Info39
                {
                    id = 4,
                    text = "会员管理",
                    state = "open",
                    iconCls = "icon-edit",
                    Url = "/EasyUI/Module4",
                    nid = 3
                }
            };

            result = result.Where(i => i.nid == (id??0)).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public class Info39
        {
            public int id { get; set; }
            public string text { get; set; }
            public string state { get; set; }
            public string iconCls { get; set; }
            public string Url { get; set; }
            public int nid { get; set; }
        }

        public ActionResult Index39Manager()
        {
            return View();
        }

        public ActionResult Index39Info(int page, int rows, string sort, string order, string userName)
        {
            List<Info39Manager> result = new List<Info39Manager>
            {
                new Info39Manager
                {
                    Id = 1,
                    UserName = "蜡笔小新",
                    Email = "xiaoxin@163.com",
                    Create = new DateTime(2015, 10, 1)
                },
                new Info39Manager
                {
                    Id = 2,
                    UserName = "蜡笔小新02",
                    Email = "xiaoxin@163.com",
                    Create = new DateTime(2015, 10, 1)
                },
                new Info39Manager
                {
                    Id = 3,
                    UserName = "蜡笔小新03",
                    Email = "xiaoxin@163.com",
                    Create = new DateTime(2015, 10, 1)
                },
                new Info39Manager
                {
                    Id = 4,
                    UserName = "蜡笔小新04",
                    Email = "xiaoxin@163.com",
                    Create = new DateTime(2015, 10, 1)
                },
                new Info39Manager
                {
                    Id = 5,
                    UserName = "樱桃小丸子",
                    Email = "yingtao@163.com",
                    Create = new DateTime(2015, 10, 2)
                },
                new Info39Manager
                {
                    Id = 6,
                    UserName = "樱桃小丸子02",
                    Email = "yingtao@163.com",
                    Create = new DateTime(2015, 10, 2)
                },
                new Info39Manager
                {
                    Id = 7,
                    UserName = "樱桃小丸子03",
                    Email = "yingtao@163.com",
                    Create = new DateTime(2015, 10, 2)
                },
                new Info39Manager
                {
                    Id = 8,
                    UserName = "樱桃小丸子04",
                    Email = "yingtao@163.com",
                    Create = new DateTime(2015, 10, 2)
                },
                new Info39Manager
                {
                    Id = 9,
                    UserName = "黑崎一护",
                    Email = "yihu@163.com",
                    Create = new DateTime(2015, 10, 3)
                },
                new Info39Manager
                {
                    Id = 10,
                    UserName = "黑崎一护02",
                    Email = "yihu@163.com",
                    Create = new DateTime(2015, 10, 3)
                },
                new Info39Manager
                {
                    Id = 11,
                    UserName = "黑崎一护03",
                    Email = "yihu@163.com",
                    Create = new DateTime(2015, 10, 3)
                }
            };

            Thread.Sleep(1000);

            if (sort == "Create")
            {
                result.Sort((i1, i2) => i1.Create.CompareTo(i2.Create));
            }

            if (!string.IsNullOrEmpty(userName))
            {
                result = result.Where(i => i.UserName.Contains(userName)).ToList();
            }

            InfoJson<Info39Manager> infoJson = new InfoJson<Info39Manager>
            {
                total = result.Count,
                rows = result.Skip((page - 1) * rows).Take(rows).ToList()
            };

            return Json(infoJson, JsonRequestBehavior.AllowGet);
        }

        public class Info39Manager
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public DateTime Create { get; set; }
        }
    }
}