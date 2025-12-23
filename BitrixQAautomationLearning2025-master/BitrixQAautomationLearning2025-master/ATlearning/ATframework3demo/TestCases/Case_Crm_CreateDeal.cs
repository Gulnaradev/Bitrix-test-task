using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects.CRM;

namespace ATframework3demo.TestCases
{
    public class Case_Crm_CreateDeal : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
            {
                new TestCase(
                    "CRM: Создание и отображение формы сделки",
                    homePage =>
                    {
                        homePage.LeftMenu.OpenCrmDeals();
                        new CrmDealsPage()
                        .ClickCreate()
                        .WaitUntilLoaded()
                        .SetTitle("Auto Deal")
                        .AddFirstProduct()
                        .SetProductQuantity(2)
                        .Save();

                        new CrmDealDetails().WaitUntilOpened(5);
                        //Тут также можно расширить и добавить проверки на остальные детали сделки 

                    })
            };
        }
    }
}
