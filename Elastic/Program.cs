using Nest;
using System;

namespace Elastic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Index、Type ElasticSearch 建议小写
            ConnectionSettings connectionSetting = new ConnectionSettings(new Uri("http://10.10.21.214:9200")).DefaultIndex("order");

            ElasticClient elasticClient = new ElasticClient(connectionSetting);

            //匹配全部
            var matchAll = elasticClient.Search<SaleOrder>(s => s
                .Type("saleOrder")
                .Query(q => q.MatchAll()));

            //单模糊匹配
            var singleFuzzy = elasticClient.Search<SaleOrder>(s => s
                .Type("saleOrder")
                .Query(q => q.QueryString(t => t.Fields(x => x.Field("SaleOrderDetails.FullName")).Query("纸"))));

            //多模糊匹配
            var mutilFuzzy = elasticClient.Search<SaleOrder>(s => s
                .Type("saleOrder")
                .Query(q => q.Bool(b => b.Must(p =>
                    p.QueryString(t => t.Fields(x => x.Field("SaleOrderDetails.FullName")).Query("纸")) ||
                    p.QueryString(t => t.Fields(x => x.Field("SaleOrderDetails.FullName")).Query("银行"))))));

            Console.ReadKey();

        }
    }
}
