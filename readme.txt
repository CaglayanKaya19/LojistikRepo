DB Yapısı
A Lojistik Projesinde
	tbl_external_order : B Lojistik firmasından alınan sipariş bilgileri bu tabloya yazılmaktadır.
	tbl_order_delivey : Alınan siparişim durum,taşımacılık ve tamamlanan verileri bu tabloya atılmaktadır.

B Lojistik Projesinde
	tbl_order	: Firmaların alınan siparişlerinin tutulduğu tablo
	tbl_product : x Lojistik firmasının B Lojistik firması üzerinde bulunan stok tablosu
	
1. Olarak çalışacak uygulama/lar
	* B Lojistik Projesinde : BLogistics.WCFService
	* A Lojistik Projesinde : ALogistics.Console.WCFDataTransfer
Burada A Lojistik firmasının B Lojistik firmasındaki siparişlerini alıyor. Sipariş listesini alırken bir önceki günün siparişleri alınmakta(AddDays(-1)). A Lojistik firması aldığı siparişlerin durumunu tbl_order_delivey tablosunda 0 olarak atıyor.

2.Olarak çalışacak uygulama/lar
	* A Lojistik Projesinde : ALogistics.Web
Web uygulaması üzerinde A Lojistik firması taşımacılığını yaptığı siparişin araç plakasını ve siparişin durumunu 1 olarak güncellemektedir.

3. Olarak çalışacak uygulama/lar
	* B Lojistik Projesinde : BLogistics.WebApi
	* A Lojistik Projesinde : ALogistics.Console.ApiDataTransfer
Burada A Lojistik firmasının statü durumu 1 olan siparişlerini alıp B Lojistik firmasına siparişin tamamlandığının bilgisini Api ile iletip kendi veri tabanındaki tbl_order_delivey tablosundaki durumunu 2 olarak güncellemektedir.


Projede Katmanlı mimari kullanmaya ve temiz kod yazmaya özen gösterdim. Ek olarak Interface leri register edebilmek için AUTOFAC thirt party nuget paketten faydalandım. Api,WCF ve Console uygulamasında. Web projelerinde Autofac de bi hata yaptığım için çalıştıramadım zaman kaybetmemek adına da burada da icrosoft.AspNet.WebFormsDependencyInjection.Unity nuget paketinden faydalandım.

NOT: Projeyi çalıştırmadan önce sql_create.sql dosyasını çalıştırmanız gerekmektedir. İlk olarak afaki veriler gelecektir.Bu veriler üzerinde oynama yapabilirsiniz. Veri eklemek için B Lojistik firmasına bir arayüz olamadığnı biliyorum fakat yoğunluğumdan dolayı projeyi çok geç sürede tamamladım daha da zaman kaybetmek istemedim açıkçası. WCF servis üzerinde asenkron metod uygulamak + olduğunu biliyorum ben burada siz adım adım görebilmeniz için ekledim. Genel olarak anlatacaklarım bu kadar. İlginiz için teşekkür ederim.

EK NOT: projelerin localhost portları sizde farklılık gösterebilir kod içerisinde kazılı olarak yazılı. ayrıca A ve B projesinde ConnectionStringleri de değiştirmeyi unutmayınız:)

<add name="ALogisticsEntities" connectionString="metadata=res://*/ALogistics.csdl|res://*/ALogistics.ssdl|res://*/ALogistics.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DEVELOPER;initial catalog=A_Logistics;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />	
 
<add name="BLogisticsEntities" connectionString="metadata=res://*/BLogistics.csdl|res://*/BLogistics.ssdl|res://*/BLogistics.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DEVELOPER;initial catalog=B_Logistics;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
