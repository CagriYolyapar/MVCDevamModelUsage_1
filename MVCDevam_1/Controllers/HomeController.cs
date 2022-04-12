using MVCDevam_1.Models.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDevam_1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            #region OnemliNotlar

            //View metodunun farklı bir View döndürmesi icerisine explicit(acıkca) string bir tipte argüman verilmesiyle olur... BU metodun bir de object tipinde bir parametresi vardır...Bu object tipindeki parametreli overload'inin görevi de View'a Model göndermektir...Bir View metodunun farklı bir View döndürmesi ile Model göndermesi arasında fark vardır...Bu metotta acık bir şekilde bir string parametre tanımlanmıs ve aynı zamanda bir object tipinde parametre de tanımlanarak overload yapılmıstır... object tipinde parametreli overload'i icerisine argüman olarak verilen her tipi kabul etse de bu metoda acık acık string tipinde bir argüman verilirse,acık acık string tipinde tanımlanmıs bir parametresi oldugu icin string parametreli overload'ı calısır(yani size o isimde bir View döndürmeye calısır)...Dolayısıyla siz bir string tipinde model göndermiş degil farklı bir View döndürmüş olursunuz...


            //Model göndermek Front End'de göstermek istedigimiz bilgileri Back End'den Front End'e yollamanın bir yoludur...Eger bu bilgi string tipte yollanacak ise o zaman string verisinin object'e cast edilerek argüman olarak verilmesi gerekir("Deneme" as object)

            //Model göndermek cok performanslı ve oldukca yetenekli bir yöntem oldugundan dolayı kompleks modelleri destekleyen en iyi yöntemdir. Digerleri de destekler ama bunu yaparken performans düsürürler...


            #endregion

            List<Product> urunler = new List<Product>
            {
                new Product
                {
                    ProductName = "Tadelle",
                    ID = 1,
                    UnitPrice = 8
                },
                new Product
                {
                    ProductName = "Biskrem",
                    ID = 2,
                    UnitPrice  = 5
                },
                new Product
                {
                    ProductName = "Cizi",
                    ID = 3,
                    UnitPrice = 3
                }
            };
           
            //Biz burada bir View'a model gönderiyoruz...

            //Bir View'a model gönderiyorsanız kesinlikle View'in bu modeli karsılaması gerekir...

            //Bİr View, gelen modeli kücük m ile yazılan @model keyword'u ile karsılar...Bir View, modeli karsılarken modelin hangi tipte hangi tipte geldigini bilmek zorundadır...Baska bir şeye gerek yoktur...


            //Her bir View bir Model property'sine sahiptir...Eger bir View Model karsılamak istiyorsa bu ilgili property'sinin set ozelleştirilmiş metoduna gider...Yani View'in Model property'sinin set metodu calısmalıdır ki Model karsılansın...Bir View icerisinde bu set'i @model keyword'u ile RazorView sayesinde calıstırırsınız...BUradaki keyword'de kücük m'ye dikkat edilmelidir...Cünkü get yapmak icin de @Model keyword'unu calıstırmalısınız...(büyük M)


            //Bir View'in sadece bir modeli olabilir...



            return View(urunler);
        }

        public ActionResult BringByID(int id)
        {
            List<Product> urunler = new List<Product>
            {
                new Product
                {
                    ID = 1,
                    ProductName = "Tadelle",
                    UnitPrice = 12.3M
                },

                new Product
                {
                    ID = 2,
                    ProductName = "Cizi",
                    UnitPrice = 13.4M
                }
            };

            Product yakalanan = urunler.FirstOrDefault(x => x.ID == id);

            return View(yakalanan);
        }


        public ActionResult Bring(int? identity)
        {
            List<Product> urunler = new List<Product>()
            {
                new Product
                {
                    ID = 1,
                    ProductName = "Tadelle",
                    UnitPrice = 12.3M
                },
                 new Product
                {
                    ID = 2,
                    ProductName = "Cizi",
                    UnitPrice = 11.2M
                },
                new Product
                {
                    ID = 3,
                    ProductName = "Biskrem",
                    UnitPrice = 12.3M
                },
                new Product
                {
                    ID = 4,
                    ProductName = "Jelibon",
                    UnitPrice = 12.3M
                },
                new Product
                {
                    ID = 5,
                    ProductName = "Tutku",
                    UnitPrice = 12.3M
                },

            };

            List<Product> gonderilecekModel = identity == null || identity > 5 ? urunler : urunler.Where(x => x.ID == identity).ToList();


            return View(gonderilecekModel);
        }



        public ActionResult RazorHelper()
        {
            //Eger bir Action, View'a model göndermiyorsa;ancak buna rağmen View'imiz sanki bir model karsılarmıs gibi @model keyword'u ile bir model set etmişsse bu demektir ki bir post request'inde bu View bir Post Action'ına veri gönderiyor...


            return View();
        }
        
        //Post edilen her veri istisnasız View'da bir Form tag'inin icerisinde bulunmalıdır...

        [HttpPost] //Takip eden Action Post request'ine hizmet edecek...
        public ActionResult RazorHelper(Product item) //Bir View'dan gönderilen Model uygun sartlarda buradaki parametreye argüman olarak gelir...
        {
            return View();
        }

    }
}