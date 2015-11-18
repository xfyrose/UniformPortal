using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.Xmls
{
    [TestClass]
    public class UnitTestXml
    {
        [TestMethod]
        public void TestMethod_Xml()
        {
            //string s1 = "a a";
            //Console.WriteLine(System.Web.HttpUtility.HtmlEncode(s1));

            //string xml = HttpUtility.HtmlDecode(Common.Helper.HttpHelper.XmlWebResponse("http://127.0.0.1:81/guanli/uums/uums.ashx?AppId=79259d6c-2b8e-42bf-a182-d457a88163be&AppName=%e7%bb%9f%e4%b8%80%e7%94%a8%e6%88%b7%e7%b3%bb%e7%bb%9f&Action=APPLISTUSER&AppAdminUserId=%e9%ab%98%e8%80%83%e6%95%b0%e6%8d%ae01&AppAdminUserPassword=b2f5ff47436671b6e533d8dc3614845d"));
            //XDocument xDoc = XDocument.Parse(xml);
            //Console.WriteLine(xDoc);

            //Console.WriteLine(Common.Helper.XmlHelper.XmlToModel<Module.Model.UserModel>((xDoc.Root.Element("Message").Element("UserModel").Elements().ToList())[1].ToString()));

            //Console.WriteLine(xDoc.Root.Name);
            //Console.WriteLine(xDoc.Root.Value);

            //XElement xEle = xDoc.Root.Element("Message");
            //Console.WriteLine(xEle.Value);

            //Console.WriteLine(typeof(Module.Model.UserModel).Name);

            //UserModel Model = new UserModel();
            //Model.Id = "test01";
            //Model.Name = "test01 Name";
            //Model.PasswordChangeCount = 0;
            ////Console.WriteLine(Model);

            //string ele = Common.Helper.XmlHelper.ModelToXml<UserModel>(Model);
            //Console.WriteLine("ToXML:" + ele);

            //UserModel modelUser = Common.Helper.XmlHelper.XmlToModel<UserModel>(ele);
            //Console.WriteLine(modelUser);

            //string xml = "<users><user><name>aaa</name></user><user><name>bbb</name></user></users>";
            //XDocument xDoc = XDocument.Parse(xml);
            //Console.WriteLine("root:" + Common.Helper.Function.ConvertListXElementToString((xDoc.Root.Elements()).ToList()));
        }
    }
}
