using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.CRM
{
    public class CrmDealsPage
    {
        public IWebDriver Driver { get; }

        private readonly WebItem createDealButton = new WebItem(
            "//span[contains(@class,'ui-btn-text') and (contains(.,'Создать'))]",
            "Кнопка 'Создать' на странице Сделок"
        );

        public CrmDealsPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public CrmDealEditForm ClickCreate()
            {
                createDealButton.Click();
                return new CrmDealEditForm(Driver);
            }
    }
}
